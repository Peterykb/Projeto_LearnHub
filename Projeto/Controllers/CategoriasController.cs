using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult<List<Categorias>>> GetCategorias()
        {
            var categorias = await context.categorias.ToListAsync();

            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<Categorias>> GetCategoria(int id){
            var categoria = await context.categorias.FindAsync(id);
            if(categoria == null) return BadRequest("Categoria não encontrada");

            return Ok(categoria);
        }
        [HttpPost]
        public async Task<ActionResult<Categorias>> CreateCategoria(Categorias categoria)
        {
            if (categoria == null)
            {
                return BadRequest("Valor nulo");
            }

            context.categorias.Add(categoria);
            await context.SaveChangesAsync();

            return CreatedAtAction("BuscarCategorias", new { id = categoria.Id_categoria }, categoria);
        }
        [HttpPut("{id}")]
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