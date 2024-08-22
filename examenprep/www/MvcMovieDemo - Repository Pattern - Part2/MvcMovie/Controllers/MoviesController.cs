using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.ViewModels;

namespace MvcMovie.Controllers
{
	public class MoviesController : Controller
	{
		private IRepository<Movie> MovieRepository;
		private IRepository<Rating> RatingRepository;

		public MoviesController(MovieContext context)
		{
			RatingRepository = new GenericRepository<Rating>(context);
			MovieRepository = new GenericRepository<Movie>(context);
		}

		public IActionResult List(int ratingID = 0)
		{
			var listMoviesVM = new ListMoviesViewModel();

			if (ratingID != 0)
			{
				listMoviesVM.Movies = MovieRepository.Get(
					filter: m => m.RatingID == ratingID,
                    orderBy: m => m.OrderBy(x => x.Title)).ToList();
			}
			else
			{
                listMoviesVM.Movies = MovieRepository.Get(
                    orderBy: m => m.OrderBy(x => x.Title)).ToList();
            }

            listMoviesVM.Ratings =
                new SelectList(
                    RatingRepository.Get(orderBy: m => m.OrderBy(x => x.Name)).ToList(),
                    "RatingID", "Name");

            return View(listMoviesVM);
		}

        public IActionResult Details(int id)
        {
            var movie = MovieRepository.Get(
                filter: x => x.MovieID == id,
                includes: x => x.Rating).FirstOrDefault();

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
		{
			ViewData["Ratings"] =
				new SelectList(RatingRepository.GetAll()
				.OrderBy(r => r.Name),
							   "RatingID",
							   "Name");

			return View();
		}
	}
}