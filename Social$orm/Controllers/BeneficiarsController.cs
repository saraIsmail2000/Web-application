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
    public class BeneficiarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        // GET: Beneficiars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beneficiars.Where(b=>b.Id > 0).ToListAsync());
        }

        // GET: Beneficiars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiar = await _context.Beneficiars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiar == null)
            {
                return NotFound();
            }

            return View(beneficiar);
        }

        // GET: Beneficiars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficiars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,DateOfBirth,PlaceOfBirth,RecordPlace,RecordNumber,Nationality,sect,Insured,PhoneNumber,SocialStatus,HealthStatus,HandicapType")] Beneficiar beneficiar)
        {
            if (ModelState.IsValid)
            {

                TempData["Person"] = "Beneficiar";

                TempData["Field"] = null;
                TempData["Field2"] = null;

               // _context.Add(beneficiar);
               // await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));

                TempData["Bid"] = beneficiar.Id;
               // TempData["Beneficiar"] = beneficiar;

                CreateModel createModel = new CreateModel();
                createModel.beneficiar = beneficiar;
                //TempData["model"] = createModel;
                TempData.Put<CreateModel>("model", createModel);

                CreateModel userTemp = TempData.Get<CreateModel>("model");
                string s = userTemp.beneficiar.FirstName;
                TempData["Name"] = beneficiar.FullName;

                if (beneficiar.HealthStatus != null && beneficiar.HealthStatus.Equals("Diseased"))
                    {
                    
                        //return Redirect("~/Beneficiars/Create/" + beneficiar.Id + "/Diseases");
                        return Redirect("~/Beneficiars/New/AddingInfo/Diseases");
                    }

                    //return Redirect("~/Beneficiars/Create/" + beneficiar.Id + "/Works/Check");
                     
                    ///////////////////////////////////////////////////////// /Check
                    return Redirect("~/Beneficiars/New/AddingInfo/Works/Create");

                
            }
            
            return View(beneficiar);
        }

        public IActionResult Cancel()
        {
            TempData["Field"] = null;
            TempData["Field2"] = null;
            return RedirectToAction("ChooseField", "Home");
        }

        // GET: Beneficiars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiar = await _context.Beneficiars.FindAsync(id);
            if (beneficiar == null)
            {
                return NotFound();
            }
            return View(beneficiar);
        }

        // POST: Beneficiars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,DateOfBirth,PlaceOfBirth,RecordPlace,RecordNumber,Nationality,sect,Insured,PhoneNumber,SocialStatus,HealthStatus,HandicapType")] Beneficiar beneficiar)
        {
            if (id != beneficiar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiar);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiarExists(beneficiar.Id))
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
            return View(beneficiar);
        }

        // GET: Beneficiars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiar = await _context.Beneficiars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficiar == null)
            {
                return NotFound();
            }

            return View(beneficiar);
        }

        // POST: Beneficiars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiar = await _context.Beneficiars.FindAsync(id);
            Wife wife = _context.Wives.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if (wife != null)
            {
                Work w1 = _context.works.Where(w => w.WifeID == wife.Id).FirstOrDefault();
                if (w1!=null) _context.works.Remove(w1);
                await _context.SaveChangesAsync();
                Disease d1 = _context.diseases.Where(w => w.WifeID == wife.Id).FirstOrDefault();
                if (d1 != null) _context.diseases.Remove(d1);
                await _context.SaveChangesAsync();

                _context.Wives.Remove(wife);
            }
            Work w = _context.works.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if(w!=null) _context.works.Remove(w);

            Belongings b = _context.belongings.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if(b!=null) _context.belongings.Remove(b);

            Address a = _context.addresses.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if(a!=null) _context.addresses.Remove(a);

            Loans l = _context.loans.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if(l!=null)_context.loans.Remove(l);

            SocialHelp s = _context.socialHelps.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if(s!=null) _context.socialHelps.Remove(s);

            Disease d = _context.diseases.Where(w => w.BeneficiarID == id).FirstOrDefault();
            if(d!=null)_context.diseases.Remove(d);

            List<Child> children = _context.children.Where(c => c.BeneficiarID == id).ToList();
            foreach (Child c in children) {
                Work w2 = _context.works.Where(w => w.ChildID == c.Id).FirstOrDefault();
                if(w2!=null) _context.works.Remove(w2);
                Disease d2 = _context.diseases.Where(w => w.ChildID == c.Id).FirstOrDefault();
                if(d2!=null)_context.diseases.Remove(d2);

                await _context.SaveChangesAsync();
                _context.children.Remove(c);

            }
            await _context.SaveChangesAsync();

            _context.Beneficiars.Remove(beneficiar);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiarExists(int id)
        {
            return _context.Beneficiars.Any(e => e.Id == id);
        }


        public IActionResult AllDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            viewModels mymodel = new viewModels();
            mymodel.beneficiar = _context.Beneficiars.Where(o => o.Id.Equals(id)).FirstOrDefault();
            if (mymodel.beneficiar.HealthStatus != null && mymodel.beneficiar.HealthStatus.Equals("Diseased"))
            {
                mymodel.disease = _context.diseases.Where(d => d.BeneficiarID.Equals(id)).FirstOrDefault();
            }
            if (mymodel.beneficiar.SocialStatus.Equals("Married"))
            {
                mymodel.wife = _context.Wives.Where(w => w.BeneficiarID.Equals(id)).FirstOrDefault();
                if (mymodel.wife != null)
                {
                    int wifeId = mymodel.wife.Id;
                    if (mymodel.wife.HealthStatus.Equals("Diseased"))
                    {
                        mymodel.wife.disease = _context.diseases.Where(dw => dw.WifeID.Equals(wifeId)).FirstOrDefault();
                    }
                    if (mymodel.wife.work != null)
                    {
                        mymodel.wife.work = _context.works.Where(ww => ww.WifeID.Equals(wifeId)).FirstOrDefault();
                    }
                }
                mymodel.children = _context.children.Where(c => c.BeneficiarID.Equals(id)).ToList();
                foreach (Child c in mymodel.children)
                {
                    int childId = c.Id;
                    if (c.HealthStatus.Equals("Diseased"))
                    {
                        c.disease = _context.diseases.Where(cd => cd.ChildID.Equals(childId)).FirstOrDefault();
                    }
                    if (c.work != null)
                    {
                        c.work = _context.works.Where(cw => cw.ChildID.Equals(childId)).FirstOrDefault();
                    }

                }
            }

            mymodel.work = _context.works.Where(wo => wo.BeneficiarID.Equals(id)).FirstOrDefault();
            mymodel.address = _context.addresses.Where(a => a.BeneficiarID.Equals(id)).FirstOrDefault();
            mymodel.belongings = _context.belongings.Where(b => b.BeneficiarID.Equals(id)).FirstOrDefault();
            mymodel.loan = _context.loans.Where(l => l.BeneficiarID.Equals(id)).FirstOrDefault();
            mymodel.socialhelp = _context.socialHelps.Where(s => s.BeneficiarID.Equals(id)).FirstOrDefault();


            return View(mymodel);
        }



        public async Task<IActionResult> PushToDB() {

             CreateModel model = TempData.Get<CreateModel>("model");
            
           // CreateModel model = null;
            string n = model.beneficiar.FirstName;

            //int dw = model.wife.disease.ID;

            _context.Add(model.beneficiar);
            await _context.SaveChangesAsync();
            int B = model.beneficiar.Id;
            if (model.disease != null)
            {
                model.disease.BeneficiarID = B;
                _context.Add(model.disease);
                  await _context.SaveChangesAsync();
            }
            if (model.work != null)
            {
                model.work.BeneficiarID = B;
                _context.Add(model.work);
                await  _context.SaveChangesAsync();
            }
            if (model.wife != null)
            {
                model.wife.BeneficiarID = B;
                _context.Add(model.wife);
                await _context.SaveChangesAsync();
               // int W = model.wife.Id;

                
            }

            model.address.BeneficiarID = B;
            _context.Add(model.address);
            await _context.SaveChangesAsync();
            if (model.loans != null)
            {
                model.loans.BeneficiarID = B;
                _context.Add(model.loans);
                 await _context.SaveChangesAsync();
            }
            if (model.belongings != null)
            {
                string t = model.belongings.rentIncomeType;
                model.belongings.BeneficiarID = B;
                _context.Add(model.belongings);
                 await _context.SaveChangesAsync();
            }
            if (model.SocialHelp != null)
            {
                model.SocialHelp.BeneficiarID = B;
                _context.Add(model.SocialHelp);
                await _context.SaveChangesAsync();
            }
            for (int i = 0; i < model.children.Count; i++) {
                model.children[i].BeneficiarID = B;
                _context.Add(model.children[i]);
                await _context.SaveChangesAsync();                
            }

            
            return Redirect("~/Beneficiars");

        }
    }
}
