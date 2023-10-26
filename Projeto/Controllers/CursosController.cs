using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/cursos")]
    public class CursosController : ControllerBase
    {
        private readonly Context _context;

        public CursosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cursos>>> GetCursos()
        {
            var cursos = await _context.cursos.ToListAsync();
            return Ok(cursos);
        }

        [HttpPost]
        public async Task<ActionResult<Cursos>> CriarCurso(Cursos curso)
        {
            if (curso == null)
                return BadRequest("Valor nulo");

            _context.cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id_curso }, curso);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cursos>> GetCurso(int id)
        {
            var curso = await _context.cursos.FindAsync(id);

            if (curso == null)
                return NotFound();

            return Ok(curso);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cursos>> AtualizarCurso(int id, Cursos curso)
        {
            if (id != curso.Id_curso)
            {
                return BadRequest(new { error = "Os IDs não correspondem." });
            }

            _context.Update(curso); // Rastreia a entidade curso

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCurso(int id)
        {
            var curso = await _context.cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            // Primeiro, exclua as aulas relacionadas
            var aulas = _context.aulas.Where(a => a.Id_curso == id);
            _context.aulas.RemoveRange(aulas);

            // Em seguida, exclua o curso
            _context.cursos.Remove(curso);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<List<Cursos>>> DeleteAll()
        {
            var cursos = await _context.cursos.ToListAsync();
            _context.RemoveRange(cursos);
            await _context.SaveChangesAsync();

            return await _context.cursos.ToListAsync();
        }
    }
}

