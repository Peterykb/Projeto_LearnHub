using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    public readonly Context context;

    public AuthController(Context _context)
    {
      context = _context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Aluno model)
    {

      var user = context.alunos.SingleOrDefault(u => u.Email == model.Email && u.Pass == model.Pass);

      if (user == null)
      {
        // Usuário não encontrado ou credenciais inválidas.
        return BadRequest("Falha na autenticação.");
      }

      // 2. Crie as reivindicações do usuário.
      var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id_aluno.ToString()),
        new Claim(ClaimTypes.Name, user.Nome),
        // Adicione outras reivindicações conforme necessário.
    };

      // 3. Configure as opções do token.
      var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sua_chave_secreta"));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = creds
      };

      // 4. Use o JwtSecurityTokenHandler para criar o token.
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);

      // 5. Retorne o token gerado para o cliente.
      return Ok(new
      {
        token = tokenHandler.WriteToken(token)
      });
    }

  }
}
