using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Projeto.Models;
using Projeto.Models.Authentication;


var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner de serviços.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});
// builder.Services.AddDbContext<IdentityContext>(options => {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
// });

// builder.Services.AddIdentity<UserIdentity, IdentityRole>()
//     .AddEntityFrameworkStores<Context>()
//     .AddDefaultTokenProviders()
//     .AddSignInManager();

// builder.Services.AddAuthorization();

var app = builder.Build();

// Configuração do escopo de serviço movida para o contexto do aplicativo
// using (var scope = app.Services.CreateScope())
// {
//     var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//     // Certifique-se de criar as roles se não existirem
//     var roles = new List<string> { "Aluno", "Instrutor" };

//     foreach (var role in roles)
//     {
//         if (!await roleManager.RoleExistsAsync(role))
//         {
//             await roleManager.CreateAsync(new IdentityRole(role));
//         }
//     }
// }
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

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
