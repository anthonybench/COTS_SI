using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COTS_Inventory.Data;
using COTS_Inventory.Models;

// Note for `Edit` and `Create` POST methods:
// To protect from overposting attacks, enable the specific properties you want to bind to, for 
// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

namespace COTS_Inventory.Controllers
{
    public class TestsController : Controller
    {
        private readonly COTSContext _context;

        public TestsController(COTSContext context)
        {
            _context = context;
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tests.ToListAsync());
        }

        // GET: Tests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Tests/Create
        public IActionResult Create()
        {
            GetProductList();
            return View();
        }

        // POST: Tests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SP_Id,TestPlan,WEDocument,TestDate,PassResult")] Test test)
        {
            // invalid principal guard
            var parentProductExists = _context.Products.Any(p => p.Id == test.SP_Id);
            if (!parentProductExists)
            {
                TempData["Message"] = "Parent product-Id entered not found, please enter corresponding `product` first.";
            }

            // successful entry
            else if (ModelState.IsValid)
            {
                _context.Add(test);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Entry successfully added!";
                return RedirectToAction(nameof(Index));
            }

            GetProductList();
            return View(test);
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            GetProductList();
            return View(test);
        }

        // POST: Tests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SP_Id,TestPlan,WEDocument,TestDate,PassResult")] Test test)
        {
            // invalid principal guard
            var parentProductExists = _context.Products.Any(p => p.Id == test.SP_Id);
            if (!parentProductExists)
            {
                TempData["Message"] = "Parent product-Id entered not found, please enter corresponding `product` first.";
            }

            // successful edit
            else if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Entry edited successfully!";
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestExists(test.Id))
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

            GetProductList();
            return View(test);
        }

        // GET: Tests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Entry successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        // Utility Functions
        private bool TestExists(int id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }

        public void GetProductList()
        {
            ViewBag.ProductSelectList = new SelectList(_context.Products
                .OrderBy(p => p.Id)
                .ToList(), "Id", "Name");
        }
    }
}
