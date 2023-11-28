using Microsoft.AspNetCore.Identity;
using Projeto.Models;
using System.Threading.Tasks;

public class UsuarioService
{
  private readonly UserManager<AlunoInformacoes> _userManagerAluno;
  private readonly UserManager<InstrutorInformacoes> _userManagerInstrutor;

  public UsuarioService(UserManager<AlunoInformacoes> userManagerAluno, UserManager<InstrutorInformacoes> userManagerInstrutor)
  {
    _userManagerAluno = userManagerAluno;
    _userManagerInstrutor = userManagerInstrutor;
  }

  public async Task<IdentityResult> CadastrarAlunoAsync(AlunoInformacoes aluno)
  {
    return await _userManagerAluno.CreateAsync(aluno, "SenhaPadrao"); // Defina a senha conforme necessário
  }

  public async Task<IdentityResult> CadastrarInstrutorAsync(InstrutorInformacoes instrutor)
  {
    return await _userManagerInstrutor.CreateAsync(instrutor, "SenhaPadrao"); // Defina a senha conforme necessário
  }
}
