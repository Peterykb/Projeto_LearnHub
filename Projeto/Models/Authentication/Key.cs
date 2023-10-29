using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models.Authentication
{
    public class Key
    {
          public static string Secret = KeyGenerator.GenerateSecureKey(256);
    }
}