using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Projeto.Models;
using Projeto.Models.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

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

// Registrar o DbContext apenas uma vez
builder.Services.AddDbContext<Context>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});

builder.Services.AddIdentity<AlunoLogin, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.AddIdentity<InstrutorLogin, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders()
    .AddSignInManager();


// var provider = builder.Services.BuildServiceProvider();
// var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
// var aluno = await roleManager.RoleExistsAsync("Aluno");

// var instrutor = await roleManager.RoleExistsAsync("Instrutor");

// if(!instrutor) await roleManager.CreateAsync(new IdentityRole("Instrutor"));
// if(!aluno) await roleManager.CreateAsync(new IdentityRole("Aluno"));

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
        ValidAudience = "audience"
      };
    });

// ...

var app = builder.Build();

// Configuração do escopo de serviço
using (var scope = app.Services.CreateScope())
{
  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

  var alunoRoleExists = await roleManager.RoleExistsAsync("Aluno");
  var instrutorRoleExists = await roleManager.RoleExistsAsync("Instrutor");

  if (!instrutorRoleExists)
  {
    await roleManager.CreateAsync(new IdentityRole("Instrutor"));
  }

  if (!alunoRoleExists)
  {
    await roleManager.CreateAsync(new IdentityRole("Aluno"));
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
