using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{

  public class CursoCategoria
  {

    public int CursoId { get; set; }
    public Cursos? Cursos { get; set; }

    public int CategoriaId { get; set; }
    public Categorias? Categorias { get; set; }

  }

}
