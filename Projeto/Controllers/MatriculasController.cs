using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MatriculasController : ControllerBase
  {
    public readonly Context context;
    public MatriculasController(Context _context)
    {
      context = _context;
    }
    [HttpGet("matriculas/aluno/{alunoid}")]
    public async Task<ActionResult<Matricula>> GetAllMatriculas(int alunoid)
    {
      var idcurso = context.matriculas.Where(m => m.AlunoId == alunoid).Select(m => m.CursoId);
      if (idcurso == null) return NotFound("Você não tem matrículas ainda.");
      var cursosdoaluno = await context.cursos.Where(c => idcurso.Contains(c.Id_curso)).ToListAsync();
      return Ok(cursosdoaluno);
    }
    [HttpDelete("matriculas/instrutor-{instrutorid}/{cursoid}/{alunoid}")]
    public async Task<ActionResult<Matricula>> DeleteMatricula(int alunoid, int cursoid, int instrutorid)
    {
      var cursosDoInstrutor = await context.cursos.Where(cursos => cursos.InstrutorId == instrutorid).Select(curso => curso.Id_curso).ToListAsync();
      var matriculaaluno = await context.matriculas.Where(m => m.AlunoId == alunoid && cursosDoInstrutor.Contains(m.CursoId)).ToListAsync();
      if (matriculaaluno == null ) return NotFound("Matrícula não existe.");
      context.Remove(matriculaaluno);
      await context.SaveChangesAsync();

      return Ok(await context.matriculas.Where(m => cursosDoInstrutor.Contains(m.CursoId)).ToListAsync());

    }
  }
}
