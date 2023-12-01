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
    [HttpGet("matriculas/aluno")]
    public async Task<ActionResult<Matricula>> GetAllMatriculas(int alunoid)
    {
      var idcurso = context.matriculas.Where(m => m.AlunoId == alunoid).Select(m => m.CursoId);
      if (idcurso == null) return NotFound("Você não tem matrículas ainda.");
      var cursosdoaluno = await context.cursos.Where(c => idcurso.Contains(c.Id_curso)).ToListAsync();
      return Ok(cursosdoaluno);
    }
    [HttpGet("{nomecurso}/matriculas/instrutor/{instrutorid}")]
    public async Task<ActionResult<List<Matricula>>> GetAllMatriculasCursoInstrutor(int instrutorid, string nomecurso)
    {
      var idcursosinstrutor = await context.cursos.Where(cursos => cursos.InstrutorId == instrutorid && cursos.Name == nomecurso).Select(cursos => cursos.Id_curso).ToListAsync();
      if (!idcursosinstrutor.Any())
      {
        return NotFound($"Não foram encontrados cursos para o instrutor {instrutorid} com o nome '{nomecurso}'.");
      }

      var matriculascursos = await context.matriculas.Where(m => idcursosinstrutor.Contains(m.CursoId)).Select(m => m.AlunoId).ToListAsync();
      if (!matriculascursos.Any()) return NotFound("Seu curso não possui matriculas");
      var alunos = await context.alunos.Where(a => matriculascursos.Contains(a.Id_aluno)).ToListAsync();
      return Ok(alunos);
    }
    [HttpDelete("matriculas/instrutor/{cursoid}/{alunoid}")]
    public async Task<ActionResult<Matricula>> DeleteMatricula(int alunoid, int cursoid, int instrutorid)
    {
      var cursosDoInstrutor = await context.cursos.Where(cursos => cursos.InstrutorId == instrutorid).Select(curso => curso.Id_curso).ToListAsync();
      var matriculaaluno = await context.matriculas.Where(m => m.AlunoId == alunoid && cursosDoInstrutor.Contains(m.CursoId)).ToListAsync();
      if (matriculaaluno == null) return NotFound("Matrícula não existe.");
      context.Remove(matriculaaluno);
      await context.SaveChangesAsync();

      return Ok(await context.matriculas.Where(m => cursosDoInstrutor.Contains(m.CursoId)).ToListAsync());

    }
  }
}
