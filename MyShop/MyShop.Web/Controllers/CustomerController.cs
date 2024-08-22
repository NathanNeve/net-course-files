using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShoppingContext _context;

        public CustomerController(ShoppingContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var customers = _context.Customers.ToList();
                return View(customers);
            }
            else
            {
                var customers = new[] { _context.Customers.Find(id.Value) };
                return View(customers);
            }
        }
    }
}
