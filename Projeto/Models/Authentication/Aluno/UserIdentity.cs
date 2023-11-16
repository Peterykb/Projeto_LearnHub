

using Microsoft.AspNetCore.Identity;

namespace Projeto.Models.Authentication
{
    public class UserIdentity : IdentityUser
    {
        public int ID_login {get;set;}
    }
}
