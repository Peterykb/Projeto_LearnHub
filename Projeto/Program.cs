using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Projeto.Models;
using Projeto.Models.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Projeto.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto", Version = "v1" });

  var securityScheme = new OpenApiSecurityScheme
  {
    Name = "JWT Authentication",
    Description = "Insira seu token JWT abaixo",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT",
    Reference = new OpenApiReference
    {
      Type = ReferenceType.SecurityScheme,
      Id = "Bearer"
    }
  };

  c.AddSecurityDefinition("Bearer", securityScheme);
  var securityRequirement = new OpenApiSecurityRequirement  
    {
        { securityScheme, new[] { "Bearer" } }
    };

  c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddDbContext<Context>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});

builder.Services.AddIdentity<UserIdentity, UserRole>(options =>
{
  options.SignIn.RequireConfirmedAccount = true;
  options.Password.RequireDigit = true;
  options.Password.RequiredLength = 8;
  options.Password.RequireUppercase = true;
  options.Lockout.MaxFailedAccessAttempts = 3;
  options.SignIn.RequireConfirmedEmail = true;
  options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<Context>();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.Secret))
  };
});

builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthorization();

// builder.Services.AddCors(options =>
// {
//   options.AddPolicy("AllowAngular", builder =>
//   {
//     // builder.WithOrigins("https://deploy-learn-hub.vercel.app") 
//        builder
//                 .AllowAnyOrigin() // Permite qualquer origem
//                 .AllowAnyMethod()
//                 .AllowAnyHeader()
//                 .AllowCredentials();
//   });
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder =>
        {
            builder
                .AllowAnyOrigin() // Permite qualquer origem
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto V1");
  c.RoutePrefix = string.Empty;
  c.OAuthClientId("swagger-ui");
  c.OAuthAppName("Swagger UI");
});
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAnyOriginPolicy");
app.MapControllers();


app.Run();
