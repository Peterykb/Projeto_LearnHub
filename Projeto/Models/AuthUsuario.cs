using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projeto.Models
{
  public class AuthUsuario
  {
     public int id {get;set;}
     public string senhacriptografada {get;set;} = string.Empty;
     public bool professorornot {get;set;}   
  }
}
