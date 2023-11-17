using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class Carrinho
    {
        [Key]
        public int Id_carrinho { get; set; }
        public int Quantidade { get; set; }
        public int CursoId { get; set; }
        public Cursos? Curso { get; set; }
        public AlunoInformacoes? Aluno { get; set; }
        public int AlunoId {get;set;}
    }
}
