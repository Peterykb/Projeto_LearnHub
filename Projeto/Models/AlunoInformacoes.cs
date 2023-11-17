using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
  public class AlunoInformacoes
  {
    [Key]
    public int Id_aluno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    public DateTime? DataNascimento { get; set; }

    //Configuração do relacionamento da entidade AlunoInformacoes com as matriculas
    public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
    //Configuração do relacionamento da entidade AlunoInformacoes com os comentarios
    public ICollection<Comentarios>? comentarios {get;set;} = new List<Comentarios>();
    
  }

}
