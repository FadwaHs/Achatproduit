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
    public class ProduitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // is required for binding on HTTP GET requests.
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }




        // GET: Produits
        public async Task<IActionResult> Index(string? CategoryFilter, string? SearchString)
        {
            if (_context.Produits == null)
            {
                return Problem("Entity in Null ");
            }

            var produits = from p in _context.Produits
                           join c in _context.Categories on p.CategoryID equals c.CategoryID
                           select new ProduitViewModel
                           {
                               Product = p,
                               CategoryName = c.Name
                           };

            if (!string.IsNullOrEmpty(SearchString))
            {
                produits = produits.Where(item => item.Product.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CategoryFilter))
            {
                produits = produits.Where(item => item.CategoryName == CategoryFilter);
            }

            var productList = produits.ToList(); // Convert to a list

            var categories = _context.Categories.Select(c => c.Name).Distinct().ToList();
            ViewData["Categories"] = categories;

            return View(productList);
        }


        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Description,Price,Quantity,Image,CategoryID")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Description,Price,Quantity,Image,CategoryID")] Produit produit)
        {
            if (id != produit.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.ProductID))
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
            return View(produit);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produits'  is null.");
            }
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // Action method to add a product to the cart
        public IActionResult AddToCart(int productId, int quantity)
        {
            // Get the product from the database
            var product = _context.Produits.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                // Handle the case where the product is not found
                return NotFound();
            }

            // Check if the cart exists for the current user (you might need to implement user authentication)
            var cart = _context.Paniers.Include(p => p.Items).FirstOrDefault();
            if (cart == null)
            {
                // If the cart doesn't exist, create a new one
                cart = new Panier();
                _context.Paniers.Add(cart);
                _context.SaveChanges(); // Save changes to get the new cart's ID
            }

            // Use the AddToPanier method to add the product to the cart
            cart.AddToPanier(product, quantity);

            // Explicitly load the related Items collection
            _context.Entry(cart).Collection(p => p.Items).Load();


            // Log or use breakpoints to inspect the state of the cart and items
            Console.WriteLine($"Cart ID: {cart.PanierID}, Items Count: {cart.Items.Count}");

            _context.SaveChanges(); // Save changes to update the cart

            return RedirectToAction("Index", "Paniers");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _context.Paniers.Include(p => p.Items).FirstOrDefault();

            if (cart != null)
            {
                // Call the RemoveFromPanier method to remove the product
                cart.RemoveFromPanier(productId);
                _context.SaveChanges(); // Save changes to update the cart
            }

            return RedirectToAction("Index", "Paniers");
        }






        private bool ProduitExists(int id)
        {
          return (_context.Produits?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
