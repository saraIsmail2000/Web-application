using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_orm.Data;
using Social_orm.Models;

namespace Social_orm.Controllers
{
    public class WorksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
            return View(await _context.works.ToListAsync());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.works
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        public IActionResult Check([Bind("BeneficiarID")] Work work)
        {
            //TempData["Person"] = "Child";
            string r = TempData.Peek("Person") as string;
            //TempData["Bid"] = work.BeneficiarID;
            ViewBag.result = r;
            return View();
        }

        

        [HttpPost]
        public IActionResult Work(string beneficiar, string wife , string child)
        {
            //int bid = (int)TempData["Bid"];
            //TempData.Keep();
            if (!string.IsNullOrEmpty(beneficiar))
            {
                if (beneficiar.Equals("Yes"))
                {
                    TempData["create"] = "yes";
                    return Redirect("~/Beneficiars/New/AddingInfo/Works");
                }
                else if (beneficiar.Equals("No"))
                    // return Redirect("~/Beneficiars/Create/" + bid + "/Addresses");
                    return Redirect("~/Beneficiars/New/AddingInfo/Addresses");

            }
            else if (!string.IsNullOrEmpty(wife))
            {
                if (wife.Equals("Yes"))
                {
                    TempData["create"] = "yes";
                    return Redirect("~/Beneficiars/New/AddingInfo/Wife/Works");
                }
                else if (wife.Equals("No"))
                    // return Redirect("~/Beneficiars/Create/" + bid + "/Children");
                    return Redirect("~/Beneficiars/New/AddingInfo/Children");

            }
            else if (!string.IsNullOrEmpty(child))
            {
                if (child.Equals("Yes"))
                {
                    TempData["create"] = "yes";
                    //return Redirect("~/Beneficiars/Create/" + bid + "/Child/Works/Create");
                    return Redirect("~/Beneficiars/New/AddingInfo/Child/Works");
                }
                else if (child.Equals("No"))
                    return Redirect("~/Beneficiars/New/AddingInfo/Children");

            }
            return null;
            //return View();
        }


        // GET: Works/Create
        public IActionResult Create()
        {
            string r = TempData.Peek("Person") as string;
            ViewBag.result = r;
            string c = TempData["create"] as string;
            ViewBag.create = c;

            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;
            string f2 = TempData.Peek("Field2") as string;
            ViewBag.Field = f2;

            ViewBag.Name = TempData.Peek("Name");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sector,TypeOfWork,Salary")] Work work)
        {
            if (ModelState.IsValid)
            {

                //int bid = (int)TempData["Bid"];
                string person = TempData.Peek("Person") as string;

                if (TempData["Field"] != null)
                {
                    work.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(work);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }
                if (TempData["Field2"] != null)
                {
                    if (TempData.Peek("wid") != null) {
                        work.WifeID = (int)TempData["wid"];
                    }
                    else if(TempData.Peek("cid") != null)
                    {
                        work.ChildID = (int)TempData["cid"];
                    }
                    
                    _context.Add(work);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }

                CreateModel model = TempData.Get<CreateModel>("model");
                string s = model.beneficiar.FirstName;
                

                if (person == "Wife")
                {
                    model.wife.work = work;
                    //TempData["model"] = model;
                    TempData.Put<CreateModel>("model", model);
                    return Redirect("~/Beneficiars/New/AddingInfo/Children");
                }

                if (person == "Child")
                {
                    //TempData["ChildWork"] = work;
                    //TempData["model"] = model;

                    model.children[model.children.Count - 1].work = work;
                    string t = model.children[model.children.Count - 1].work.TypeOfWork;
                    TempData.Put<CreateModel>("model", model);
                    return Redirect("~/Beneficiars/New/AddingInfo/Children");
                }

                //work.BeneficiarID = bid;
                //TempData["Work"] = work;

                model.work = work;
                string w = model.work.TypeOfWork;

                TempData.Put<CreateModel>("model", model);
                //TempData["model"] = model;

                int wi = model.work.Id;
                return Redirect("~/Beneficiars/New/AddingInfo/Addresses");
            }
            return View(work);
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

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.works.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", work.BeneficiarID);
            ViewData["ChildID"] = new SelectList(_context.children, "Id", "Name", work.ChildID);
            ViewData["WifeID"] = new SelectList(_context.Wives, "Id", "FullName", work.WifeID);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,sector,TypeOfWork,Salary,BeneficiarID,WifeID,ChildID")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.Id))
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
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.works
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var work = await _context.works.FindAsync(id);
            _context.works.Remove(work);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("ChooseField", "Home");
        }

        private bool WorkExists(int id)
        {
            return _context.works.Any(e => e.Id == id);
        }
    }
}
