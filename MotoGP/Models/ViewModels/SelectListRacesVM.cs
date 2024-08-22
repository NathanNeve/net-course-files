using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class SelectListRacesVM
    {
        public List<Race> Races;
        public SelectList? RacesSelectList { get; set; }
        public int SelectedRaceId { get; set; }
        public Race SelectedRace;
    }
}
