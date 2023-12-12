// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Projeto.Models;

// namespace Projeto.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class CadastrarController : ControllerBase
//     {
//         public readonly Context context;
//           private readonly CriptografiaService criptografia;
//         public CadastrarController(Context _context, CriptografiaService _criptografia)
//         {
//             context = _context;
//             criptografia = _criptografia;

//         }
//         [HttpPost("aluno")]
//         public async Task<ActionResult<AlunoInformacoes>> CadastroAluno(AlunoInformacoes newaluno, string senha)
//         {
//             var email = newaluno.Email;
//             var existealuno = await context.alunos.Where(a => a.Email == email).ToListAsync();
//             if (existealuno.Any()) return BadRequest("Email já cadastrado");
//             context.alunos.Add(newaluno);
//             context.SaveChanges();
//             var usuario = new AuthUsuario{
//                 id = newaluno.Id_aluno,
//                 senhacriptografada = criptografia.HashPassword(senha)
//             };
//             context.user.Add(usuario);
//             await context.SaveChangesAsync();
//             return Ok(newaluno);
//         }
//         [HttpPost("instrutor")]
//         public async Task<ActionResult<InstrutorInformacoes>> CadastroInstrutor(InstrutorInformacoes newinstrutor, string senha)
//         {
//             var email = newinstrutor.Email;
//             var existeinstrutor = await context.instrutors.Where(a => a.Email == email).ToListAsync();
//             if (existeinstrutor.Any()) return BadRequest("Email já cadastrado");
//             context.instrutors.Add(newinstrutor);
//             context.SaveChanges();

//             await context.SaveChangesAsync();
//             return Ok(newinstrutor);
//         }

//     }

// }
