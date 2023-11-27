using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
[Route("api/[controller]")]
public class ModulosController : ControllerBase
{
    private readonly Context context;

    public ModulosController(Context _context)
    {
        context = _context;
    }

  [HttpGet("{cursoid}/modulos")]
public async Task<ActionResult<List<Modulos>>> GetAllModulos(int cursoid)
{
    var modulosDoCurso = await context.modulos
        .Where(m => m.CursoId == cursoid)
        .ToListAsync();

    return Ok(modulosDoCurso);
}

[HttpPost("curso/modulos/{cursoid}/adicionar-modulo")]
public async Task<ActionResult<Modulos>> PostModulo(Modulos newModulo, int cursoid)
{
    var curso = await context.cursos.FindAsync(cursoid);
    if (curso == null)
    {
        return NotFound("Curso não encontrado");
    }

    var moduloExistente = await context.modulos
        .FirstOrDefaultAsync(m => m.Id_Modulo == newModulo.Id_Modulo && m.CursoId == cursoid);

    if (moduloExistente != null)
    {
        return BadRequest("Módulo já existe.");
    }

    newModulo.CursoId = cursoid;
    curso.Modulos ??= new List<Modulos>();
    curso.Modulos.Add(newModulo);

    await context.SaveChangesAsync();

    return Ok(await context.modulos.ToListAsync());
}

[HttpPut("curso/modulos/{cursoid}/modificar-modulo/{moduloid}")]
public async Task<ActionResult<Modulos>> PutModulos(int cursoid, int moduloid, Modulos modifyModulo)
{
    var cursoExistente = await context.cursos.FindAsync(cursoid);
    if (cursoExistente == null)
    {
        return NotFound("Curso não encontrado");
    }

    var moduloExistente = await context.modulos
        .FirstOrDefaultAsync(m => m.Id_Modulo == moduloid && m.CursoId == cursoid);

    if (moduloExistente == null)
    {
        return NotFound("Módulo não encontrado");
    }

    moduloExistente.Titulo = modifyModulo.Titulo;
    moduloExistente.Descricao = modifyModulo.Descricao;

    await context.SaveChangesAsync();

    return Ok(moduloExistente);
}

[HttpDelete("instrutor/{nomecurso}/{moduloid}/deletar-modulo")]
public async Task<ActionResult<List<Modulos>>> DeleteModulos(string nomecurso, int moduloid, int instrutorid)
{
    var cursoExistenteId = await context.cursos
        .Where(curso => curso.Name == nomecurso && curso.InstrutorId == instrutorid)
        .Select(curso => curso.Id_curso)
        .ToListAsync();

    if (!cursoExistenteId.Any())
    {
        return NotFound("Curso não encontrado");
    }

    var moduloExistente = await context.modulos
        .FirstOrDefaultAsync(m => m.Id_Modulo == moduloid && cursoExistenteId.Contains(m.CursoId));

    if (moduloExistente == null)
    {
        return NotFound("Módulo não encontrado");
    }

    var aulas = context.aulas.Where(a => a.Moduloid == moduloid);
    if (aulas.Any())
    {
        context.RemoveRange(aulas);
    }

    context.Remove(moduloExistente);
    await context.SaveChangesAsync();

    return Ok(await context.modulos.Where(m => cursoExistenteId.Contains(m.CursoId)).ToListAsync());
}

}

}
