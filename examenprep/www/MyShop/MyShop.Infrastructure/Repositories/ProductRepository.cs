using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System.Linq;

namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly ShoppingContext _context;
        public ProductRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public override Task<Product> UpdateAsync(Product entity)
        {
            var product = _context.Products
                .Single(p => p.ProductID == entity.ProductID);

            product.Price = entity.Price;
            product.Name = entity.Name;

            return base.UpdateAsync(product);
        }
    }
}
