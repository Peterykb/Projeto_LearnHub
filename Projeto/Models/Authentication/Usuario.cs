using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models.Authentication
{
    public class Usuario
    {
        public int id {get;set;}
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set;}
    }
}