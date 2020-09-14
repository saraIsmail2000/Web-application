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
    public class SocialHelpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialHelpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialHelps
        public async Task<IActionResult> Index()
        {
            return View(await _context.socialHelps.ToListAsync());
        }

        // GET: SocialHelps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialHelp = await _context.socialHelps
                .FirstOrDefaultAsync(m => m.ID == id);
            if (socialHelp == null)
            {
                return NotFound();
            }

            return View(socialHelp);
        }

        // GET: SocialHelps/Create
        public IActionResult Create()
        {
            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;
            
            return View();
        }

        // POST: SocialHelps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutionName,type,duration,amount")] SocialHelp socialHelp)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(socialHelp);
                // await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (TempData["Field"] != null)
                {
                    socialHelp.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(socialHelp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }


                CreateModel model = TempData.Get<CreateModel>("model");
                model.SocialHelp = socialHelp;
                TempData.Put<CreateModel>("model", model);

                string b = model.SocialHelp.duration;

                return Redirect("~/Beneficiars/PushToDB");
            }
            return View(socialHelp);
        }

        public IActionResult Skip()
        {
            return Redirect("~/Beneficiars/PushToDB");
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

        // GET: SocialHelps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialHelp = await _context.socialHelps.FindAsync(id);
            if (socialHelp == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", socialHelp.BeneficiarID);
            return View(socialHelp);
        }

        // POST: SocialHelps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,InstitutionName,type,duration,amount,BeneficiarID")] SocialHelp socialHelp)
        {
            if (id != socialHelp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialHelp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialHelpExists(socialHelp.ID))
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
            return View(socialHelp);
        }

        // GET: SocialHelps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialHelp = await _context.socialHelps
                .FirstOrDefaultAsync(m => m.ID == id);
            if (socialHelp == null)
            {
                return NotFound();
            }

            return View(socialHelp);
        }

        // POST: SocialHelps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialHelp = await _context.socialHelps.FindAsync(id);
            _context.socialHelps.Remove(socialHelp);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChooseField", "Home");
            //return RedirectToAction(nameof(Index));
        }

        private bool SocialHelpExists(int id)
        {
            return _context.socialHelps.Any(e => e.ID == id);
        }
    }
}
