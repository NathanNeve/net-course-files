using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _uow.ProductRepository.AllAsync();
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public Task<Product> GetProduct(int id)
        {
            var product = _uow.ProductRepository.GetAsync(id);

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _uow.ProductRepository.AddAsync(product);
            _uow.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }
    }
}
