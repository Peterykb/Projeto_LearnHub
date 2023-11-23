using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{

  public class CursoCategoria
  {

    public int CursoId { get; set; }
    public Cursos? Cursos { get; set; }

    public int CategoriaId { get; set; }
     [JsonIgnore]
    public Categorias? Categorias { get; set; }

  }

}
