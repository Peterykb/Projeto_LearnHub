using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
  public class Carrinho
  {

    public int AlunoId { get; set; }
    public AlunoInformacoes? Aluno { get; set; }
    public int CursoId { get; set; }
    public Cursos? Curso { get; set; }

  }

}

