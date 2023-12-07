using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Projeto.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner de serviços.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});

builder.Services.AddAuthorization();
// builder.Services.AddIdentity<AlunoInformacoes, InstrutorInformacoes>(options =>
// {
//   options.Password.RequireDigit = true;
//   options.Password.RequiredLength = 8;
//   options.Password.RequireUppercase = true;
//   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
//   options.Lockout.MaxFailedAccessAttempts = 3;
//   options.SignIn.RequireConfirmedEmail = true;
//   options.User.RequireUniqueEmail = true;
// })
// .AddEntityFrameworkStores<Context>()
// .AddDefaultTokenProviders();
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
