using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        /*{
          "nome": "Pedro",
          "email": "pedroylb123@gmail.com",
          "cpf": "111.111.111-00",
          "dataNascimento": "2003-12-15"
          Senha: 12345@Pe
        }*/
        [HttpPost("aluno")]
        public async Task<ActionResult<UserIdentity>> CadastrarAluno(CadastrarModel cadastro)
        {
            if (cadastro.aluno == null || cadastro.email == null || cadastro.senha == null || cadastro.aluno.Username == null) return BadRequest("Os dados não podem ser nulos");
            try
            {
                var novoAluno = new UserIdentity
                {
                    UserName = cadastro.aluno.Username,
                    Email = cadastro.email
                };
                var resultcadastro = await userManager.CreateAsync(novoAluno, cadastro.senha);
                if (resultcadastro.Succeeded)
                {
                    var aluno = new AlunoInformacoes
                    {
                        Username = cadastro.aluno.Username,
                        Nome = cadastro.aluno.Nome,
                        CPF = cadastro.aluno.CPF,
                        DataNascimento = cadastro.aluno.DataNascimento,
                        Email = cadastro.aluno.Email
                    };
                    await userManager.AddToRoleAsync(novoAluno, "Aluno");
                    var token = tokenService.GerarToken(novoAluno.Id, novoAluno.UserName, "Aluno");
                    context.estudante.Add(aluno);
                    await context.SaveChangesAsync();

                    return Ok(new { Usuario = novoAluno, Token = token });
                }
                else
                {
                    return BadRequest(resultcadastro.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex}");
            }
        }
        [HttpPost("instrutor")]
        public async Task<ActionResult<UserIdentity>> CadastrarInstrutor(InstrutorModel cadastro)
        {
            try
            {
                if (cadastro.instrutor == null || cadastro.email == null || cadastro.senha == null || cadastro.instrutor.Username == null)
                    return BadRequest("Os dados não podem ser nulos");

                var novoInstrutor = new UserIdentity
                {
                    Email = cadastro.email,
                    UserName = cadastro.instrutor.Username
                };

                var resultadoCadastro = await userManager.CreateAsync(novoInstrutor, cadastro.senha);

                if (resultadoCadastro.Succeeded)
                {
                    await userManager.AddToRoleAsync(novoInstrutor, "Instrutor");

                    var token = tokenService.GerarToken(novoInstrutor.Id, novoInstrutor.UserName, "Instrutor");

                    var instrutor = new InstrutorInformacoes
                    {
                        Username = cadastro.instrutor.Username,
                        Nome = cadastro.instrutor.Nome,
                        CPF = cadastro.instrutor.CPF,
                        DataNascimento = cadastro.instrutor.DataNascimento,
                        Email = cadastro.instrutor.Email
                    };

                    context.instrutors.Add(instrutor);
                    await context.SaveChangesAsync();

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
                if (model.Email == null || model.Senha == null) return BadRequest("Campos não podem ser nulos");
                var usuario = await userManager.FindByEmailAsync(model.Email);

                if (usuario != null && await userManager.CheckPasswordAsync(usuario, model.Senha))
                {
                    if (usuario.UserName == null) return BadRequest("Username nulo.");
                    var rolesUsuario = await userManager.GetRolesAsync(usuario);
                    var role = rolesUsuario.FirstOrDefault();
                    if (role == null) return BadRequest("Role não encontrada.");
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
            public string? Email { get; set; }
            public string? Senha { get; set; }
        }
        public class CadastrarModel
        {
            public string? email { get; set; }
            public string? senha { get; set; }
            public AlunoInformacoes? aluno { get; set; }

        }
        public class InstrutorModel{
            public string? email {get;set;}
            public string? senha {get;set;}
            public InstrutorInformacoes? instrutor {get;set;}
        }

    }

}
