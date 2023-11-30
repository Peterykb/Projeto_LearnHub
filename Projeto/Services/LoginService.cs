using Microsoft.AspNetCore.Identity;
using Projeto.Models.Authentication;

namespace Projeto.Services
{
    public class LoginService
    {
        private readonly UserManager<IdentityUser> userManager;

        public LoginService(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task<string?> LoginAsync(string username, string password, string userType)
        {
            IdentityUser user;

            if (userType == "Aluno")
            {
                user = await userManager.FindByNameAsync(username);
            }
            else if (userType == "Instrutor")
            {
                user = await userManager.FindByNameAsync(username);
            }
            else
            {
                // Lidar com tipo de usuário inválido, se necessário
                return null;
            }

            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                return TokenService.GenerateToken(user, userType);
            }

            return null;
        }
    }
}
