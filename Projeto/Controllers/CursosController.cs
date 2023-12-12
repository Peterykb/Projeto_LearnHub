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

    [HttpGet] // pra todo mundo
    public async Task<ActionResult<List<Cursos>>> GetAllCursos()
    {
      var cursos = await context.cursos.Join(
        context.instrutors,
        c => c.InstrutorId,
        i => i.Id_Instrutor,
        (c, i) => new CursoInstrutorModel
        {
          Curso = c,
          Instrutor = i.Nome
        }
      ).ToListAsync();
      return Ok(cursos);
    }
    [HttpGet("pegarporid/{cursoid}")]
    public async Task<ActionResult> PegarPorId(int cursoid)
    {
      var curso = await context.cursos.Where(c => c.Id_curso == cursoid).Join(
        context.instrutors,
        c => c.InstrutorId,
        i => i.Id_Instrutor,
        (c, i) => new CursoInstrutorModel
        {
          Curso = c,
          Instrutor = i.Nome
        }
      ).ToListAsync();
      if(!curso.Any()) return BadRequest("curso não encontrado");

      return Ok(curso);
    }
    [HttpGet("{nomeCurso}")] //pra pesquisa
    public async Task<ActionResult<Cursos>> GetCurso(string nomeCurso)
    {
      var cursos = await context.cursos.Where(c => c.Name.Contains(nomeCurso)).ToListAsync();
      if (cursos == null || cursos.Count == 0) return NotFound("Não foi encontrado nenhum curso.");

      return Ok(cursos);
    }

    [HttpGet("{instrutorid}")] // cursos do instrutor
    public async Task<ActionResult<IEnumerable<Cursos>>> GetCursoInstrutor(int id)
    {
      var cursosDoInstrutor = await context.cursos
     .Where(c => c.InstrutorId == id)
     .Select(c => new
     {
       c.Id_curso,
       c.Name,
       c.Data_criacao,
       c.Disponivel,
       c.Preco
     }).ToListAsync();
      if (!cursosDoInstrutor.Any()) return NotFound("Não foi encontrado");
      return Ok(cursosDoInstrutor);
    }

    [HttpPost("{instrutorid}/criar")] // pro instrutor criar um curso
    public async Task<ActionResult<Cursos>> CreateCurso([FromBody] Cursos novocurso, int instrutorid, int categoriaId)
    {
      if (novocurso == null)
      {
        return BadRequest("Dados vazios");
      }

      var cursoExistente = await context.cursos
          .FirstOrDefaultAsync(c => c.Name == novocurso.Name && c.InstrutorId == instrutorid);

      if (cursoExistente != null)
      {
        return BadRequest("O curso já existe");
      }
      novocurso.InstrutorId = instrutorid;
      context.cursos.Add(novocurso);

      await context.SaveChangesAsync();

      var pegaridcategoria = await context.categorias
          .Where(c => c.Id_categoria == categoriaId)
          .Select(c => c.Id_categoria)
          .FirstOrDefaultAsync();

      if (pegaridcategoria == default)
      {
        return BadRequest("Categoria não encontrada");
      }
      var cursoCategoria = new CursoCategoria
      {
        CursoId = novocurso.Id_curso,
        CategoriaId = pegaridcategoria
      };

      context.CursoCategorias.Add(cursoCategoria);

      await context.SaveChangesAsync();

      return Ok(novocurso);
    }


    [HttpPut("{instrutorid}/atualizar")] //pro instrutor atualizar um curso
    public async Task<ActionResult<Cursos>> PutCurso(int instrutorid, [FromBody] Cursos modifycurso)
    {
      if (modifycurso == null)
      {
        return BadRequest("O curso está nulo");
      }

      var cursoExistente = await context.cursos
          .FirstOrDefaultAsync(c => c.Id_curso == modifycurso.Id_curso && c.InstrutorId == instrutorid);

      if (cursoExistente == null)
      {
        return NotFound("Não encontrado");
      }

      try
      {
        cursoExistente.Name = modifycurso.Name;
        cursoExistente.Preco = modifycurso.Preco;
        cursoExistente.Data_criacao = modifycurso.Data_criacao;
        cursoExistente.Disponivel = modifycurso.Disponivel;

        context.Update(cursoExistente);
        await context.SaveChangesAsync();

        return Ok(cursoExistente);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Erro no servidor: {ex.Message}");
      }
    }

    [HttpDelete("{instrutorid}/{cursoid}/deletar")] //pro instrutor deletar um curso
    public async Task<ActionResult<Cursos>> DeleteCurso(int cursoid, int instrutorid)
    {
      var curso = await context.cursos.FirstOrDefaultAsync(c => c.Id_curso == cursoid && c.InstrutorId == instrutorid);
      if (curso == null) return BadRequest("Curso não encontrado.");

      var matriculasDoCurso = context.matriculas.Where(m => m.CursoId == cursoid);
      if (matriculasDoCurso != null) context.matriculas.RemoveRange(matriculasDoCurso);

      var modulosdocurso = await context.modulos.Where(m => m.CursoId == cursoid).ToListAsync();
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
  public class CursoInstrutorModel
  {
    public Cursos? Curso { get; set; }
    public string? Instrutor { get; set; } // Nome do instrutor
  }
}
