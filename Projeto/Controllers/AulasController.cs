using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AulasController : ControllerBase
  {
    public readonly Context context;
    public AulasController(Context _context)
    {
      context = _context;
    }

    [HttpGet("{moduloid}/aulas")]
    public async Task<ActionResult<List<Aulas>>> GetAllAulas(int moduloid)
    {

      var aulasDomodulo = await context.aulas.Where(a => a.Moduloid == moduloid).ToListAsync();
      if (!aulasDomodulo.Any()) return NotFound("Aulas não encontradas ou modulo não existe");

      return Ok(aulasDomodulo);
    }
    [HttpPost("{cursoid}/{moduloid}/adicionar-aula")]
    [Authorize(Roles = "Instrutor")]
    public async Task<ActionResult<Aulas>> PostAulas(int cursoid, int moduloid, Aulas newaula)
    {
      var cursos = await context.cursos.FindAsync(cursoid);
      if (cursos == null) return BadRequest("Curso não encontrado.");

      var modulos = await context.modulos.FirstOrDefaultAsync(m => m.CursoId == cursoid && m.Id_Modulo == moduloid);
      if (modulos == null) return BadRequest("Módulo não encontrado.");

      var aula = await context.aulas.FirstOrDefaultAsync(a => a.Moduloid == moduloid && a.Titulo == newaula.Titulo);
      if (aula != null) return BadRequest("Aula já existe.");

      newaula.Moduloid = moduloid;
      context.aulas.Add(newaula);
      await context.SaveChangesAsync();

      return Ok(await context.aulas.Where(a => a.Moduloid == moduloid).ToListAsync());
    }
    [HttpPut("{cursoid}/{moduloid}/{aulaid}/modificar-aula")] 
    [Authorize(Roles = "Instrutor")]
    public async Task<ActionResult<Aulas>> PutAulas(int cursoid, int moduloid, int aulaid, Aulas modifyaula)
    {
      var cursos = await context.cursos.FindAsync(cursoid);
      if (cursos == null) return BadRequest("Curso não encontrado.");

      var modulos = await context.modulos.FirstOrDefaultAsync(m => m.CursoId == cursoid && m.Id_Modulo == moduloid);
      if (modulos == null) return BadRequest("Módulo não encontrado.");

      var aula = await context.aulas.FirstOrDefaultAsync(a => a.Id_aulas == aulaid && a.Moduloid == moduloid);
      if (aula == null) return BadRequest("Aula não encontrada");

      // Verifica se a aula pertence ao módulo e curso especificados
      if (aula.Moduloid != moduloid || modulos.CursoId != cursoid)
      {
        return BadRequest("Aula não pertence ao módulo e curso especificados.");
      }

      // Atualiza os campos da aula com os valores fornecidos
      aula.Titulo = modifyaula.Titulo;
      aula.url = modifyaula.url;

      await context.SaveChangesAsync();

      return Ok(await context.aulas.Where(a => a.Moduloid == moduloid).ToListAsync());
    }
    [HttpDelete("{cursoid}/{moduloid}/{aulaid}/deletar-aula")] 
    [Authorize(Roles = "Instrutor")]
    public async Task<ActionResult<List<Aulas>>> DeleteAulas(int cursoid, int moduloid, int aulaid)
    {
      var curso = await context.cursos.FindAsync(cursoid);
      if (curso == null) return BadRequest("Curso não encontrado.");

      var modulo = await context.modulos.FirstOrDefaultAsync(m => m.CursoId == cursoid && m.Id_Modulo == moduloid);
      if (modulo == null) return BadRequest("Módulo não encontrado.");

      var aula = await context.aulas.FirstOrDefaultAsync(a => a.Id_aulas == aulaid && a.Moduloid == moduloid);
      if (aula == null) return BadRequest("Aula não encontrada");

      // Verifica se a aula pertence ao módulo e curso especificados
      if (aula.Moduloid != moduloid || modulo.CursoId != cursoid)
      {
        return BadRequest("Aula não pertence ao módulo e curso especificados.");
      }

      context.aulas.Remove(aula);
      await context.SaveChangesAsync();

      return Ok(await context.aulas.Where(a => a.Moduloid == moduloid).ToListAsync());
    }


  }
}
