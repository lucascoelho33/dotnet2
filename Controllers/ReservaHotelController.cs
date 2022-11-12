#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet2.Models;

namespace dotnet2.Controllers
{
    public class ReservaHotelController : Controller
    {
        private readonly MyDbContext _context;

        public ReservaHotelController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ReservaHotel
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaHotels.ToListAsync());
        }

        // GET: ReservaHotel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHotel = await _context.ReservaHotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaHotel == null)
            {
                return NotFound();
            }

            return View(reservaHotel);
        }

        // GET: ReservaHotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservaHotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroReserva,Valor,DataReserva")] ReservaHotel reservaHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservaHotel);
        }

        // GET: ReservaHotel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHotel = await _context.ReservaHotels.FindAsync(id);
            if (reservaHotel == null)
            {
                return NotFound();
            }
            return View(reservaHotel);
        }

        // POST: ReservaHotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroReserva,Valor,DataReserva")] ReservaHotel reservaHotel)
        {
            if (id != reservaHotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaHotelExists(reservaHotel.Id))
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
            return View(reservaHotel);
        }

        // GET: ReservaHotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHotel = await _context.ReservaHotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaHotel == null)
            {
                return NotFound();
            }

            return View(reservaHotel);
        }

        // POST: ReservaHotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaHotel = await _context.ReservaHotels.FindAsync(id);
            _context.ReservaHotels.Remove(reservaHotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaHotelExists(int id)
        {
            return _context.ReservaHotels.Any(e => e.Id == id);
        }
    }
}
