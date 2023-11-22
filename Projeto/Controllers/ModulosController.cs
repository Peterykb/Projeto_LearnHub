using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulosController : ControllerBase
    {
      public Context context;
      public ModulosController(Context _context){
        context = _context;
      }
      [HttpGet("modulos")]
      public async Task <ActionResult<List<Modulos>>> GetModulos(){
        return Ok(await context.modulos.ToListAsync());
      }
      [HttpPost("modulos/{id}")]
      public async Task <ActionResult<Modulos>> PostModulo(int id){
      var modulo = await context.modulos.FindAsync(id);
      if(modulo == null) return BadRequest("Modulo não encontrado.");

      context.modulos.Remove(modulo);
      await context.SaveChangesAsync();

      return Ok(await context.modulos.ToListAsync());
      }

    }
}
