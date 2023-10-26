using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projeto.Models
{
    public class Aulas
    {
        [Key]
        public int Id_aulas {get;set;}
        public string Titulo {get;set;} = String.Empty;
        public string url {get;set;} = String.Empty;
        [ForeignKey("Id_curso")]
        public int Id_curso {get;set;}
        public Cursos? Curso {get;set;}
        

    }
}