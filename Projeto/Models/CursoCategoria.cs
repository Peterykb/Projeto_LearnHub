using System.ComponentModel.DataAnnotations;


namespace Projeto.Models
{

  public class CursoCategoria
  {
    [Key]
    public int Id { get; set; }

    public int CursoId { get; set; }
    public Cursos? Cursos { get; set; }

    public int CategoriaId { get; set; }
    public Categorias? Categorias { get; set; }

  }










}
