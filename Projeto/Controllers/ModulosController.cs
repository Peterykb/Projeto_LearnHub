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

    [HttpGet("{cursoid}/modulos")]
    public async Task<ActionResult<List<Modulos>>> GetAllModulos(int cursoid)
    {
        var modulosDoCurso = await _context.modulos.Where(m => m.CursoId == cursoid).ToListAsync();
        return Ok(modulosDoCurso);
    }

    [HttpPost("curso/modulos/{cursoid}/adicionar-modulo")]
    public async Task<ActionResult<Modulos>> PostModulo(Modulos newmodulo, int cursoid)
    {
        var curso = _context.cursos.Find(cursoid);
        if (curso == null)
            return NotFound("Curso não encontrado");

        var moduloExistente = _context.modulos.SingleOrDefault(m => m.Id_Modulo == newmodulo.Id_Modulo);
        if (moduloExistente != null)
            return BadRequest("Módulo já existe.");

        newmodulo.CursoId = cursoid;
        curso.Modulos ??= new List<Modulos>();
        curso.Modulos.Add(newmodulo);

        await _context.SaveChangesAsync();

        return Ok(await _context.modulos.ToListAsync());
    }

    [HttpPut("curso/modulos/{cursoid}/modificar-modulo/{moduloid}")]
    public async Task<ActionResult<Modulos>> PutModulos(int cursoid, int moduloid, Modulos modifymodulo)
    {
        var cursoExistente = await _context.cursos.FindAsync(cursoid);
        if (cursoExistente == null)
            return NotFound("Curso não encontrado");

        var moduloExistente = _context.modulos.FirstOrDefault(m => m.Id_Modulo == moduloid && m.CursoId == cursoid);
        if (moduloExistente == null)
            return NotFound("Módulo não encontrado");

        moduloExistente.Titulo = modifymodulo.Titulo;
        moduloExistente.Descricao = modifymodulo.Descricao;

        await _context.SaveChangesAsync();

        return Ok(moduloExistente);
    }

    [HttpDelete("curso/modulos/{cursoid}/deletar-modulo/{moduloid}")]
    public async Task<ActionResult<List<Modulos>>> DeleteModulos(int cursoid, int moduloid)
    {
        var cursoExistente = await _context.cursos.FindAsync(cursoid);
        if (cursoExistente == null)
            return NotFound("Curso não encontrado");

        var moduloExistente = _context.modulos.FirstOrDefault(m => m.Id_Modulo == moduloid && m.CursoId == cursoid);
        if (moduloExistente == null)
            return NotFound("Módulo não encontrado");

        var aulas = _context.aulas.Where(a => a.Moduloid == moduloid);
        if (aulas != null)
            _context.RemoveRange(aulas);

        _context.Remove(moduloExistente);
        await _context.SaveChangesAsync();

        return Ok(await _context.modulos.Where(m => m.CursoId == cursoid).ToListAsync());
    }
}

}
