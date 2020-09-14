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
    public class LoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            return View(await _context.loans.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.loans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;

            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("source,reason,amount,paymentfrequency,paymentvalue,OtherDebts")] Loans loans)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(loans);
                // await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (TempData["Field"] != null)
                {
                    loans.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(loans);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }


                CreateModel model = TempData.Get<CreateModel>("model");
                model.loans = loans;
                TempData.Put<CreateModel>("model", model);

                string b = model.loans.paymentfrequency;

                return Redirect("~/Beneficiars/New/AddingInfo/SocialHelps");

            }
            return View(loans);
        }

        public IActionResult Skip()
        {
            return Redirect("~/Beneficiars/New/AddingInfo/SocialHelps");
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

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.loans.FindAsync(id);
            if (loans == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", loans.BeneficiarID);
            return View(loans);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,source,reason,amount,paymentfrequency,paymentvalue,OtherDebts,BeneficiarID")] Loans loans)
        {
            if (id != loans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoansExists(loans.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ChooseField", "Home");
                //return RedirectToAction(nameof(Index));
            }
            return View(loans);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.loans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loans = await _context.loans.FindAsync(id);
            _context.loans.Remove(loans);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChooseField", "Home");
            //return RedirectToAction(nameof(Index));
        }

        private bool LoansExists(int id)
        {
            return _context.loans.Any(e => e.Id == id);
        }
    }
}
