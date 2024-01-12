using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelaDeLogin.DTO;
using TelaDeLogin.Models;
using TelaDeLogin.Repositories;

namespace TelaDeLogin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastrandoCliente([FromBody] Cliente cliente)
        {
            Repository.CadastraClienteBanco(cliente);
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult RetornandoClientes([FromBody] Cliente cliente)
        {
            Repository.RetornaClientesBanco(cliente);
            return Ok();
        }

        [HttpGet]
        public IActionResult LoginCliente([FromBody] Login login)
        {
            Repository.LoginClienteBanco(login);
            return Ok();
        }
    }
}
