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
    public class DiseasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diseases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.diseases.Include(d => d.beneficiar).Include(d => d.child).Include(d => d.wife);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Diseases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.diseases
                .Include(d => d.beneficiar)
                .Include(d => d.child)
                .Include(d => d.wife)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // GET: Diseases/Create
        public IActionResult Create()
        {
            ViewBag.Name = TempData.Peek("Name");
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName");
            ViewData["ChildID"] = new SelectList(_context.children, "Id", "EducationLevel");
            ViewData["WifeID"] = new SelectList(_context.Wives, "Id", "PhoneNumber");

            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;
            string f2 = TempData.Peek("Field2") as string;
            ViewBag.Field = f2;

            return View();
        }

        // POST: Diseases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]                               ///////BeneficiarID,ChildID,WifeID
        public async Task<IActionResult> Create([Bind("DiseaseType,MedicineName,MedicineCost")] Disease disease)
        {

            if (ModelState.IsValid)
            {

                int bid = disease.BeneficiarID;
                string person = TempData.Peek("Person") as string;
                // CreateModel model = TempData["model"] as CreateModel;

                if (TempData["Field"] != null)
                {
                    disease.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(disease);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }
                if (TempData["Field2"] != null)
                {
                    if (TempData.Peek("wid") != null)
                    {
                        disease.WifeID = (int)TempData["wid"];
                    }
                    if (TempData.Peek("cid") != null)
                    {
                        disease.ChildID = (int)TempData["cid"];
                    }

                    _context.Add(disease);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }

                CreateModel model = TempData.Get<CreateModel>("model");



                if (person == "Wife")
                {
                    model.wife.disease = disease;
                    //TempData["model"] = model;
                    string wd = model.wife.disease.DiseaseType;
                    TempData.Put<CreateModel>("model", model);
                    return Redirect("~/Beneficiars/New/AddingInfo/Wife/Works/Create");
                }

                if(person == "Child")
                {
                    
                    //Child child = model.children[model.children.Count-1];

                    model.children[model.children.Count-1].disease = disease;
                    string d =  model.children[model.children.Count - 1].disease.DiseaseType;
                    //TempData["model"] = model;
                    TempData.Put<CreateModel>("model", model);
                    return Redirect("~/Beneficiars/New/AddingInfo/Child/Works");
                }

                // _context.Add(disease);
                // await _context.SaveChangesAsync();

                //TempData["Disease"] = disease;
                
                model.disease = disease;
                string s = model.disease.DiseaseType;
                //TempData["model"] = model;

                TempData.Put<CreateModel>("model", model);

                //return Redirect("~/Beneficiars/Create/" + disease.BeneficiarID + "/Works/Check");
                return Redirect("~/Beneficiars/New/AddingInfo/Works");

            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", disease.BeneficiarID);
            ViewData["ChildID"] = new SelectList(_context.children, "Id", "EducationLevel", disease.ChildID);
            ViewData["WifeID"] = new SelectList(_context.Wives, "Id", "PhoneNumber", disease.WifeID);

            return  View(disease);
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


        // GET: Diseases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", disease.BeneficiarID);
            ViewData["ChildID"] = new SelectList(_context.children, "Id", "Name", disease.ChildID);
            ViewData["WifeID"] = new SelectList(_context.Wives, "Id", "FullName", disease.WifeID);
            return View(disease);
        }

        // POST: Diseases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DiseaseType,MedicineName,MedicineCost,BeneficiarID,WifeID,ChildID")] Disease disease)
        {
            if (id != disease.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseExists(disease.ID))
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
            //ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FirstName", disease.BeneficiarID);
            //ViewData["ChildID"] = new SelectList(_context.children, "Id", "EducationLevel", disease.ChildID);
            //ViewData["WifeID"] = new SelectList(_context.Wives, "Id", "PhoneNumber", disease.WifeID);
            return View(disease);
        }

        // GET: Diseases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.diseases
                .Include(d => d.beneficiar)
                .Include(d => d.child)
                .Include(d => d.wife)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
            //return View("~/Views/Diseases/Create.cshtml");
        }

        // POST: Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disease = await _context.diseases.FindAsync(id);
            _context.diseases.Remove(disease);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("ChooseField", "Home");
        }

        private bool DiseaseExists(int id)
        {
            return _context.diseases.Any(e => e.ID == id);
        }
    }
}
