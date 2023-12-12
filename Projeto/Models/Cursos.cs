using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
  public class Cursos
  {
    [Key]
    public int Id_curso { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonConverter(typeof(DataFormat))]
    public DateTime Data_criacao { get; set; }
    public string Idiomas {get;set;} = string.Empty;
    public bool Disponivel { get; set; } = true;
    public double Preco { get; set; }
    public int InstrutorId { get; set; }
    [JsonIgnore]

    public InstrutorInformacoes? Instrutor { get; set; }

    [JsonIgnore]
    public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
    [JsonIgnore]
    public ICollection<CursoCategoria> CursoCategorias { get; set; } = new List<CursoCategoria>();
    [JsonIgnore]
    public ICollection<Modulos> Modulos { get; set; } = new List<Modulos>();
    [JsonIgnore]
    public List<Carrinho>? Carrinhos { get; set; }
  }
}
