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
    public class ParceiroController : Controller
    {
        private readonly MyDbContext _context;

        public ParceiroController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Parceiro
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Parceiros.Include(p => p.Fisica);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Parceiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiro = await _context.Parceiros
                .Include(p => p.Fisica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parceiro == null)
            {
                return NotFound();
            }

            return View(parceiro);
        }

        // GET: Parceiro/Create
        public IActionResult Create()
        {
            ViewData["FisicaId"] = new SelectList(_context.Fisicas, "Id", "Discriminator");
            return View();
        }

        // POST: Parceiro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoPessoa,Atividade,FisicaId")] Parceiro parceiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FisicaId"] = new SelectList(_context.Fisicas, "Id", "Discriminator", parceiro.FisicaId);
            return View(parceiro);
        }

        // GET: Parceiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiro = await _context.Parceiros.FindAsync(id);
            if (parceiro == null)
            {
                return NotFound();
            }
            ViewData["FisicaId"] = new SelectList(_context.Fisicas, "Id", "Discriminator", parceiro.FisicaId);
            return View(parceiro);
        }

        // POST: Parceiro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoPessoa,Atividade,FisicaId")] Parceiro parceiro)
        {
            if (id != parceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParceiroExists(parceiro.Id))
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
            ViewData["FisicaId"] = new SelectList(_context.Fisicas, "Id", "Discriminator", parceiro.FisicaId);
            return View(parceiro);
        }

        // GET: Parceiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parceiro = await _context.Parceiros
                .Include(p => p.Fisica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parceiro == null)
            {
                return NotFound();
            }

            return View(parceiro);
        }

        // POST: Parceiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parceiro = await _context.Parceiros.FindAsync(id);
            _context.Parceiros.Remove(parceiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParceiroExists(int id)
        {
            return _context.Parceiros.Any(e => e.Id == id);
        }
    }
}
