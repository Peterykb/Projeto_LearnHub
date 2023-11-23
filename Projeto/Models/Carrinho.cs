using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
    public class Carrinho
    {
        [Key]
        public int Id_carrinho { get; set; }
        public int Quantidade { get; set; }
        public int CursoId { get; set; }
         [JsonIgnore]
        public Cursos? Curso { get; set; }
         [JsonIgnore]
        public AlunoInformacoes? Aluno { get; set; }
        public int AlunoId {get;set;}
    }
}
