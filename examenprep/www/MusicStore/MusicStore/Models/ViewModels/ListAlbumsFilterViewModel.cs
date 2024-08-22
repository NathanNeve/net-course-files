using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MusicStore.Models.ViewModels
{
    public class ListAlbumsFilterViewModel
    {
        public SelectList Genres { get; set; }
        public SelectList Artists { get; set; }
        public List<Album> Albums { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }
        public string Title { get; set; }
    }
}
