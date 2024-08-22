using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private IUnitOfWork _uow;

        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            var orders = _uow.OrderRepository.AllAsync();

            return View(orders);
        }

        public IActionResult Create()
        {
            var products = _uow.ProductRepository.AllAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var existingCustomer = await _uow.CustomerRepository.FindAsync(filter: c => c.Name == model.Customer.Name);

            if (existingCustomer.Any())
            {
                var existingCustomerEntity = existingCustomer.First();
                existingCustomerEntity.ShippingAddress = customer.ShippingAddress;
                existingCustomerEntity.City = customer.City;
                existingCustomerEntity.PostalCode = customer.PostalCode;
                existingCustomerEntity.Country = customer.Country;
                await _uow.CustomerRepository.UpdateAsync(existingCustomerEntity);
            }
            else
            {
                await _uow.CustomerRepository.AddAsync(customer);
            }

            await _uow.SaveChanges();

            return Ok();
        }

    }
}
