using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetByID(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Insert(Movie obj)
        {
            _context.Movies.Add(obj);
        }

        public void Delete(int id)
        {
            var Movie = _context.Movies.Find(id);
            _context.Movies.Remove(Movie);
        }

        public void Update(Movie obj)
        {
            _context.Update(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
