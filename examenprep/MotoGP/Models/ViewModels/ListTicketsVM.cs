using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class ListTicketsVM
    {
        public SelectList? RacesSelectList { get; set; }
        public int SelectedRaceId { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Country> Countries { get; set; }
    }
}
