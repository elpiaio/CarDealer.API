using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult RetornandoClientes()
        {
            var clients = Repository.RetornaClientesBanco();
            return Ok(clients);
        }

        [HttpPost("login")]
        public IActionResult LoginCliente([FromBody] Login login)
        {
            var cliente = Repository.LoginClienteBanco(login).FirstOrDefault();
            return Ok(cliente);
        }
    }
}
