using Microsoft.AspNetCore.Mvc;
using TelaDeLogin.DTO;
using TelaDeLogin.Repositories;

namespace TelaDeLogin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpPost]
        public IActionResult InserindoVendas([FromBody] Venda venda)
        {

            Repository.InserindoVenda(venda);
            return Ok(venda);
        }

        [HttpGet]
        public IActionResult RetornandoVendas()
        {
            var vendas = Repository.RetornandoVendasBanco();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaProdutoId(int id)
        {
            var produto = Repository.RetornandoIdBanco(id);
            return Ok(produto);
        }
    }
}
