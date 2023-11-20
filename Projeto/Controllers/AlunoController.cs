using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    public readonly Context context;

    public AlunoController(Context _context)
    {
      context = _context;
    }

    [HttpGet]
    public async Task <ActionResult<List<Cursos>>> GetCursos(){

      return Ok(await context.cursos.ToListAsync());
    }
    

  }
}
