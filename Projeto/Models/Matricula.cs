
using System.Text.Json.Serialization;

namespace Projeto.Models
{
  public class Matricula
{
    public int AlunoId { get; set; }
    [JsonIgnore]
    public AlunoInformacoes? Aluno { get; set; }

    public int CursoId { get; set; }
     [JsonIgnore]
    public Cursos? Curso { get; set; }
}

}
