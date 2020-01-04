using Data;
using EstoqueProduto.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EstoqueProduto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueProdutoController : ControllerBase
    {
        [HttpGet("GetProduto")]
        public List<Produto> GetProduto()
        {
            return new Estoque().BuscarProdutos();
        }

        [HttpGet("GetProduto")]
        public Produto GetProduto(int idProduto)
        {
            return new Estoque().BuscarProduto(idProduto);
        }

        [HttpPut("PutProduto")]
        public Produto PutProduto(Produto produto)
        {
            return new Estoque().AtualizarProduto(produto);
        }

        [HttpDelete("DeleteProduto")]
        public string DeleteProduto(int idProduto)
        {
            return new Estoque().DeletarProduto(idProduto);
        }

        [HttpPost("PostProduto")]
        public Produto PostProduto(Produto produto)
        {
            return new Estoque().SalvarProduto(produto);
        }



    }
}