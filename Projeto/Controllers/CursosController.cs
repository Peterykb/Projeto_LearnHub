using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;
using Projeto.Models.Authentication;
using Projeto.Services;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CursosController : ControllerBase
  {
     private readonly Context _context;

        public CursosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Aluno, Instrutor")]
        public async Task<ActionResult<List<Cursos>>> GetAllCursos()
        {
            var cursos = await _context.cursos.ToListAsync();

            if (!cursos.Any())
            {
                return NotFound("Não foram encontrados cursos.");
            }

            return Ok(cursos);
        }

        [HttpGet("{cursoid}")]
        [Authorize(Roles = "Aluno, Instrutor")]
        public async Task<ActionResult<Cursos>> GetCursoById(int cursoid)
        {
            var curso = await _context.cursos.FindAsync(cursoid);

            if (curso == null)
            {
                return NotFound($"Curso com o ID {cursoid} não encontrado.");
            }

            return Ok(curso);
        }

        [HttpPost]
        [Authorize(Roles = "Instrutor")]
        public async Task<ActionResult<Cursos>> AddCurso(Cursos curso)
        {
            _context.cursos.Add(curso);
            await _context.SaveChangesAsync();

            return Ok(curso);
        }

        [HttpPut("{cursoid}")]
        [Authorize(Roles = "Instrutor")]
        public async Task<ActionResult<Cursos>> UpdateCurso(int cursoid, Cursos curso)
        {
            if (cursoid != curso.Id_curso)
            {
                return BadRequest("IDs de curso não coincidem.");
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(cursoid))
                {
                    return NotFound($"Curso com o ID {cursoid} não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(curso);
        }

        [HttpDelete("{cursoid}")]
        [Authorize(Roles = "Instrutor")]
        public async Task<ActionResult<Cursos>> DeleteCurso(int cursoid)
        {
            var curso = await _context.cursos.FindAsync(cursoid);
            if (curso == null)
            {
                return NotFound($"Curso com o ID {cursoid} não encontrado.");
            }

            _context.cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return Ok(curso);
        }

        private bool CursoExists(int cursoid)
        {
            return _context.cursos.Any(c => c.Id_curso == cursoid);
        }
    }
}
