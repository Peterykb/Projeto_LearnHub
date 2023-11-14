using System.Security.Cryptography;

namespace Projeto.Models.Authentication
{
    public class KeyGenerator
    {
          public static string GenerateSecureKey(int keySizeInBits)
    {
        if (keySizeInBits % 8 != 0)
        {
            throw new ArgumentException("O tamanho da chave deve ser um múltiplo de 8 bits.");
        }

        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] keyBytes = new byte[keySizeInBits / 8];
            rng.GetBytes(keyBytes);
            return Convert.ToBase64String(keyBytes);
        }
    }
    }
}
