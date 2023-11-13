using System.ComponentModel.DataAnnotations;


namespace Projeto.Models
{
  public class InstrutorInformacoes
  {
    [Key]
    public Guid Id_Instrutor { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }


  }
}
