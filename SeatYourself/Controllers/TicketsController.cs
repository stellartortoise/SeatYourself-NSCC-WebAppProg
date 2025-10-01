using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeatYourself.Data;
using SeatYourself.Models;

namespace SeatYourself.Controllers
{
    public class TicketsController : Controller
    {
        private readonly SeatYourselfContext _context;

        public TicketsController(SeatYourselfContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var seatYourselfContext = _context.Ticket.Include(t => t.vOccasion).Include(t => t.vSeat);
            return View(await seatYourselfContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.vOccasion)
                .Include(t => t.vSeat)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["OccasionId"] = new SelectList(_context.Occasion, "OccasionId", "OccasionId");
            ViewData["SeatId"] = new SelectList(_context.Set<Seat>(), "SeatId", "SeatId");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,OccasionId,SeatId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OccasionId"] = new SelectList(_context.Occasion, "OccasionId", "OccasionId", ticket.OccasionId);
            ViewData["SeatId"] = new SelectList(_context.Set<Seat>(), "SeatId", "SeatId", ticket.SeatId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["OccasionId"] = new SelectList(_context.Occasion, "OccasionId", "OccasionId", ticket.OccasionId);
            ViewData["SeatId"] = new SelectList(_context.Set<Seat>(), "SeatId", "SeatId", ticket.SeatId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,OccasionId,SeatId")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OccasionId"] = new SelectList(_context.Occasion, "OccasionId", "OccasionId", ticket.OccasionId);
            ViewData["SeatId"] = new SelectList(_context.Set<Seat>(), "SeatId", "SeatId", ticket.SeatId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.vOccasion)
                .Include(t => t.vSeat)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.TicketId == id);
        }

        //public async Task<IActionResult> SelectSeats(int? id) // Class generated by Gemini AI
        //{
        //    if (id == null) return NotFound();

        //    var occasion = await _context.Occasions
        //                                 .FirstOrDefaultAsync(o => o.OccasionId == id);

        //    if (occasion == null) return NotFound();

        //    // The logic to get sold seats and venue seats remains the same
        //    var soldSeatIds = await _context.Tickets
        //                                    .Where(t => t.OccasionId == id)
        //                                    .Select(t => t.SeatId)
        //                                    .ToListAsync();

        //    var venueSeats = await _context.Seats
        //                                   .Where(s => s.VenueId == occasion.VenueId)
        //                                   .ToListAsync();

        //    // --- Key Change: Use ViewBag Instead of a ViewModel ---

        //    // A. Pass the Occasion Title to the view
        //    ViewBag.OccasionTitle = occasion.Title;

        //    // B. Create a simple list of seats with their availability
        //    var seatsForView = venueSeats.Select(seat => new
        //    {
        //        SeatId = seat.SeatId,
        //        Row = seat.Row.ToString(),
        //        Number = seat.Number,
        //        IsAvailable = !soldSeatIds.Contains(seat.SeatId)
        //    }).ToList();

        //    // C. Pass the list of seats to the view
        //    // Note: We are now passing the list directly as the model
        //    return View(seatsForView);
        //}

    }
}
