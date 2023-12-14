using Microsoft.AspNetCore.Identity;
using Projeto.Models.Authentication;
using System.Threading.Tasks;

public class UsuarioService
{
    private readonly UserManager<UserIdentity> _userManager;
    private readonly RoleManager<UserRole> _roleManager;

    public UsuarioService(UserManager<UserIdentity> userManager, RoleManager<UserRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> CadastrarUsuarioAsync(UserIdentity usuario, string senha, string roleName)
    {
        // Verifica se a role especificada já existe; se não existir, cria a role.
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await _roleManager.CreateAsync(new UserRole { Name = roleName, NormalizedName = roleName.ToUpper() });
        }

        await _userManager.AddToRoleAsync(usuario, roleName);

        return await _userManager.CreateAsync(usuario, senha);
    }
}
