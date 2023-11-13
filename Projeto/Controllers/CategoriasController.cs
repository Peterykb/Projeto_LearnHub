// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Projeto.Models;

// namespace Projeto.Controllers
// {
//   [ApiController]
//   [Route("api/[controller]")]
//   public class CategoriasController : ControllerBase
//   {
//     private readonly Context _context;

//     public CategoriasController(Context context)
//     {
//       _context = context;
//     }

//     [HttpGet]
//     [Authorize]
//     public async Task<ActionResult<List<Categorias>>> GetCategorias()
//     {
//       var categorias = await _context.categorias.ToListAsync();
//       return Ok(categorias);
//     }

//     [HttpGet("{id}")]
//     [Authorize]
//     public async Task<ActionResult<Categorias>> GetCategoria(int id)
//     {
//       var categoria = await _context.categorias.FindAsync(id);
//       if (categoria == null)
//         return NotFound("Categoria não encontrada");

//       return Ok(categoria);
//     }

//     [HttpPost]
//     [Authorize]
//     public async Task<ActionResult<Categorias>> CreateCategoria(Categorias categoria)
//     {
//       if (categoria == null)
//         return BadRequest("Categoria não pode ser nula");

//       var existecategoria = await _context.categorias.FirstOrDefaultAsync(c => c.Name == categoria.Name);
//       if (existecategoria != null)
//         return BadRequest("Categoria já existe");

//       _context.categorias.Add(categoria);
//       await _context.SaveChangesAsync();

//       return Ok(categoria);
//     }

//     [HttpPut("{id}")]
//     [Authorize]
//     public async Task<ActionResult<Categorias>> ChangeCategoria(int id, Categorias categoria)
//     {
//       if (id != categoria.Id_categoria)
//         return BadRequest("Id da categoria não corresponde");

//       _context.Entry(categoria).State = EntityState.Modified;

//       try
//       {
//         await _context.SaveChangesAsync();
//       }
//       catch (DbUpdateConcurrencyException)
//       {
//         throw;
//       }
//       return NoContent();
//     }

//     // [HttpDelete("{id}")]
//     // [Authorize]
//     // public async Task<ActionResult<Categorias>> DeleteCategoria(int id)
//     // {
//     //   var categoria = await _context.categorias.FindAsync(id);
//     //   if (categoria == null)
//     //     return NotFound();

//     //   var cursosDaCategoria = await _context.cursos.Where(c => c. == id).ToListAsync();

//     //   if (cursosDaCategoria.Any())
//     //   {
//     //     _context.cursos.RemoveRange(cursosDaCategoria);
//     //   }

//     //   _context.categorias.Remove(categoria);

//     //   try
//     //   {
//     //     await _context.SaveChangesAsync();
//     //   }
//     //   catch (DbUpdateConcurrencyException)
//     //   {
//     //     throw;
//     //   }
//     //   return NoContent();
//     // }
// [HttpDelete("{id}")]
// [Authorize]
// public async Task<ActionResult<Categorias>> DeleteCategoria(int id)
// {
//     var categoria = await _context.categorias.FindAsync(id);
//     if (categoria == null)
//         return NotFound();

//     var cursoCategorias = await _context.CursoCategorias
//         .Where(cc => cc.CategoriaId == id)
//         .Include(cc => cc.Cursos) // Incluímos os cursos relacionados
//         .ToListAsync();

//     foreach (var cursoCategoria in cursoCategorias)
//     {
//         _context.CursoCategorias.Remove(cursoCategoria);
//     }

//     _context.categorias.Remove(categoria);

//     try
//     {
//         await _context.SaveChangesAsync();
//     }
//     catch (DbUpdateConcurrencyException)
//     {
//         throw;
//     }
//     return NoContent();
// }



//   }
// }
