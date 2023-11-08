using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Projeto.Models.Authentication
{
    public class ApplicationUser : IdentityUser<Guid>
    {
      public int Id_Instrutor {get;set;}
      public virtual Instrutor? Instrutor {get;set;}
    }
}
