using Projeto.Models;

public class AutenticacaoService
{
    private readonly Context _context;

    public AutenticacaoService(Context context)
    {
        _context = context;
    }

    public bool AutenticarUsuario(int id, string senha)
    {
        var usuario = _context.user.FirstOrDefault(u => u.id == id);

        if (usuario != null)
        {
            if (VerifyPassword(senha, usuario.senhacriptografada))
            {
                return usuario.professorornot;
            }
            else
            {
                throw new Exception("Senha incorreta.");
            }
        }
        else
        {
            throw new Exception("Usuário não encontrado.");
        }
    }
    public bool VerifyPassword(string password, string hashedPassword)
    {
        bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        return passwordMatches;
    }
    public bool VerificarSeEhProfessor(int id)
    {
        var usuario = _context.user.FirstOrDefault(u => u.id == id);

        if (usuario != null)
        {
            return usuario.professorornot;
        }
        return false;
    }

}