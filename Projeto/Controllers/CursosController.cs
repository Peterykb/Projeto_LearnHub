using System.ComponentModel.DataAnnotations;
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

    [HttpGet("{nomeCurso}")]
    public async Task<ActionResult<Cursos>> GetCurso(string nomeCurso)
    {
      var cursos = await context.cursos.Where(c => c.Name.Contains(nomeCurso)).ToListAsync();
      if (cursos == null || cursos.Count == 0) return NotFound("Não foi encontrado nenhum curso.");

      return Ok(cursos);
    }

    [HttpGet("instrutor/{id}")]
    public async Task<ActionResult<IEnumerable<Cursos>>> GetCursoInstrutor(int id)
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
     }).ToList();
      if (cursosDoInstrutor == null) return NotFound("Não foi encontrado");
      return Ok(cursosDoInstrutor);
    }

    [HttpGet("aluno/{id}")]
    public async Task<ActionResult<List<Cursos>>> GetAlunoCursos(int id)
    {

      var matriculas = await context.matriculas.Where(m => m.AlunoId == id).ToListAsync();

      if (matriculas == null || !matriculas.Any())
      {
        return NotFound("Não foram encontradas matrículas para o aluno.");
      }

      var iddoscursos = matriculas.Select(m => m.CursoId).ToList();
      var cursosdoaluno = await context.cursos.Where(c => iddoscursos.Contains(c.Id_curso)).ToListAsync();

      if (cursosdoaluno == null || cursosdoaluno.Count == 0)
      {
        return NotFound("Não foram encontrados cursos para o aluno.");
      }
      return Ok(cursosdoaluno);
    }

    [HttpPost("instrutor/criar")]
    public async Task<ActionResult<Cursos>> CreateCurso(Cursos novocurso, int instrutorid)
    {
      if (novocurso == null) return BadRequest("Dados vazios");
      var cursoexiste = await context.cursos.FirstOrDefaultAsync(c => c.Name == novocurso.Name && c.InstrutorId == instrutorid);
      if (cursoexiste != null) return BadRequest("O curso já existe");
      context.cursos.Add(novocurso);
      novocurso.InstrutorId = instrutorid;
      await context.SaveChangesAsync();

      return Ok(novocurso);
    }

    [HttpPut("instrutor/{id}/atualizar")]
    public async Task<ActionResult<Cursos>> PutCurso(Cursos modifycurso, int id)
    {
      if (modifycurso == null) return BadRequest("O curso está nulo");
      var cursoexiste = await context.cursos.FirstOrDefaultAsync(c => c.Id_curso == modifycurso.Id_curso && c.InstrutorId == id);

      if (cursoexiste == null) return NotFound("Não encontrado");

      try
      {

        cursoexiste.Name = modifycurso.Name;
        cursoexiste.Preco = modifycurso.Preco;
        cursoexiste.Data_criacao = modifycurso.Data_criacao;
        cursoexiste.Disponivel = modifycurso.Disponivel;

        context.Update(cursoexiste);
        await context.SaveChangesAsync();

        return Ok(cursoexiste);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Erro no servidor: {ex.Message}");
      }
    }

    [HttpDelete("{idinstrutor}/{idcurso}/deletar")]
    public async Task<ActionResult<Cursos>> DeleteCurso(int idcurso, int idinstrutor)
    {
      var curso = await context.cursos.FirstOrDefaultAsync(c => c.Id_curso == idcurso && c.InstrutorId == idinstrutor);
      if (curso == null) return BadRequest("Curso não encontrado.");

      var matriculasDoCurso = context.matriculas.Where(m => m.CursoId == idcurso);
      if (matriculasDoCurso != null) context.matriculas.RemoveRange(matriculasDoCurso);

      var modulosdocurso = await context.modulos.Where(m => m.CursoId == idcurso).ToListAsync();
      if (modulosdocurso != null)
      {
        foreach (var modulo in modulosdocurso)
        {
          var aulasDoModulo = context.aulas.Where(a => a.Moduloid == modulo.Id_Modulo);
          if (aulasDoModulo != null)
            context.aulas.RemoveRange(aulasDoModulo);
        }
        context.modulos.RemoveRange(modulosdocurso);
      }
      context.cursos.Remove(curso);
      await context.SaveChangesAsync();

      return Ok(await context.cursos.ToListAsync());
    }
  }
}
