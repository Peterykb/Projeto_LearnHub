using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Projeto.Models.Authentication.Instrutor
{
  public class InstrutorIdentity : IEntityTypeConfiguration<InstrutorLogin>
  {
    public void Configure(EntityTypeBuilder<InstrutorLogin> builder)
    {
      builder.Property(i => i.ID_login).IsRequired();

    }
  }
}
