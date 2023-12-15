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

    [HttpGet("alunos")]
    public async Task<ActionResult<Matricula>> GetAllMatriculas(int alunoid)
    {
      var idcurso = context.matriculas.Where(m => m.AlunoId == alunoid).Select(m => m.CursoId);
      if (idcurso == null) return NotFound("Você não tem matrículas ainda.");
      var cursosdoaluno = await context.cursos.Where(c => idcurso.Contains(c.Id_curso)).ToListAsync();
      return Ok(cursosdoaluno);
    }
    [HttpGet("{nomecurso}")]
    public async Task<ActionResult<List<AlunoInformacoes>>> GetAllMatriculasCursoInstrutor(int instrutorid, string nomecurso)
    {
      var cursosInstrutor = await context.cursos
          .Where(c => c.InstrutorId == instrutorid && c.Name == nomecurso)
          .ToListAsync();

      if (!cursosInstrutor.Any())
      {
        return NotFound($"Não foram encontrados cursos para o instrutor {instrutorid} com o nome '{nomecurso}'.");
      }

      var idCursosInstrutor = cursosInstrutor.Select(c => c.Id_curso).ToList();

      var matriculasAlunos = await context.matriculas
          .Where(m => idCursosInstrutor.Contains(m.CursoId))
          .Select(m => m.AlunoId)
          .ToListAsync();

      if (!matriculasAlunos.Any())
      {
        return NotFound("Seu curso não possui matrículas.");
      }

      var alunos = await context.estudante.Where(a => matriculasAlunos.Contains(a.Id_aluno))
          .Select(info => new AlunoInformacoes
          {
            Nome = info.Nome,
            DataNascimento = info.DataNascimento
          })
          .ToListAsync();

      return Ok(alunos);
    }

    [HttpPost("{cursoid}/{alunoid}")]
    public async Task<ActionResult<Matricula>> ComprarCurso(int cursoid, int alunoid, Matricula matricula)
    {
      var aluno = await context.estudante.FindAsync(alunoid);
      if (aluno == null) return BadRequest("Aluno não encontrado.");
      var cursos = await context.cursos.FindAsync(cursoid);
      if (cursos == null) return BadRequest("Curso não encontrado.");

      matricula.AlunoId = alunoid;
      matricula.CursoId = cursoid;
      context.matriculas.Add(matricula);
      try
      {
        await context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        return BadRequest($"Não foi possível realizar a compra. {ex}");
      }
      return Ok("Compra realizada com sucesso.");
    }

  }
}

