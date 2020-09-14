using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_orm.Data;
using Social_orm.Models;

namespace Social_orm.Controllers
{
    public class AidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aids
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.aids.Include(a => a.beneficiar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aid = await _context.aids
                .Include(a => a.beneficiar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aid == null)
            {
                return NotFound();
            }

            return View(aid);
        }

        // GET: Aids/Create
        public IActionResult Create()
        {
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName");
            return View();
        }

        // POST: Aids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,type,amount,BeneficiarID")] Aid aid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", aid.BeneficiarID);
            return View(aid);
        }

        public IActionResult Cancel()
        {
            TempData["Field"] = null;
            TempData["Field2"] = null;
            return RedirectToAction("Index", "Aids");
        }

        // GET: Aids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aid = await _context.aids.FindAsync(id);
            if (aid == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", aid.BeneficiarID);
            return View(aid);
        }

        // POST: Aids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,type,amount,BeneficiarID")] Aid aid)
        {
            if (id != aid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AidExists(aid.Id))
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
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", aid.BeneficiarID);
            return View(aid);
        }

        // GET: Aids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aid = await _context.aids
                .Include(a => a.beneficiar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aid == null)
            {
                return NotFound();
            }

            return View(aid);
        }

        // POST: Aids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aid = await _context.aids.FindAsync(id);
            _context.aids.Remove(aid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AidExists(int id)
        {
            return _context.aids.Any(e => e.Id == id);
        }
    }
}
