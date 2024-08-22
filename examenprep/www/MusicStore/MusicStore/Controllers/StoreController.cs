using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListGenres()
        {
            return View(await _context.Genres.OrderBy(g => g.Name).ToListAsync());
        }

        public async Task<IActionResult> ListAlbums(int? id)
        {
            var listAlbumsVM = new ListAlbumsViewModel();
            listAlbumsVM.genreID = (int)id;
            listAlbumsVM.genre = await _context.Genres.FindAsync(id);
            listAlbumsVM.Albums = await _context.Albums.Where(a => a.GenreID == id).OrderBy(a => a.Title).ToListAsync();
            return View(listAlbumsVM);
        }

        // GET: details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                            .Include(a => a.Artist)
                            .Include(a => a.Genre)
                            .FirstOrDefaultAsync(m => m.AlbumID == id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
    }
}
