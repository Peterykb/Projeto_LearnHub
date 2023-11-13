using Microsoft.AspNetCore.Identity;

namespace Projeto.Models.Authentication
{
    public class InstrutorLogin : IdentityUser
    {
        public int ID_login {get;set;}
    }
}
