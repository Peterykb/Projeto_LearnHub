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

    [HttpGet("Categorias")]
    public async Task<ActionResult<List<Categorias>>> GetCategorias()
    {
      return await context.categorias.ToListAsync(); 
    }

    [HttpGet("Categorias/{categoriaid}/Cursos")]
    public async Task<ActionResult<List<CursoCategoria>>> GetCursosdaCategoria(int categoriaid)
    {
      var categoria = await context.categorias.FindAsync(categoriaid);
      if(categoria == null) return NotFound("Categoria não existe");

      var cursosdacategoria = context.CursoCategorias.Where(c => c.CategoriaId == categoriaid).ToList();
      if (cursosdacategoria == null || cursosdacategoria.Count == 0) return NotFound("Não há cursos nessa categoria");

      return Ok(cursosdacategoria);
    }

  }
}
