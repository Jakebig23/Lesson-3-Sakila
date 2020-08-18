using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sakila.Models;

namespace Sakila.Controllers
{
    public class StaffsController : Controller
    {
        private readonly SakilaContext _context;

        public StaffsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            var sakilaContext = _context.Staff.Include(s => s.Address).Include(s => s.Store);
            return View(await sakilaContext.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Address)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "Address1");
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,FirstName,LastName,AddressId,Picture,Email,StoreId,Active,Username,Password,LastUpdate")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "Address1", staff.AddressId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId", staff.StoreId);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "Address1", staff.AddressId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId", staff.StoreId);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("StaffId,FirstName,LastName,AddressId,Picture,Email,StoreId,Active,Username,Password,LastUpdate")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "AddressId", "Address1", staff.AddressId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "StoreId", staff.StoreId);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Address)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var staff = await _context.Staff.FindAsync(id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(byte id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }
    }
}
