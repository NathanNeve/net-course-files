using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovieMVC.Controllers
{
    public class RatingsController : Controller
    {
        private readonly MovieContext _context;

        public RatingsController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var ratings = _context.Ratings.OrderBy(r => r.Name);
            return View(ratings);
        }

        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("RatingID, Code, Name")] Rating rating) 
        {
            if (ModelState.IsValid)
            {
                _context.Ratings.Add(rating);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(rating);
        }

        public IActionResult Edit(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            return View(rating);
        }


        // Ratings/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, [Bind("RatingID, Code, Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("List");
            }
            return View(rating);
        }

        public IActionResult Delete(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
