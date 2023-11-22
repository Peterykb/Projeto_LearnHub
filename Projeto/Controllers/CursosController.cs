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
    public async Task<ActionResult<Cursos>> GetCurso(int id)
    {
      var curso = await context.cursos.FindAsync(id);
      if (curso == null) return NotFound("Curso não encontrado");
      return Ok(curso);
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
       // Adicione mais propriedades do curso conforme necessário
     }).ToList();
      if (cursosDoInstrutor == null) return NotFound("Não foi encontrado");
      return Ok(cursosDoInstrutor);
    }

    [HttpGet("aluno/{id}")]
    public async Task<ActionResult<List<Cursos>>> GetAlunoCursos(int id)
    {
      var cursosdoAluno = context.cursos.Where(c => c.InstrutorId == id).Select(c => new
      {
        c.Name,
        c.Data_criacao,
        c.Disponivel,
        c.Preco
      }).ToList();

      if (cursosdoAluno == null) return NotFound("Não foram encontrados cursos.");

      return Ok(cursosdoAluno);
    }


    [HttpPost("instrutor")]
    public async Task<ActionResult<Cursos>> CreateCurso(Cursos novocurso)
    {
      if (novocurso == null) return BadRequest("Dados vazios");
      var cursoexiste = await context.cursos.FindAsync(novocurso.Id_curso);
      if (cursoexiste != null) return BadRequest("O curso já existe");
      context.cursos.Add(novocurso);
      await context.SaveChangesAsync();

      return Ok(novocurso);
    }

    [HttpPut("instrutor{id}")]
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

    [HttpDelete("{id}")]
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
