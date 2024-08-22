using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public OrdersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _uow.OrderRepository.AllAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<Order> GetOrder(int id)
        {
            var order = await _uow.OrderRepository.GetAsync(id);
            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            await _uow.OrderRepository.UpdateAsync(order);

            try
            {
                await _uow.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) 
            {
                return NoContent();
            }
            return Ok();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _uow.OrderRepository.AddAsync(order);
            await _uow.SaveChanges();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _uow.OrderRepository.DeleteAsync(id);
            await _uow.SaveChanges();

            return NoContent();
        }

        private async Task<bool> OrderExistsAsync(int id)
        {
            if (await _uow.OrderRepository.FindAsync(o => o.OrderID == id) != null)
            {
                return true;
            } 
            
            return false;   
        }

    }
}
