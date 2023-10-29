using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/cursos")]
  public class CursosController : ControllerBase
  {
    private readonly Context context;

    public CursosController(Context _context)
    {
      context = _context;
    }
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<Cursos>>> GetCursos()
    {
      var cursos = await context.cursos.ToListAsync();
      return Ok(cursos);
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Cursos>> CriarCurso(Cursos curso)
    {
      if (curso == null) return BadRequest("Valor nulo");

      var existecurso = await context.cursos.FirstOrDefaultAsync(cursos => cursos.Name == curso.Name);

      if (existecurso != null) return BadRequest("Curso já existe!");

      var existecategoria = await context.categorias.FirstOrDefaultAsync(Categorias => Categorias.Id_categoria == curso.Id_categoria);

      if (existecategoria == null) return BadRequest("Categoria digitada não encontrada no banco de dados");

      context.cursos.Add(curso);
      await context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCurso), new { id = curso.Id_curso }, curso);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Cursos>> GetCurso(int id)
    {
      var curso = await context.cursos.FindAsync(id);

      if (curso == null)
        return NotFound("Curso não encontrado");

      return Ok(curso);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Cursos>> AtualizarCurso(int id, Cursos curso)
    {
      if (id != curso.Id_curso)
      {
        return BadRequest(new { error = "Os IDs não correspondem." });
      }
      var existecategoria = await context.categorias.FirstOrDefaultAsync(Categorias => Categorias.Id_categoria == curso.Id_categoria);

      if (existecategoria == null) return BadRequest("Categoria digitada não encontrada no banco de dados");


      context.Update(curso); // Rastreia a entidade curso

      try
      {
        await context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }

      return NoContent();
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarCurso(int id)
    {
      var curso = await context.cursos.FindAsync(id);

      if (curso == null)
      {
        return NotFound();
      }

      // Primeiro, exclua as aulas relacionadas
      var aulas = context.aulas.Where(a => a.Id_curso == id);
      context.aulas.RemoveRange(aulas);

      // Em seguida, exclua o curso
      context.cursos.Remove(curso);

      await context.SaveChangesAsync();

      return NoContent();
    }
    [Authorize]
    [HttpDelete]
    public async Task<ActionResult<List<Cursos>>> DeleteAll()
    {
      var cursos = await context.cursos.ToListAsync();
      context.RemoveRange(cursos);
      await context.SaveChangesAsync();

      return await context.cursos.ToListAsync();
    }
  }
}

