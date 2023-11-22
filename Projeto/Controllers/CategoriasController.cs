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

        public CategoriasController(Context _context){
          context = _context;
        }

        [HttpGet("Categorias")]
        public async Task <ActionResult<List<Categorias>>> GetCategorias(){
          return await context.categorias.ToListAsync();
        }
    }
}
