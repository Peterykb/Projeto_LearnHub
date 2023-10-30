using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Models.Authentication;
using Projeto.Services;

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

        [HttpPost]

        public IActionResult Auth(string username, string pass){
          var user = context.alunos.SingleOrDefault(a => a.Nome == username && a.Pass == pass);

            if(user != null){
                var token = TokenService.GenerateToken(new Aluno());
                return Ok(token);
            }
            return BadRequest("Username or password invalid");
        }
  }
}
