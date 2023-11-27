using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Projeto.Models
{
  public class Aulas
  {
    [Key]
    public int Id_aulas { get; set; }
    public string Titulo { get; set; } = String.Empty;
    public string url { get; set; } = String.Empty;
    public Modulos? Modulo { get; set; }
    public int Moduloid { get; set; }

  }
}
