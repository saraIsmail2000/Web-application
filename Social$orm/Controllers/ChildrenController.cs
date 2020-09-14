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
    public class ChildrenController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static List<Child> children = new List<Child>();

        public ChildrenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Children
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.children.Include(c => c.beneficiar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Children/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.children
                .Include(c => c.beneficiar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        public IActionResult Check([Bind("BeneficiarID")] Child child) {
           // TempData["Bid"] = child.BeneficiarID;
            return View();
        }

        public IActionResult Check2()
        {
            return View();
        }

        public IActionResult Answer1(string submit) {
            //int bid = (int)TempData["Bid"];
            //TempData.Keep();
            if (submit.Equals("Yes"))
            {
                TempData["createChild"] = "create";
                return Redirect("~/Beneficiars/New/AddingInfo/Children");
            }
            else if (submit.Equals("No"))
                return Redirect("~/Beneficiars/New/AddingInfo/Belongings");

            return View();
        }

 

        public IActionResult Answer2(string submit)
        {
            if (submit.Equals("Yes"))
            {
                TempData["check"] = "others";
                TempData["createChild"] = "create";
                return Redirect("~/Beneficiars/New/AddingInfo/Children");
            }
            else if (submit.Equals("No"))
                return Redirect("~/Beneficiars/New/AddingInfo/Belongings");

            return View();
        }


        // GET: Children/Create
        public IActionResult Create(int? Bid)
        {
            if (Bid != null) {
                TempData["NewChild"] = "new";
                ViewBag.Field = "";
                return View();
            }

            if (TempData.Peek("Field") != null) {
                ViewBag.Field = "";
                return View();
            }

            if (TempData["check"] == null)
                TempData["check"] = "first";
            ViewBag.child = TempData["check"].ToString();
            string c = TempData["createChild"] as string;
            ViewBag.create = c;

            //ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName");
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,EducationLevel,EducationalInstitute,yearlyCost,monthlyContribution,Insured,SocialStatus,HealthStatus,HandicapType")] Child child)
        {
            if (ModelState.IsValid)
            {

                //TempData["Children"] = children;
                if (TempData["Field"] != null || TempData["newChild"] != null) {
                    child.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(child);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }

                TempData["Person"] = "Child";

                // CreateModel model = TempData["model"] as CreateModel;
                CreateModel model = TempData.Get<CreateModel>("model");


                model.children.Add(child);
                //TempData["model"] = model;
                TempData.Put<CreateModel>("model", model);

                string n = model.children[model.children.Count - 1].Name;
                TempData["check"] = "others";

                if (child.SocialStatus.Equals("Single"))
                {
                    TempData["Name"] = child.Name;
                    if (child.HealthStatus.Equals("Diseased"))
                    {
                        return Redirect("~/Beneficiars/New/AddingInfo/Child/Diseases");
                    }
                    return Redirect("~/Beneficiars/New/AddingInfo/Child/Works/Create");
                }

                return Redirect("~/Beneficiars/New/AddingInfo/Children");
            }
            //ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", child.BeneficiarID);
            return View(child);
        }

        public IActionResult Cancel()
        {
            TempData["Field"] = null;
            TempData["Field2"] = null;
            TempData["NewChild"] = null;
            return RedirectToAction("ChooseField", "Home");
        }

        public IActionResult Cancel2()
        {
            TempData["Name"] = null;
            return RedirectToAction("Index", "Beneficiars");
        }

        // GET: Children/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.children.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", child.BeneficiarID);
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EducationLevel,EducationalInstitute,yearlyCost,monthlyContribution,Insured,SocialStatus,HealthStatus,HandicapType,BeneficiarID")] Child child)
        {
            if (id != child.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(child);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildExists(child.Id))
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
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", child.BeneficiarID);
            return View(child);
        }

        // GET: Children/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.children
                .Include(c => c.beneficiar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var child = await _context.children.FindAsync(id);
            var child = await _context.children.Where(c => c.Id == id)
                .Include(c => c.work)
                .Include(c => c.disease).FirstOrDefaultAsync();
            if (child.work != null)
            {
                _context.works.Remove(child.work);
                await _context.SaveChangesAsync();

            }
            if (child.disease != null)
            {
                _context.diseases.Remove(child.disease);
                await _context.SaveChangesAsync();
            }
            
            _context.children.Remove(child);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("ChooseField", "Home");
        }

        private bool ChildExists(int id)
        {
            return _context.children.Any(e => e.Id == id);
        }
    }
}
