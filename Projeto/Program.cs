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

builder.Services.AddSwaggerGen();

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
  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});

builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngular", builder =>
  {
    builder.WithOrigins("http://localhost:4200") // Substitua pelo seu URL Angular
             .AllowAnyMethod()
             .AllowAnyHeader();
  });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
