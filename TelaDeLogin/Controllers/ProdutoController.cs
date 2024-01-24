using Microsoft.AspNetCore.Mvc;
using TelaDeLogin.DTO;
using TelaDeLogin.Repositories;

namespace TelaDeLogin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrandoProduto([FromBody] Produto produto)
        {

            Repository.InserindoProduto(produto);
            return Ok(produto);
        }

        [HttpGet]
        public IActionResult RetornandoProdutos()
        {
            var produtos = Repository.RetornandoProdutosBanco();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaProdutoId(int id)
        {
            var produto = Repository.RetornandoIdBanco(id);
            return Ok(produto);
        }
    }
}
