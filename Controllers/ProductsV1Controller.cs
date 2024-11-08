using Microsoft.AspNetCore.Mvc;
using RestAPIPro.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIPro.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products/v1")]  // <-- Add version 1 specific path
    [ApiController]
    public class ProductsV1Controller : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Smartphone", Price = 699.99M }
        };

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpGet("get-by-id/{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("add")]
        public ActionResult<Product> AddProduct(Product newProduct)
        {
            _products.Add(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("update/{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return Ok(product);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return NoContent();
        }
    }
}
