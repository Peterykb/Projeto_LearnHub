using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarrinhoController : ControllerBase
  {
    public readonly Context context;
    public CarrinhoController(Context _context)
    {
      context = _context;
    }
  }
}
