using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AchatProduit.Data;
using AchatProduit.Models;
using Microsoft.AspNetCore.Authorization;

namespace AchatProduit.Controllers
{
    [Authorize]
    public class PaniersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaniersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paniers
        public async Task<IActionResult> Index()
        {
            /*
             *     This line retrieves a list of Paniers from the database using Entity Framework's Include method.
                   The Include method is used to eagerly load the associated Items collection for each Panier with his Product
                   This helps to avoid lazy loading issues
             *
             */
            var carts = _context.Paniers.Include(p => p.Items)  // Include the Items collection in Panier
                .ThenInclude(i => i.Product) // !! you should Include the related Product for each LignePanier in Items
                .ToList();

            /*
             * 
             * Explicitly load the Items collection for each cart
             * it uses _context.Entry(cart) to get the EntityEntry for the Panier entity. The EntityEntry represents the entity being tracked by the DbContext
             * .Collection(p => p.Items) specifies that we want to work with the Items collection of the Panier.
             * .Load() is then called to explicitly load the Items collection. This ensures that the Items data is fetched from the database.
             * 
             */
            foreach (var cart in carts)
            {
                _context.Entry(cart).Collection(p => p.Items).Load();
            }

            // Pass the loaded carts to the view , The view will then render this data
            return View(carts);
        }

        // GET: Paniers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paniers == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers
                .FirstOrDefaultAsync(m => m.PanierID == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // GET: Paniers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PanierID")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(panier);
        }

        // GET: Paniers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paniers == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PanierID")] Panier panier)
        {
            if (id != panier.PanierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanierExists(panier.PanierID))
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
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paniers == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers
                .FirstOrDefaultAsync(m => m.PanierID == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paniers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Paniers'  is null.");
            }
            var panier = await _context.Paniers.FindAsync(id);
            if (panier != null)
            {
                _context.Paniers.Remove(panier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanierExists(int id)
        {
          return (_context.Paniers?.Any(e => e.PanierID == id)).GetValueOrDefault();
        }
    }
}
