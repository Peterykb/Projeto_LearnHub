  using System.ComponentModel.DataAnnotations;

  namespace Projeto.Models
  {
      public class Cursos
  {
      [Key]
      public int Id_curso { get; set; }
      public string Name { get; set; } = string.Empty;
      public int Data_criacao { get; set; }

      // Definição da chave estrangeira
      public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
        public ICollection<CursoCategoria> CursoCategorias { get; set; } = new List<CursoCategoria>();
  }

  }
