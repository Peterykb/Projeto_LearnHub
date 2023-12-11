using BCrypt.Net;

public class CriptografiaService
{
    public string HashPassword(string password)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        return hashedPassword;
    }
 
}
