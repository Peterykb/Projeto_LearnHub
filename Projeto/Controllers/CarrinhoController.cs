using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Projeto.Models.Authentication;

namespace Projeto.Controllers
{
    [Authorize(Roles = "Aluno")]
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<UserIdentity> _userManager;

        public CarrinhoController(Context context, UserManager<UserIdentity> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("cursos")]
        public async Task<ActionResult<Carrinho>> GetCursosCarrinho()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            var userEmail = user.Email;

            var aluno = await _context.estudante.FirstOrDefaultAsync(e => e.Email == userEmail);
            if (aluno == null) return BadRequest("Aluno não encontrado.");

            var carrinho = await _context.carrinhos
                .Where(c => c.AlunoId == aluno.Id_aluno)
                .Select(c => c.CursoId)
                .ToListAsync();

            if (!carrinho.Any()) return Ok("Não há nada no carrinho.");

            var cursos = await _context.cursos
                .Where(c => carrinho.Contains(c.Id_curso))
                .ToListAsync();

            return Ok(cursos);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<Carrinho>> PostCursoCarrinho(int cursoid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            var userEmail = user.Email;

            var aluno = await _context.estudante.FirstOrDefaultAsync(e => e.Email == userEmail);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            var curso = await _context.cursos.FindAsync(cursoid);
            if (curso == null)
            {
                return BadRequest("Curso não encontrado.");
            }

            var carrinhoExistente = await _context.carrinhos
                .Where(c => c.AlunoId == aluno.Id_aluno && c.CursoId == cursoid)
                .FirstOrDefaultAsync();

            if (carrinhoExistente != null)
            {
                return BadRequest("Este curso já está no carrinho.");
            }

            var novoCarrinhoItem = new Carrinho
            {
                AlunoId = aluno.Id_aluno,
                CursoId = cursoid
            };

            _context.carrinhos.Add(novoCarrinhoItem);
            await _context.SaveChangesAsync();

            return Ok(novoCarrinhoItem);
        }
    }
}
