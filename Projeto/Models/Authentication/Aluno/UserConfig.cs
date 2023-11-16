using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.Models.Authentication.Aluno
{
  public class UserConfig : IEntityTypeConfiguration<UserIdentity>
  {
  

    public void Configure(EntityTypeBuilder<UserIdentity> builder)
    {
      throw new NotImplementedException();
    }
  }
}
