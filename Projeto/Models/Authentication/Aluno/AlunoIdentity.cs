using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Models.Authentication.Aluno
{
  public class AlunoIdentity : IEntityTypeConfiguration<AlunoLogin>
  {
    public void Configure(EntityTypeBuilder<AlunoLogin> builder)
    {
        builder.Property(a => a.ID_login).IsRequired();
        
    }
  }
}
