using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Projeto.Models;
using Projeto.Models.Authentication;
using Projeto.Models.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner de serviços.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});
builder.Services.AddDbContext<IdentityContext>(options => {
options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});

builder.Services.AddIdentity<UserIdentity, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.Secret)),
            ValidIssuer = "https://localhost:7009",
            ValidAudience = "audience",

            // Adicionando validação personalizada para obter informações do token
            RoleClaimType = "tipoUsuario" // O nome da claim que contém o tipo de usuário
        };

        // Adicionando evento para processar a claim de tipo de usuário
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var tipoUsuario = context.Principal?.Claims.FirstOrDefault(claim => claim.Type == "tipoUsuario")?.Value;

                // Verificar e adicionar roles com base no tipo de usuário
                if (!string.IsNullOrEmpty(tipoUsuario))
                {
                    var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<UserIdentity>>();
                    var roles = userManager.GetRolesAsync(userManager.FindByNameAsync(context.Principal.Identity.Name).Result).Result;

                    var identity = (JwtIdentity)context.Principal.Identity;
                    identity.AddRoles(roles);
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configuração do escopo de serviço movida para o contexto do aplicativo
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Certifique-se de criar as roles se não existirem
    var roles = new List<string> { "Aluno", "Instrutor" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

public class JwtIdentity : ClaimsIdentity
{
    public void AddRoles(IEnumerable<string> roles)
    {
        foreach (var role in roles)
        {
            AddClaim(new Claim(ClaimTypes.Role, role));
        }
    }
}
