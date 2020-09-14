using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Social_orm.Data;
using Social_orm.Models;

namespace Social_orm.Controllers
{
    public class WivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wives
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wives.Include(w => w.beneficiar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wife = await _context.Wives
                .Include(w => w.beneficiar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wife == null)
            {
                return NotFound();
            }

            return View(wife);
        }

        // GET: Wives/Create
        public IActionResult Create()
        {
            ViewBag.Name = TempData.Peek("Name"); 
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName");

            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;

            return View();
        }

        // POST: Wives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,DateOfBirth,PlaceOfBirth,Nationality,sect,Insured,PhoneNumber,HealthStatus,HandicapType,BeneficiarID")] Wife wife)
        {
            if (ModelState.IsValid)
            {

                if (TempData["Field"] != null) {
                    wife.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(wife);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }

               // TempData["WifeId"] = wife.Id;
                TempData["Person"] = "Wife";

                //CreateModel model = TempData["model"] as CreateModel;
                CreateModel model = TempData.Get<CreateModel>("model");

                model.wife = wife;
                //TempData["model"] = model;
                TempData.Put<CreateModel>("model", model);

                TempData["Name"] = wife.FullName;

                if (wife.HealthStatus.Equals("Diseased")) {
                    return Redirect("~/Beneficiars/New/AddingInfo/Wife/Diseases");
                }

                return Redirect("~/Beneficiars/New/AddingInfo/Wife/Works");
            }
            //ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", wife.BeneficiarID);
            return View(wife);
        }

        public IActionResult Cancel() {
            TempData["Field"] = null;
            TempData["Field2"] = null;
            return RedirectToAction("ChooseField", "Home");
        }

        public IActionResult Cancel2()
        {
            TempData["Name"] = null;
            return RedirectToAction("Index", "Beneficiars");
        }

        // GET: Wives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wife = await _context.Wives.FindAsync(id);
            if (wife == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", wife.BeneficiarID);
            return View(wife);
        }

        // POST: Wives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,DateOfBirth,PlaceOfBirth,Nationality,sect,Insured,PhoneNumber,HealthStatus,HandicapType,BeneficiarID")] Wife wife)
        {
            if (id != wife.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wife);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WifeExists(wife.Id))
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
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", wife.BeneficiarID);
            return View(wife);
        }

        // GET: Wives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wife = await _context.Wives
                .Include(w => w.beneficiar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wife == null)
            {
                return NotFound();
            }

            return View(wife);
        }

        // POST: Wives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var wife = await _context.Wives.FindAsync(id);
            var wife = await _context.Wives.Where(w=>w.Id==id)
                .Include(w=>w.work)
                .Include(w=> w.disease).FirstOrDefaultAsync();
            if (wife.work != null)
            {
                _context.works.Remove(wife.work);
                await _context.SaveChangesAsync();

            }
            if (wife.disease != null) {
                _context.diseases.Remove(wife.disease);
                await _context.SaveChangesAsync();
            }
            _context.Wives.Remove(wife);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("ChooseField", "Home");
        }

        private bool WifeExists(int id)
        {
            return _context.Wives.Any(e => e.Id == id);
        }
    }
}
