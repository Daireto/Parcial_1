using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;
using Parcial1.Data.Entities;
using Parcial1.Helpers;
using Parcial1.Models;

namespace Parcial1.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public TicketsController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public IActionResult SearchTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchTicket(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return NotFound();
                }

                Ticket ticket = await _context.Tickets.FindAsync(model.Id);
                if (ticket == null)
                {
                    ModelState.AddModelError(string.Empty, "La boleta no existe");
                    return View(model);
                }

                if (ticket.WasUsed == false)
                {
                    return RedirectToAction(nameof(SetTicket), new { id = ticket.Id });
                }
                else
                {
                    return RedirectToAction(nameof(TicketDetails), new { id = ticket.Id });
                }

            }
            return View(model);
        }

        public async Task<IActionResult> SetTicket(int id)
        {
            UpdateTicketViewModel model = new()
            {
                Id = id,
                Entrances = await _combosHelper.GetComboEntrancesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetTicket(UpdateTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return NotFound();
                }

                Ticket ticket = await _context.Tickets.FindAsync(model.Id);
                ticket.WasUsed = true;
                ticket.Document = model.Document;
                ticket.Name = model.Name;
                ticket.Date = DateTime.Today;
                ticket.Entrance = await _context.Entrances.FindAsync(model.EntranceId);
                _context.Update(ticket);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(TicketDetails), new { id = ticket.Id });
            }
            return View();
        }

        public async Task<IActionResult> TicketDetails(int id)
        {
            Ticket ticket = await _context.Tickets
                .Include(t => t.Entrance)
                .FirstOrDefaultAsync(t => t.Id == id);
            return View(ticket);
        }
    }
}
