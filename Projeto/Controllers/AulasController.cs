using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AulasController : ControllerBase
    {
      public readonly Context context;
      public AulasController(Context _context){
        context = _context;
      }

    }
}
