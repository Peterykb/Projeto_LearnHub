using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarrinhoController : ControllerBase
  {
    public readonly Context context;
    public CarrinhoController(Context _context)
    {
      context = _context;
    }
    [HttpGet("cursos")]
    public async Task<ActionResult<Carrinho>> GetCursosCarrinho(int alunoid)
    {
      var aluno = await context.estudante.FindAsync(alunoid);
      if (aluno == null) return BadRequest("Aluno não encontrado.");

      var carrinho = await context.carrinhos.Where(carrinho => carrinho.AlunoId == alunoid).Select(carrinho => carrinho.CursoId).ToListAsync();
      if (!carrinho.Any()) return Ok("Não há nada no carrinho.");

      var cursos = await context.cursos.Where(cursos => carrinho.Contains(cursos.Id_curso)).ToListAsync();
      return Ok(cursos);
    }
    [HttpPost("adicionar")]
    public async Task<ActionResult<Carrinho>> PostCursoCarrinho(int alunoid, int cursoid)
    {
      var aluno = await context.estudante.FindAsync(alunoid);
      if (aluno == null)
      {
        return BadRequest("Aluno não encontrado.");
      }

      var curso = await context.cursos.FindAsync(cursoid);
      if (curso == null)
      {
        return BadRequest("Curso não encontrado.");
      }

      var carrinhoExistente = await context.carrinhos
          .Where(c => c.AlunoId == alunoid && c.CursoId == cursoid)
          .FirstOrDefaultAsync();

      if (carrinhoExistente != null)
      {
        return BadRequest("Este curso já está no carrinho.");
      }

      var novoCarrinhoItem = new Carrinho
      {
        AlunoId = alunoid,
        CursoId = cursoid
      };

      context.carrinhos.Add(novoCarrinhoItem);
      await context.SaveChangesAsync();

      return Ok(novoCarrinhoItem);
    }

  }
}
