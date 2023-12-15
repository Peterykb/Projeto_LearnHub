using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Models.Authentication;
using Projeto.Services;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticationController : ControllerBase
    {
        private readonly TokenService tokenService;
        private readonly UserManager<UserIdentity> userManager;
        private readonly Context context;

        public AutenticationController(TokenService token, UserManager<UserIdentity> user, Context _context)
        {
            tokenService = token;
            userManager = user;
            context = _context;
        }

        [HttpPost("instrutor")]
        public async Task<ActionResult<UserIdentity>> CadastrarInstrutor(InstrutorInformacoes instrutor, string senha)
        {
            try
            {
                var novoInstrutor = new UserIdentity
                {
                    Email = instrutor.Email,
                    UserName = instrutor.Nome
                };

                var resultadoCadastro = await userManager.CreateAsync(novoInstrutor, senha);

                if (resultadoCadastro.Succeeded)
                {
                    await userManager.AddToRoleAsync(novoInstrutor, "Instrutor");

                    var token = tokenService.GerarToken(novoInstrutor.Id, novoInstrutor.UserName, "Instrutor");

                    return Ok(new { Usuario = novoInstrutor, Token = token });
                }
                else
                {
                    return BadRequest(resultadoCadastro.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex}");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                var usuario = await userManager.FindByEmailAsync(model.Email);

                if (usuario != null && await userManager.CheckPasswordAsync(usuario, model.Senha))
                {
                    var rolesUsuario = await userManager.GetRolesAsync(usuario);
                    var role = rolesUsuario.FirstOrDefault();
                    var token = tokenService.GerarToken(usuario.Id, usuario.UserName, role);

                    return Ok(new { Token = token });
                }
                else
                {
                    return Unauthorized(new { Mensagem = "Credenciais inválidas" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor{ex}");
            }
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Senha { get; set; }
        }


    }

}
