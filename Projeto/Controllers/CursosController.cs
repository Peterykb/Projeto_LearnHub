using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CursosController : ControllerBase
  {
    public readonly Context context;

    public CursosController(Context _context)
    {
      context = _context;
    }

    [HttpGet]

    public async Task<ActionResult<List<Cursos>>> GetAllCursos()
    {
      return Ok(await context.cursos.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task <ActionResult<Cursos>> GetCurso(int id){
      var curso = await context.cursos.FindAsync(id);
      if(curso == null) return NotFound("Curso não encontrado");

      return Ok(curso);
    }

    
  }
}
