using Microsoft.EntityFrameworkCore;

namespace Projeto.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Cursos> cursos { get; set; }
        public DbSet<Aluno> alunos {get;set;}
        public DbSet<AlunoCurso> alunoCursos {get;set;}
        public DbSet<Aulas> aulas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cursos>().HasOne(c => c.Categoria).WithMany().HasForeignKey(c => c.Id_categoria).IsRequired(false);
            modelBuilder.Entity<Cursos>()
           .HasMany(c => c.Aulas)
           .WithOne(a => a.Curso)
           .HasForeignKey(a => a.Id_curso)
           .IsRequired(false);

            modelBuilder.Entity<Aulas>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.Aulas)
                .HasForeignKey(a => a.Id_curso)
                .IsRequired(false);
            modelBuilder.Entity<AlunoCurso>()
                .HasKey(ac => new { ac.AlunoId, ac.CursoId });

            modelBuilder.Entity<AlunoCurso>()
                .HasOne(ac => ac.Aluno)
                .WithMany(a => a.AlunoCursos)
                .HasForeignKey(ac => ac.AlunoId);

            modelBuilder.Entity<AlunoCurso>()
                .HasOne(ac => ac.Curso)
                .WithMany(c => c.AlunoCursos)
                .HasForeignKey(ac => ac.CursoId);


        }

    }
}