using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projeto.Models
{
    public class Cursos
    {
        [Key]
        public int Id_curso { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Data_criacao { get; set; }

        [ForeignKey("Id_Categoria")] // Usar o nome da propriedade de navegação
        public int? Id_categoria { get; set; }
        public Categorias? Categoria { get; set; }
        public ICollection<Aulas>? Aulas { get; set; }
        public ICollection<Matricula>? matriculas { get; set; } = new List<Matricula>();
    }
}
