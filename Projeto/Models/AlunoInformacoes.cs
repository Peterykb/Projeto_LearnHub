using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Projeto.Models
{
  public class AlunoInformacoes 
  {
    [Key]
    public int Id_aluno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email {get;set;} = string.Empty;
    public string CPF { get; set; } = string.Empty;
     [JsonConverter(typeof(DataFormat))]
    public DateTime DataNascimento { get; set; }
    [JsonIgnore]
    public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
    [JsonIgnore]
     public List<Carrinho>? Carrinhos { get; set; }
  }
}
