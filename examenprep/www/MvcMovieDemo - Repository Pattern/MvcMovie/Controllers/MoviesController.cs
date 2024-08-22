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
			RatingRepository = new RatingRepository(context);
			MovieRepository = new MovieRepository(context);
		}

		public IActionResult List(int ratingID = 0)
		{
			var listMoviesVM = new ListMoviesViewModel();

			if (ratingID != 0)
			{
                listMoviesVM.Movies = MovieRepository.GetAll().Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList()
			}
			else
			{
                listMoviesVM.Movies = MovieRepository.GetAll().OrderBy(m => m.Title).ToList();
			}

			listMoviesVM.Ratings =			
			new SelectList(RatingRepository.GetAll().OrderBy(r => r.Name),
								"RatingID", "Name");
			listMoviesVM.ratingID = ratingID;

			return View(listMoviesVM);
		}

		public IActionResult Details(int id)
		{
			var movie = MovieRepository.GetByID(id);

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