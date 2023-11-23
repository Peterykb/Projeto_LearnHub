using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
  public class AlunoInformacoes
  {
    [Key]
    public int Id_aluno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    public int DataNascimento { get; set; }

    //Configuração do relacionamento da entidade AlunoInformacoes com as matriculas
    [JsonIgnore]
    public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
    //Configuração do relacionamento da entidade AlunoInformacoes com os comentarios
    [JsonIgnore]
    public ICollection<Comentarios>? comentarios { get; set; } = new List<Comentarios>();

  }

}
