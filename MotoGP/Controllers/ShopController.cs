using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext _context;

        public ShopController (GPContext context)
        {
            _context = context;
        }

        public IActionResult OrderTicket()
        {
            ViewData["BannerNr."] = 3;
            ViewData["Title"] = "Order Tickets";

            ViewData["Countries"] = new SelectList(_context.Countries, "CountryID", "Name");
            ViewData["Races"] = new SelectList(_context.Races, "RaceID", "Name");

            return View();
        }

        //vraag1
        [Route("Shop/ConfirmOrder/{ticketId}")]
        //zonder is mijn route https://localhost:7270/Shop/ConfirmOrder?TicketID=12
        public IActionResult ConfirmOrder(int ticketID)
        {
            ViewData["BannerNr."] = 3;
            var ticket = _context.Tickets
                .Include(t => t.Race)
                .Single(t => t.TicketID == ticketID);
            // include methode -> join
            // find werkt niet met include, met single/singleordefault
            return View(ticket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order([Bind("Name,Email,Address,Number,CountryID,RaceID")] Ticket ticket) 
        {
            if(ModelState.IsValid)
            {
                ticket.OrderDate = DateTime.Now;
                ticket.Paid = false;

                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new { ticket.TicketID });
            }

            ViewData["BannerNr."] = 3;
            ViewData["Title"] = "Order Tickets";
            return View("OrderTicket", ticket);
        }


        public IActionResult ListTickets(int SelectedRaceId)
        {
            ViewData["BannerNr."] = 3;
            ViewData["Title"] = "Ordered Tickets";

            ListTicketsVM vm = new ListTicketsVM();
            vm.RacesSelectList = new SelectList(
            _context.Races.OrderBy(r => r.Name).ToList(),
                "RaceID",
                "Name"
                );
            vm.SelectedRaceId = SelectedRaceId;
            vm.Tickets = _context.Tickets.ToList();
            vm.Countries = _context.Countries.ToList();

            if (SelectedRaceId == 0)
            {
                return View(vm);
            } else
            {
                vm.Tickets = _context.Tickets.Where(t => t.RaceID == SelectedRaceId).ToList();
                return View(vm);
            }
        }

        public IActionResult EditTicket(int TicketId)
        {
            ViewData["BannerNr."] = 3;
            ViewData["Title"] = "Edit Ticket";

            EditTicketVM vm = new EditTicketVM();
            vm.Ticket = _context.Tickets.Single(t => t.TicketID == TicketId);
            vm.Country = _context.Countries.Single(c => c.CountryID == vm.Ticket.CountryID);
            vm.Race = _context.Races.Single(r => r.RaceID == vm.Ticket.RaceID);
            return View(vm);
        }
    }
}
