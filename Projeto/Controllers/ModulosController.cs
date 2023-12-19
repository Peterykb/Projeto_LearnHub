using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ModulosController : ControllerBase
  {
    private readonly Context _context;

        public ModulosController(Context context)
        {
            _context = context;
        }

        [HttpGet("cursos/{cursoid}")]
        [Authorize(Roles = "Aluno, Instrutor")]
        public async Task<ActionResult<List<Modulos>>> GetModulosByCurso(int cursoid)
        {
            var modulos = await _context.modulos
                .Where(m => m.CursoId == cursoid)
                .ToListAsync();

            if (!modulos.Any())
            {
                return NotFound($"Não foram encontrados módulos para o curso com o ID {cursoid}.");
            }

            return Ok(modulos);
        }

        [HttpGet("{moduloid}")]
        [Authorize(Roles = "Aluno, Instrutor")]
        public async Task<ActionResult<Modulos>> GetModuloById(int moduloid)
        {
            var modulo = await _context.modulos.FindAsync(moduloid);

            if (modulo == null)
            {
                return NotFound($"Módulo com o ID {moduloid} não encontrado.");
            }

            return Ok(modulo);
        }

        [HttpPost("cursos/{cursoid}")]
        [Authorize(Roles = "Instrutor")]
        public async Task<ActionResult<Modulos>> AddModuloToCurso(int cursoid, Modulos modulo)
        {
            var curso = await _context.cursos.FindAsync(cursoid);
            if (curso == null)
            {
                return BadRequest("Curso não encontrado.");
            }

            modulo.CursoId = cursoid;

            _context.modulos.Add(modulo);
            await _context.SaveChangesAsync();

            return Ok(modulo);
        }

        [HttpPut("{moduloid}")]
        [Authorize(Roles = "Instrutor")]
        public async Task<ActionResult<Modulos>> UpdateModulo(int moduloid, Modulos modulo)
        {
            if (moduloid != modulo.Id_Modulo)
            {
                return BadRequest("IDs de módulo não coincidem.");
            }

            _context.Entry(modulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(moduloid))
                {
                    return NotFound($"Módulo com o ID {moduloid} não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(modulo);
        }

        [HttpDelete("{moduloid}")]
        [Authorize(Roles = "Instrutor")]
        public async Task<ActionResult<Modulos>> DeleteModulo(int moduloid)
        {
            var modulo = await _context.modulos.FindAsync(moduloid);
            if (modulo == null)
            {
                return NotFound($"Módulo com o ID {moduloid} não encontrado.");
            }

            _context.modulos.Remove(modulo);
            await _context.SaveChangesAsync();

            return Ok(modulo);
        }

        private bool ModuloExists(int moduloid)
        {
            return _context.modulos.Any(m => m.Id_Modulo == moduloid);
        }
    }
}
