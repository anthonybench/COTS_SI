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
    public class InstallsController : Controller
    {
        private readonly COTSContext _context;

        public InstallsController(COTSContext context)
        {
            _context = context;
        }

        // GET: Installs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Installs.ToListAsync());
        }

        // GET: Installs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var install = await _context.Installs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (install == null)
            {
                return NotFound();
            }

            return View(install);
        }

        // GET: Installs/Create
        public IActionResult Create()
        {
            GetClientMachineList();
            GetLicenseList();
            return View();
        }

        // POST: Installs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CM_Id,SL_Id,SerialNumber,Comment")] Install install)
        {
            // invalid principal guard
            var parentMachineExists = _context.ClientMachines.Any(cm => cm.Id == install.CM_Id);
            var parentLicenseExists = _context.Licenses.Any(l => l.Id == install.SL_Id);
            if (!parentMachineExists)
            {
                TempData["Message"] = "Parent machine-Id entered not found, please enter corresponding `client machine` first.";
            }
            else if (!parentLicenseExists)
            {
                TempData["Message"] = "Parent license-Id entered not found, please enter corresponding `license` first.";
            }

            // successful entry
            else if (ModelState.IsValid)
            {
                _context.Add(install);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Entry successfully added!";
                return RedirectToAction(nameof(Index));
            }

            GetClientMachineList();
            GetLicenseList();
            return View(install);
        }

        // GET: Installs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var install = await _context.Installs.FindAsync(id);
            if (install == null)
            {
                return NotFound();
            }

            GetClientMachineList();
            GetLicenseList();
            return View(install);
        }

        // POST: Installs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CM_Id,SL_Id,SerialNumber,Comment")] Install install)
        {
            // invalid principal guard
            var parentMachineExists = _context.ClientMachines.Any(cm => cm.Id == install.CM_Id);
            var parentLicenseExists = _context.Licenses.Any(l => l.Id == install.SL_Id);
            if (!parentMachineExists)
            {
                TempData["Message"] = "Parent machine-Id entered not found, please enter corresponding `client machine` first.";
            }
            else if (!parentLicenseExists)
            {
                TempData["Message"] = "Parent license-Id entered not found, please enter corresponding `license` first.";
            }

            // successful edit
            else if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Entry edited successfully!";
                    _context.Update(install);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstallExists(install.Id))
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

            GetClientMachineList();
            GetLicenseList();
            return View(install);
        }

        // GET: Installs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var install = await _context.Installs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (install == null)
            {
                return NotFound();
            }

            return View(install);
        }

        // POST: Installs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var install = await _context.Installs.FindAsync(id);
            _context.Installs.Remove(install);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Entry successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        // Utility Functions
        private bool InstallExists(int id)
        {
            return _context.Installs.Any(e => e.Id == id);
        }

        public void GetClientMachineList()
        {
            ViewBag.ClientMachineSelectList = new SelectList(_context.ClientMachines
                .OrderBy(cm => cm.Id)
                .ToList(), "Id", "Name");
        }

        public void GetLicenseList()
        {
            ViewBag.LicenseSelectList = new SelectList(_context.Licenses
                .OrderBy(l => l.Id)
                .ToList(), "Id", "Id");
        }
    }
}
