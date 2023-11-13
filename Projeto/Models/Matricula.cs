
namespace Projeto.Models
{
  public class Matricula
{
    public int AlunoId { get; set; }
    public AlunoInformacoes? Aluno { get; set; }

    public int CursoId { get; set; }
    public Cursos? Curso { get; set; }
}

}
