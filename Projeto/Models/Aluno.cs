using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    public class Aluno
    {
        [Key]
        public int Id_aluno { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Pass { get; set; } = String.Empty;
        [ForeignKey("Id_curso")]
        public int Id_curso { get; set; }
        public ICollection<AlunoCurso>? AlunoCursos { get; set; } = new List<AlunoCurso>();

    }
}