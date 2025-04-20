using App.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product {Id= 1,Name = "Product1", Price = 10},
            new Product {Id= 2,Name = "Product2", Price = 15},
            new Product {Id= 3,Name = "Product3", Price = 20},
            new Product {Id= 4,Name = "Product4", Price = 25},
            new Product {Id= 5,Name = "Product5", Price = 30}
        };

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            products.Add(product);
            return Ok();
        }

        [HttpGet("/get/({id})")]
        public IActionResult Get([FromRoute]int id)
        {
            var product = products.Find(product => product.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("/get2")]
        public IActionResult Get2([FromQuery] int id)
        {
            var product = products.Find(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("form")]
        public IActionResult Form([FromForm] Product product)
        {
            products.Add(product);
            return Ok();
        }
    }
}
