
namespace Projeto.Models.Authentication
{
    public class Key
    {
          public static string Secret = KeyGenerator.GenerateSecureKey(256);
    }
}
