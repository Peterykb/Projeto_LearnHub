using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        public readonly Context context;
        public CategoriasController(Context Context)
        {
            context = Context;
        }
        [HttpGet]
        [Authorize]

        public async Task<ActionResult<List<Categorias>>> GetCategorias()
        {
            var categorias = await context.categorias.ToListAsync();

            return Ok(categorias);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task <ActionResult<Categorias>> GetCategoria(int id){
            var categoria = await context.categorias.FindAsync(id);
            if(categoria == null) return BadRequest("Categoria não encontrada");

            return Ok(categoria);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Categorias>> CreateCategoria(Categorias categoria)
        {
          var existecategoria = await context.categorias.FirstOrDefaultAsync(c => c.Name == categoria.Name);
            if (categoria == null)
            {
                return BadRequest("Valor nulo");
            }
            if(existecategoria != null) return BadRequest("Categoria já existe");


            context.categorias.Add(categoria);
            await context.SaveChangesAsync();

            return Ok(categoria);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task <ActionResult<Categorias>> ChangeCategoria(Categorias categoria, int id){
         if(id != categoria.Id_categoria) return BadRequest("Categoria não existe");
         context.Update(categoria);

         try{
            await context.SaveChangesAsync();
         }
         catch(DbUpdateConcurrencyException){
             throw;
         }
         return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task <ActionResult<Categorias>> DeleteCategoria(int id){
            var categoria = await context.categorias.FindAsync(id);
            if(categoria == null) return NotFound();

            var cursos = context.cursos.Where(c => c.Id_categoria == id);
            context.RemoveRange(cursos);

            context.Remove(categoria);
            try{
                await context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                throw;
            }
            return NoContent();
        }

    }
}
