using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CategoriasController : ControllerBase
  {
    public Context context;

    public CategoriasController(Context _context)
    {
      context = _context;
    }

    [HttpGet("Categorias")]//pegar todas as categorias
    public async Task<ActionResult<List<Categorias>>> GetCategorias()
    {
      return await context.categorias.ToListAsync();
    }

    [HttpGet("Categorias/{categoriaid}")]
    public async Task<ActionResult<List<CursoInstrutorModel>>> GetCursosdaCategoria(int categoriaid)
    {
      var categoria = await context.categorias.FindAsync(categoriaid);
      if (categoria == null) return NotFound("Categoria não existe");

      var cursosInstrutores = await context.CursoCategorias
          .Where(cc => cc.CategoriaId == categoriaid)
          .Join(
              context.cursos,
              cc => cc.CursoId,
              c => c.Id_curso,
              (cc, c) => new CursoInstrutorModel
              {
                Curso = c,
                Instrutor = context.instrutors
                      .Where(i => i.Id_Instrutor == c.InstrutorId)
                      .Select(i => i.Nome)
                      .FirstOrDefault()
              }
          )
          .ToListAsync();

      return cursosInstrutores;
    }

    public class CursoInstrutorModel
    {
      public Cursos Curso { get; set; }
      public string Instrutor { get; set; } // Nome do instrutor
    }
  }
}
