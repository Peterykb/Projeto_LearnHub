// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Projeto.Models;

// namespace Projeto.Controllers
// {
//   [Authorize]
//   [ApiController]
//   [Route("api/[controller]")]
//   public class AlunoController : ControllerBase
//   {
//     public readonly Context context;

//     public AlunoController(Context _context)
//     {
//       context = _context;
//     }

//     [HttpGet]
//     public async Task<ActionResult<List<Aluno>>> GetAlunos()
//     {
//       var alunos = await context.alunos.ToListAsync();

//       if(alunos == null) return Ok("Não há alunos cadastrados");

//       return Ok(alunos);
//     }
// 
//     [HttpGet("{id}")]

//     public async Task <ActionResult<Aluno>> GetAluno(int id){
//       var aluno = await context.alunos.FindAsync(id);
//       if(aluno == null) return BadRequest("Aluno não encontrado");

//       return Ok(aluno);
//     }
//   }
// }
