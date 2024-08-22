using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;
using System.Diagnostics;
using System.Xml.Linq;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;

        public InfoController(GPContext context)
        {
            _context = context;
        }


        public IActionResult ListRaces()
        {
            ViewData["BannerNr."] = 0;
            ViewData["Title"] = "Races";

            var Races = _context.Races;


            return View(Races.ToList());
        }

        public IActionResult BuildMap() 
        {
            var Races = _context.Races;

            ViewData["BannerNr."] = 0;

            return View(Races.ToList());
        }

        public IActionResult ShowRace(int id)
        {
            var Races = _context.Races.ToList();
            var race = Races[id];

            ViewData["id"] = id;
            ViewData["BannerNr."] = 0;
            ViewData["Title"] = "Race - " + race.Name;

            return View(race);
        }

        public IActionResult ListRiders()
        {
            ViewData["Title"] = "Riders";
            ViewData["BannerNr."] = 1;

            var Riders = _context.Riders.OrderBy(r => r.Number)
                .ToList();

            return View(Riders);
        }

        public IActionResult SelectRace(int SelectedRaceId)
        {
            ViewData["Title"] = "Races";
            ViewData["BannerNr."] = 0;

            SelectListRacesVM vm = new SelectListRacesVM();
            vm.RacesSelectList = new SelectList(
            _context.Races.OrderBy(r => r.Name).ToList(),
                "RaceID",
                "Name"
                );
            vm.SelectedRaceId = SelectedRaceId;

            if (SelectedRaceId == 0)
            {
                return View(vm);

            } else
            {
                vm.SelectedRace = _context.Races.Single(r => r.RaceID == SelectedRaceId);
                return View(vm);
            }
        }
    }
}
