using System.ComponentModel.DataAnnotations;


namespace Projeto.Models
{
    public class Categorias
    {
        [Key]
        public int Id_categoria {get;set;}
        public string Name {get;set;} = String.Empty;
        public ICollection<Cursos>? Cursos {get;set;}
   
        
    }
}