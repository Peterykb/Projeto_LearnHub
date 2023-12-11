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
    public class CadastrarController : ControllerBase
    {
        public readonly Context context;
        public CadastrarController(Context _context)
        {
            context = _context;
        }
        [HttpPost("aluno")]
        public async Task<ActionResult<AlunoInformacoes>> CadastroAluno(AlunoInformacoes newaluno, string senha)
        {
            var email = newaluno.Email;
            var existealuno = await context.alunos.Where(a => a.Email == email).ToListAsync();
            if (existealuno.Any()) return BadRequest("Email já cadastrado");
            // var usuario = new AuthUsuario{
            //     id = newaluno.Id_aluno,
            //     senhacriptografada = 
            // }
            context.alunos.Add(newaluno);
            context.SaveChanges();
            
            await context.SaveChangesAsync();
            return Ok(newaluno);
        }
        [HttpPost("instrutor")]
        public async Task<ActionResult<InstrutorInformacoes>> CadastroInstrutor(InstrutorInformacoes newinstrutor, string senha)
        {
            var email = newinstrutor.Email;
            var existeinstrutor = await context.instrutors.Where(a => a.Email == email).ToListAsync();
            if (existeinstrutor.Any()) return BadRequest("Email já cadastrado");
            context.instrutors.Add(newinstrutor);
            context.SaveChanges();

            await context.SaveChangesAsync();
            return Ok(newinstrutor);
        }

    }

}