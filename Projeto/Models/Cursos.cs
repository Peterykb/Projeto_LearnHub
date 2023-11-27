using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
    public class Cursos
    {
        [Key]
        public int Id_curso { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Data_criacao { get; set; }
        public bool Disponivel { get; set; } = true;
        public double Preco { get; set; }
        public int InstrutorId { get; set; }
         [JsonIgnore]

        public InstrutorInformacoes? Instrutor { get; set; }

        // Definição da chave estrangeira
         [JsonIgnore]
        public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
         [JsonIgnore]
        public ICollection<CursoCategoria> CursoCategorias { get; set; } = new List<CursoCategoria>();
         [JsonIgnore]
        public ICollection<Modulos> Modulos { get; set; } = new List<Modulos>();
         [JsonIgnore]
        public ICollection<Carrinho>? carrinho { get; set; }
    }
}
