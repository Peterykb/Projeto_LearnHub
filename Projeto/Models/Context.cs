using Microsoft.EntityFrameworkCore;

namespace Projeto.Models
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Categorias> categorias { get; set; }
    public DbSet<Cursos> cursos { get; set; }
    public DbSet<Aluno> alunos { get; set; }
    public DbSet<Instrutor> instrutors { get; set; }
    public DbSet<Matricula> matriculas { get; set; }
    public DbSet<Aulas> aulas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //Definindo a relação entre cursos e categorias
      modelBuilder.Entity<Cursos>().HasOne(c => c.Categoria).WithMany().HasForeignKey(c => c.Id_categoria).IsRequired(false);
      modelBuilder.Entity<Cursos>()
     .HasMany(c => c.Aulas)
     .WithOne(a => a.Curso)
     .HasForeignKey(a => a.Id_curso)
     .IsRequired(false);

      //Definindo a relação entre cursos e aulas
      modelBuilder.Entity<Aulas>()
          .HasOne(a => a.Curso)
          .WithMany(c => c.Aulas)
          .HasForeignKey(a => a.Id_curso)
          .IsRequired(false);

      //Definindo a relação n:n entre alunos e cursos através da tabela matricula
      modelBuilder.Entity<Matricula>()
          .HasKey(ac => new { ac.AlunoId, ac.CursoId });

      modelBuilder.Entity<Matricula>()
          .HasOne(ac => ac.Aluno)
          .WithMany(a => a.matriculas) //Representação da quantidade de matriculas do aluno em cursos
          .HasForeignKey(ac => ac.AlunoId);

      modelBuilder.Entity<Matricula>()
          .HasOne(ac => ac.Curso)
          .WithMany(c => c.matriculas) //Representação da quantidade de matriculas existentes no curso
          .HasForeignKey(ac => ac.CursoId);


    }

  }
}
