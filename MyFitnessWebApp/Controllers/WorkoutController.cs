using Microsoft.AspNetCore.Mvc;
using MyFitnessWebApp.Data;
using MyFitnessWebApp.Models;


namespace MyFitnessWebApp.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly FitnessDbContext _context;
        public WorkoutController(FitnessDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // DB call
            List<String> workouts = new List<string>()
            {
            "W1", "W2", "W3"
            };

            // List of workouts
            // SELECT * FROM GYM
            List<Gym> gyms = _context.Gyms.ToList();


            // viewbag of viewdata
            // ViewBag.Workouts = workouts; (doet hetzelfde)
            //ViewData["Workouts"] = workouts;
            ViewBag.Gyms = gyms;    
            return View();
        }

        public IActionResult Details(int Id, string name, int amount)
        {
            // Get by ID
            ViewBag.Id = Id;  
            ViewBag.Name = name;
            ViewBag.Amount = amount;
            return View();
        }
    }
}
