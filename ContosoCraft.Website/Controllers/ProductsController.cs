using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraft.Website.Models;
using ContosoCraft.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoCraft.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly JsonFileProductsService _productsService;

        public ProductsController(JsonFileProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productsService.GetProducts();
        }

        [HttpGet("rate")]
        public ActionResult Post(
            [FromQuery] string productId,
            [FromQuery] int rating)
        {
            _productsService.AddRating(productId, rating);

            return Ok();
        }
    }
}
