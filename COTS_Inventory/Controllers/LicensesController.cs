using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COTS_Inventory.Data;
using COTS_Inventory.Models;

namespace COTS_Inventory.Controllers
{
    public class LicensesController : Controller
    {
        private readonly COTSContext _context;

        public LicensesController(COTSContext context)
        {
            _context = context;
        }

        // GET: Licenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Licence.ToListAsync());
        }

        // GET: Licenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.Licence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (license == null)
            {
                return NotFound();
            }

            return View(license);
        }

        // GET: Licenses/Create
        public IActionResult Create()
        {
            GetProductList();
            return View();
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SP_Id,Type,Servicer,NumOfInstalls,Cost,ExpireDate,PurchaseOrderNum,MRNumber,PurchaseAgent,Owner,OwnerEmail,ActivationWebsite,ContractNumber,Comment")] License license)
        {
            // invalid principal guard
            var parentProductExists = _context.Product.Any(p => p.Id == license.SP_Id);
            if (!parentProductExists)
            {
                TempData["Message"] = "Parent product-Id entered not found, please enter corresponding `product` first.";
            }

            // successful entry
            else if (ModelState.IsValid)
            {
                _context.Add(license);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Entry successfully added!";
                return RedirectToAction(nameof(Index));
            }

            GetProductList();
            return View(license);
        }

        // GET: Licenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.Licence.FindAsync(id);
            if (license == null)
            {
                return NotFound();
            }

            GetProductList();
            return View(license);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SP_Id,Type,Servicer,NumOfInstalls,Cost,ExpireDate,PurchaseOrderNum,MRNumber,PurchaseAgent,Owner,OwnerEmail,ActivationWebsite,ContractNumber,Comment")] License license)
        {
            // invalid principal guard
            var parentProductExists = _context.Product.Any(p => p.Id == license.SP_Id);
            if (!parentProductExists)
            {
                TempData["Message"] = "Parent product-Id entered not found, please enter corresponding `product` first.";
            }

            // successfull edit
            else if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Entry edited successfully!";
                    _context.Update(license);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseExists(license.Id))
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
            return View(license);
        }

        // GET: Licenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.Licence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (license == null)
            {
                return NotFound();
            }

            return View(license);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var license = await _context.Licence.FindAsync(id);
            _context.Licence.Remove(license);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Entry successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        // Utility Functions
        private bool LicenseExists(int id)
        {
            return _context.Licence.Any(e => e.Id == id);
        }

        public void GetProductList()
        {
            ViewBag.ProductSelectList = new SelectList(_context.Product
                .OrderBy(p => p.Id)
                .ToList(), "Id", "Name");
        }
    }
}
