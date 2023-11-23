using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ModulosController : ControllerBase
  {
    public Context context;
    public ModulosController(Context _context)
    {
      context = _context;
    }
    [HttpGet("{cursoid}/modulos")]
    public async Task<ActionResult<List<Modulos>>> GetModulos(int cursoid)
    {
      
      return Ok();
    }
    [HttpPost("curso/modulos/{cursoid}/adicionar-modulo")]
    public async Task<ActionResult<Modulos>> PostModulo(Modulos newmodulo, int cursoid)
    {
      var curso = context.cursos.Find(cursoid);
      if (curso == null) return NotFound("Curso não encontrado");

      var modulo = context.modulos.SingleOrDefault(m => m.Id_Modulo == newmodulo.Id_Modulo);
      if (modulo != null) return BadRequest("Modulo já existe.");

      newmodulo.Curso = curso;
      curso.Modulos ??= new List<Modulos>();
      curso.Modulos.Add(newmodulo);

      context.SaveChanges();

      return Ok(await context.modulos.ToListAsync());
    }

  }
}
