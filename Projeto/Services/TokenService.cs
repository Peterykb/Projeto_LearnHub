using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Projeto.Models.Authentication;
using Projeto.Models;
namespace Projeto.Services
{

    public class TokenService
    {
        public static string GenerateToken(Aluno usu)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret));

            var claims = new[]
            {
                new Claim("Usuarioid", usu.Id_aluno.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}