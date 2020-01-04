using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueProduto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueProdutoController : ControllerBase
    {
        [HttpGet("GetProduto")]
        public Produto GetProduto()
        {
            
        }
    }
}