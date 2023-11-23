using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
  public class Modulos
  {
    [Key]
    public int Id_Modulo { get; set; }
    public string Titulo { get; set; } = String.Empty;
    public string Descricao {get;set;} = String.Empty;
     [JsonIgnore]

    public Cursos? Curso { get; set; }
    public int CursoId { get; set; }
     [JsonIgnore]
    public ICollection<Aulas> Aulas { get; set; } = new List<Aulas>();
  }
}
