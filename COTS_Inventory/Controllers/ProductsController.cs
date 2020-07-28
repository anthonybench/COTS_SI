using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COTS_Inventory.Data;
using COTS_Inventory.Models;

// Note on `Create` and `Edit` POST action methods:
// To protect from overposting attacks, enable the specific properties you want to bind to, for 
// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

namespace COTS_Inventory.Controllers
{
    public class ProductsController : Controller
    {
        private readonly COTSContext _context;

        public ProductsController(COTSContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            GetVendorList();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SV_Id,Name,Version,VendorCatNum,Description,NPRClassification,SafetyCriticalDetermine")] Product product)
        {
            // invalid principal guard
            var parentVendorExists = _context.Vendor.Any(v => v.Id == product.SV_Id);
            if (!parentVendorExists)
            {
                TempData["Message"] = "Parent vendor-Id entered not found, please enter corresponding `vendor` first.";
            }

            // successful entry
            else if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Entry successfully added!";
                return RedirectToAction(nameof(Index));
            }

            GetVendorList();
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            GetVendorList();
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SV_Id,Name,Version,VendorCatNum,Description,NPRClassification,SafetyCriticalDetermine")] Product product)
        {
            // invalid principal guard
            var parentVendorExists = _context.Vendor.Any(v => v.Id == product.SV_Id);
            if (!parentVendorExists)
            {
                TempData["Message"] = "Parent vendor-Id entered not found, please enter corresponding `vendor` first.";
            }

            // successful edit
            else if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Entry edited successfully!";
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        TempData["Message"] = null;
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            GetVendorList();
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Entry successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        // Utiltiy Functions
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        public void GetVendorList()
        {
            ViewBag.VendorSelectList = new SelectList(_context.Vendor
                .OrderBy(v => v.Id)
                .ToList(), "Id", "Name");
        }
    }
}
