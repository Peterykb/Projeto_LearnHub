using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Models.Authentication;
using Projeto.Services;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        public readonly UserIdentity user;
        public readonly UserRole role;
        public readonly Context context;
        public readonly TokenService tokenservice;
        public readonly UsuarioService userservice;

        public CadastroController(UserIdentity useridentity, UserRole userole, Context _context, TokenService servicetoken, UsuarioService users){
            user = useridentity;
            role = userole;
            context = _context;
            tokenservice = servicetoken;
            userservice = users;
        }
    }
}