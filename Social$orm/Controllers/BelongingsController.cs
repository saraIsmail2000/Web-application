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
    public class BelongingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BelongingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Belongings
        public async Task<IActionResult> Index()
        {
            return View(await _context.belongings.ToListAsync());
        }

        // GET: Belongings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belongings = await _context.belongings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (belongings == null)
            {
                return NotFound();
            }

            return View(belongings);
        }

        // GET: Belongings/Create
        public IActionResult Create()
        {
            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;
            return View();
        }

        // POST: Belongings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cars,houses,lands,rentIncomeType,rentIncomeAmount")] Belongings belongings)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(belongings);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                if (TempData["Field"] != null)
                {
                    belongings.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(belongings);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }

                CreateModel model = TempData.Get<CreateModel>("model");
                model.belongings = belongings;
                TempData.Put<CreateModel>("model", model);

                string b = model.belongings.rentIncomeType;

                return Redirect("~/Beneficiars/New/AddingInfo/Loans");
            }
            return View(belongings);
        }

        public IActionResult Skip() {
            return Redirect("~/Beneficiars/New/AddingInfo/Loans");
        }

        public IActionResult Cancel()
        {
            TempData["Field"] = null;
            TempData["Field2"] = null;
            return RedirectToAction("ChooseField", "Home");
        }

        public IActionResult Cancel2()
        {
            TempData["Name"] = null;
            return RedirectToAction("Index", "Beneficiars");
        }

        // GET: Belongings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belongings = await _context.belongings.FindAsync(id);
            if (belongings == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", belongings.BeneficiarID);
            return View(belongings);
        }

        // POST: Belongings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,cars,houses,lands,rentIncomeType,rentIncomeAmount,BeneficiarID")] Belongings belongings)
        {
            if (id != belongings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(belongings);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BelongingsExists(belongings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ChooseField", "Home");
                // return RedirectToAction(nameof(Index));
            }
            return View(belongings);
        }

        // GET: Belongings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belongings = await _context.belongings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (belongings == null)
            {
                return NotFound();
            }

            return View(belongings);
        }

        // POST: Belongings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var belongings = await _context.belongings.FindAsync(id);
            _context.belongings.Remove(belongings);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("ChooseField", "Home");
        }

        private bool BelongingsExists(int id)
        {
            return _context.belongings.Any(e => e.Id == id);
        }
    }
}
