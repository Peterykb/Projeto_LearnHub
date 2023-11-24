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
      var modulosdocurso = await context.modulos.Where(m => m.CursoId == cursoid).ToListAsync();
      
      return Ok(modulosdocurso);
    }
    [HttpPost("curso/modulos/{cursoid}/adicionar-modulo")]
    public async Task<ActionResult<Modulos>> PostModulo(Modulos newmodulo, int cursoid)
    {
      var curso = context.cursos.Find(cursoid);
      if (curso == null) return NotFound("Curso não encontrado");

      var modulo = context.modulos.SingleOrDefault(m => m.Id_Modulo == newmodulo.Id_Modulo);
      if (modulo != null) return BadRequest("Modulo já existe.");

      newmodulo.CursoId = cursoid;
      curso.Modulos ??= new List<Modulos>();
      curso.Modulos.Add(newmodulo);

      context.SaveChanges();

      return Ok(await context.modulos.ToListAsync());
    }
    

  }
}
