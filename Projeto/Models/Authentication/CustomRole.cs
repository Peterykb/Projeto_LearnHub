using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Projeto.Models.Authentication
{
    public class CustomRole : IdentityRole<Guid>
    {
       public CustomRole() : base(){
        Id = Guid.NewGuid();
       }
       public CustomRole(string roleName) : base(roleName){
        Id = Guid.NewGuid();
       }
    }
}
