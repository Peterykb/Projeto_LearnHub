using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Projeto.Models;
using Projeto.Models.Authentication;
using Projeto.Services;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly Context context;

        public CursosController(Context _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cursos>>> GetAllCursos()
        {
            var cursos = await context.cursos.ToListAsync();

            if (!cursos.Any())
            {
                return NotFound("Não foram encontrados cursos.");
            }

            return Ok(cursos);
        }
        [HttpGet("searchbyname/{nomecurso}")]
        public async Task<ActionResult> GetCursoByNome(string nomecurso)
        {
            var curso = await context.cursos.Where(c => c.Name == nomecurso).ToListAsync();

            if (!curso.Any())
            {
                return NotFound($"Nenhum curso com o nome {nomecurso} foi encontrado.");
            }

            return Ok(curso);
        }

        [HttpGet("{cursoid}")]
        [Authorize(Roles = "Aluno, Instrutor")]
        public async Task<ActionResult<Cursos>> GetCursoById(int cursoid)
        {
            var curso = await context.cursos.FindAsync(cursoid);

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
            context.cursos.Add(curso);
            await context.SaveChangesAsync();

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

            context.Entry(curso).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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
            var curso = await context.cursos.FindAsync(cursoid);
            if (curso == null)
            {
                return NotFound($"Curso com o ID {cursoid} não encontrado.");
            }

            context.cursos.Remove(curso);
            await context.SaveChangesAsync();

            return Ok(curso);
        }

        private bool CursoExists(int cursoid)
        {
            return context.cursos.Any(c => c.Id_curso == cursoid);
        }
    }
}
