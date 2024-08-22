using Adventures.Domain.Models.ViewModels;
using Adventures.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Adventures.Web.Controllers
{
    public class TravelController : Controller
    {
        private readonly TravelContext _context;
        public TravelController(TravelContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.Include(c => c.Trips).ThenInclude(c => c.Bookings).ThenInclude(c => c.Traveller).OrderBy(c => c.Name).ToList();
            return View(countries);
        }

        public IActionResult Create(int id)
        {
            var CreateBookingVM = new CreateBookingViewModel();
            CreateBookingVM.TripName = _context.Trips.Where(b => b.TripId == id).SingleOrDefault().Title;

            //CreateBookingVM.Travellers = new SelectList(_context.Travellers.OrderBy(t => t.Lastname), "TravellerId", "Fullname");
            
            return View(CreateBookingVM);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return RedirectToAction("Index");
        }
    }
}
