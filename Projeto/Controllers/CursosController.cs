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
      var existingCurso = await context.cursos.FindAsync(modifycurso.Id_curso);

      if (existingCurso == null) return NotFound("Não encontrado");
      try
      {
        existingCurso.Name = modifycurso.Name;
        existingCurso.Preco = modifycurso.Preco;
        existingCurso.Data_criacao = modifycurso.Data_criacao;
        existingCurso.Disponivel = modifycurso.Disponivel;

        context.Update(existingCurso);
        await context.SaveChangesAsync();

        return Ok(existingCurso);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Erro no servidor: {ex.Message}");
      }
    }

    [HttpDelete("instrutor/{id}/deletar")]
    public async Task<ActionResult<Cursos>> DeleteCurso(int id)
    {
      var curso = await context.cursos.FindAsync(id);
      if (curso == null) return BadRequest("Curso não encontrado ou não existe.");

      var matriculasDoCurso = context.matriculas.Where(m => m.CursoId == id);
      if (matriculasDoCurso != null) context.matriculas.RemoveRange(matriculasDoCurso);

      context.cursos.Remove(curso);
      await context.SaveChangesAsync();
      return Ok(await context.cursos.ToListAsync());
    }
  }
}
