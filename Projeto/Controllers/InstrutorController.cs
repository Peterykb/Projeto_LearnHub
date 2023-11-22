using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class InstrutorController : ControllerBase
  {
    public readonly Context context;

    public InstrutorController(Context _context)
    {
      context = _context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Cursos>>> GetAllCursos()
    {
      return Ok(await context.cursos.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Cursos>> GetCursoById(int id){
      return Ok();
    }

  }
}
