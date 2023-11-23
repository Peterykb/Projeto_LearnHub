using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Projeto.Models
{
    public class Categorias
    {
        [Key]
        public int Id_categoria {get;set;}
        public string Name {get;set;} = string.Empty;
         [JsonIgnore]
        public ICollection<CursoCategoria>? CursoCategorias {get;set;}

    }
}
