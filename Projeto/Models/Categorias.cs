using System.ComponentModel.DataAnnotations;


namespace Projeto.Models
{
    public class Categorias
    {
        [Key]
        public int Id_categoria {get;set;}
        public string Name {get;set;} = string.Empty;
        public ICollection<CursoCategoria>? CursoCategorias {get;set;}

    }
}
