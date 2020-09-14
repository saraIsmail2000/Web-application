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
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.addresses.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewBag.Name = TempData.Peek("Name");
            string f = TempData.Peek("Field") as string;
            ViewBag.Field = f;
            
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("location,type,rent,roomnumber,misses")] Address address)
        {
            if (ModelState.IsValid)
            {
                string missings = "";
                if (address.misses != null)
                {
                    for (int i = 0; i < address.misses.Count(); i++)
                        missings += address.misses[i] + ",";
                }

                address.missings = missings;

                if (TempData["Field"] != null)
                {
                    address.BeneficiarID = (int)TempData.Peek("BenId");
                    _context.Add(address);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChooseField", "Home");
                }

                // CreateModel model = TempData["model"] as CreateModel;
                CreateModel model = TempData.Get<CreateModel>("model");

                model.address = address;
                TempData.Put<CreateModel>("model", model);

                // TempData["model"] = model;

                //Beneficiar b = TempData["Beneficiar"] as Beneficiar;

                Beneficiar b = model.beneficiar;
                string n = b.FirstName;
                string a = model.address.location;

                if (b.SocialStatus.Equals("Married") || b.SocialStatus.Equals("Dead"))
                    return Redirect("~/Beneficiars/New/AddingInfo/Wives");

                //else if(b.SocialStatus.Equals("Single"))
                //   return Redirect("~/Beneficiars/New/AddingInfo/Belongings");

                else
                    return Redirect("~/Beneficiars/New/AddingInfo/Children");

            }
            return View(address);
        }

        public IActionResult Cancel()
        {
            TempData["Field"] = null;
            TempData["Field2"] = null;
            return RedirectToAction("ChooseField", "Home");
        }

        public IActionResult Cancel2() {
            TempData["Name"] = null;
            return RedirectToAction("Index", "Beneficiars");
        }


        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName", address.BeneficiarID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,location,type,rent,roomnumber,missings,BeneficiarID")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.addresses.FindAsync(id);
            _context.addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChooseField", "Home");
            // return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.addresses.Any(e => e.Id == id);
        }
    }
}
