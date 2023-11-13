using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
  public class AlunoInformacoes
  {
    [Key]
    public int Id_aluno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    // Definição da chave estrangeira
    public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
  }

}
