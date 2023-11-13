using Microsoft.AspNetCore.Identity;
using Projeto.Models.Authentication;

namespace Projeto.Services
{
    public class LoginService
    {
        private readonly UserManager<AlunoLogin> alunomanager;
        private readonly UserManager<InstrutorLogin> instrutormanager;

        public LoginService(UserManager<AlunoLogin> _alunomanager, UserManager<InstrutorLogin> _instrutormanager)
        {
            alunomanager = _alunomanager;
            instrutormanager = _instrutormanager;
        }

        public async Task<bool> LoginAlunoAsync(string username, string password)
        {
            var user = await alunomanager.FindByNameAsync(username);

            if (user != null && await alunomanager.CheckPasswordAsync(user, password))
            {
                
                return true;
            }

            return false;
        }

        public async Task<bool> LoginInstrutorAsync(string username, string password)
        {
            var user = await instrutormanager.FindByNameAsync(username);

            if (user != null && await instrutormanager.CheckPasswordAsync(user, password))
            {
                // Realize ações adicionais, se necessário
                return true;
            }

            return false;
        }
    }
}
