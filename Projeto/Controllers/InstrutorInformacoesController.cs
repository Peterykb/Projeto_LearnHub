using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrutorInformacoesController : ControllerBase
    {
        public Context context;

        public InstrutorInformacoesController(Context _context)
        {
            context = _context;
        }
        [HttpGet]
        public async Task<ActionResult<List<InstrutorInformacoes>>> GetInstrutor(){
            return Ok(await context.instrutors.ToListAsync());
        }
        [HttpPost]
        public async Task <ActionResult<InstrutorInformacoes>> PostInstrutor(InstrutorInformacoes newinstrutor){
            var instrutorexiste = await context.instrutors.Where(i => i.Id_Instrutor == newinstrutor.Id_Instrutor).ToListAsync();
            if(instrutorexiste.Any()) return BadRequest("Instrutor já existe");

            context.instrutors.Add(newinstrutor);
            await context.SaveChangesAsync();

            return Ok(newinstrutor); 
        }
    }

}