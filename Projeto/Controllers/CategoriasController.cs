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

    [HttpGet("Categorias/{categoriaid}/Cursos")]//pra pegar os cursos de uma categoria
    public async Task<ActionResult<List<CursoCategoria>>> GetCursosdaCategoria(int categoriaid)
    {
     var categoria = await context.categorias.FindAsync(categoriaid);
     if(categoria == null) return NotFound("Categoria não existe");

     var iddoscursos = await context.CursoCategorias.Where(cc=> cc.CategoriaId == categoriaid).Select(cc => cc.CursoId).ToListAsync();

     if (iddoscursos == null || iddoscursos.Count == 0) return NotFound("Não há cursos nessa categoria");

     var cursos = await context.cursos.Where(cursos => iddoscursos.Contains(cursos.Id_curso)).ToListAsync();

      return Ok(cursos);
    }

  }
}
