using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interface;
using Business.Proxy;
using Eventing.EventMessages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService ProductService;
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }
        [HttpGet("GetProduct")]
        public async Task<ActionResult<ProductResponseMessage>> Get()
        {
            return await ProductService.Get();
        }
        [HttpGet("GetProductDetails")]
        public async Task<ActionResult<ProductResponseMessage>> Get(string id)
        {
            return await ProductService.Get(id);
        }

    }
}