

namespace Projeto.Models
{
    public class AlunoCurso
    {
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public int CursoId { get; set; }
        public Cursos? Curso { get; set; }

    }
}