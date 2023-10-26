using System.ComponentModel.DataAnnotations;


namespace Projeto.Models
{
    public class Instrutor
    {
        [Key]
        public int Id_Instrutor {get;set;}
        public string Nome {get;set;} = String.Empty;

    }
}
