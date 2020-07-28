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
    public class ClientMachinesController : Controller
    {
        private readonly COTSContext _context;

        public ClientMachinesController(COTSContext context)
        {
            _context = context;
        }

        // GET: ClientMachines
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientMachine.ToListAsync());
        }

        // GET: ClientMachines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientMachine = await _context.ClientMachine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientMachine == null)
            {
                return NotFound();
            }

            return View(clientMachine);
        }

        // GET: ClientMachines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientMachines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Owner,ITSecurityPlan,Active")] ClientMachine clientMachine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientMachine);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Entry successfully added!";
                return RedirectToAction(nameof(Index));
            }
            return View(clientMachine);
        }

        // GET: ClientMachines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientMachine = await _context.ClientMachine.FindAsync(id);
            if (clientMachine == null)
            {
                return NotFound();
            }
            return View(clientMachine);
        }

        // POST: ClientMachines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,Owner,ITSecurityPlan,Active")] ClientMachine clientMachine)
        {
            if (id != clientMachine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Message"] = "Entry edited successfully!";
                    _context.Update(clientMachine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientMachineExists(clientMachine.Id))
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
            return View(clientMachine);
        }

        // GET: ClientMachines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientMachine = await _context.ClientMachine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientMachine == null)
            {
                return NotFound();
            }

            return View(clientMachine);
        }

        // POST: ClientMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientMachine = await _context.ClientMachine.FindAsync(id);
            _context.ClientMachine.Remove(clientMachine);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Entry successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        // Utility Function
        private bool ClientMachineExists(int id)
        {
            return _context.ClientMachine.Any(e => e.Id == id);
        }
    }
}
