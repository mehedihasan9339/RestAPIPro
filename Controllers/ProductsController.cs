using Microsoft.AspNetCore.Mvc;
using RestAPIPro.Models;

namespace RestAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Smartphone", Price = 699.99M }
        };

         // OPTIONS: api/products
        [HttpOptions]
        public IActionResult Options()
        {
            // Detailed response for the OPTIONS request
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");

            // Adding more detailed information to the response header
            Response.Headers.Add("X-Allow-Methods", "GET - Retrieves all products; POST - Adds a new product; PUT - Updates a product; DELETE - Removes a product");
            Response.Headers.Add("X-Description", "This endpoint allows basic CRUD operations on products. The allowed methods are: GET, POST, PUT, DELETE.");

            // Returning a 200 OK with no content, just headers describing allowed methods.
            return Ok();
        }

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            // Assigning a new ID for the created product
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            return NoContent();
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
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
