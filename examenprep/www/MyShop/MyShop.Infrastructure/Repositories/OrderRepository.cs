using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System.Linq;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        private readonly ShoppingContext _context;
        public OrderRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public override Task<Order> UpdateAsync(Order entity)
        {
            var order = _context.Orders
                .Single(o => o.OrderID == entity.OrderID);

            order.OrderDate = entity.OrderDate;
            order.Orderlines = entity.Orderlines;

            return base.UpdateAsync(order);
        }

        public override async Task<IEnumerable<Order>> AllAsync()
        {
           var orders = _context.Orders.Include(o => o.Orderlines)
                .ThenInclude(ol => ol.Product);
            orders.Include(o => o.Customer);

            return await orders.ToListAsync();
        }

    }
}
