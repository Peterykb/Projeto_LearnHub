

using Microsoft.AspNetCore.Identity;

namespace Projeto.Models.Authentication
{
    public class AlunoLogin : IdentityUser
    {
        public int ID_login {get;set;}
    }
}
