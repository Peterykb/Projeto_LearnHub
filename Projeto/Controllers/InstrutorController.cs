using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class InstrutorController : ControllerBase
  {
    public readonly Context context;

    public InstrutorController(Context _context)
    {
      context = _context;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Cursos>>> GetCurso(int id)
    {
      var cursosDoInstrutor = context.cursos
     .Where(c => c.InstrutorId == id)
     .Select(c => new
     {
       c.Id_curso,
       c.Name,
       c.Data_criacao,
       c.Disponivel,
       c.Preco
       // Adicione mais propriedades do curso conforme necessário
     })
     .ToList();
      if (cursosDoInstrutor.Count == null) return NotFound("Não foi encontrado");
      return Ok(cursosDoInstrutor);
    }
   [HttpPost]
   public async Task <ActionResult<Cursos>> CreateCurso( Cursos novocurso){
    if(novocurso == null) return BadRequest("Dados vazios");

     context.cursos.Add(novocurso);

     await context.SaveChangesAsync();

     return Ok(novocurso);
   }
   

  }
}
