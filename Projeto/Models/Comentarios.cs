using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
  public class Comentarios
  {
    [Key]
    public int Id_comentarios { get; set; }
    public string Titulo { get; set; } = String.Empty;
    public string Texto { get; set; } = String.Empty;
    [DataType(DataType.Date)]
    public int data_public { get; set; }

    //Configuração do relacionamento da entidade curso com os comentários
    public Cursos? Curso {get;set;}
    public int CursoId {get;set;}
    //Configuração do relacionamento da entidade aluno com os comentários
    public AlunoInformacoes? aluno {get;set;}
    public int AlunoId {get;set;}

  }
}
