using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Social_orm.Data;
using Social_orm.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
//using Syncfusion.HtmlConverter;

namespace Social_orm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext  _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Beneficiars = _context.Beneficiars.ToListAsync();
            return View();
        }

        public IActionResult ChooseBeneficiary() {
            
            ViewData["BeneficiarID"] = new SelectList(_context.Beneficiars, "Id", "FullName");
            return View();
        }

        //public IActionResult EditBeneficiary(int? BeneficiarID) {
        //    if (BeneficiarID == null) BeneficiarID = (int)TempData.Peek("BenId");
        //    TempData["BenId"] = BeneficiarID;
        //    Beneficiar b = _context.Beneficiars.Where(b => b.Id == BeneficiarID).FirstOrDefault();
        //    TempData["Name"] = b.FullName;
        //    ViewData["Name"] += b.FullName;
        //    //CreateModel model = new CreateModel();
        //    //model.beneficiar = b;

        //    b.wife = _context.Wives.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault();            
        //    b.wife.disease = _context.diseases.Where(d => d.WifeID == b.wife.Id).FirstOrDefault();
        //    b.wife.work = _context.works.Where(w => w.WifeID == b.wife.Id).FirstOrDefault();
        //    b.work = _context.works.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault();
        //    b.disease = _context.diseases.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault();
        //    b.address = _context.addresses.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault();
        //    b.loan = _context.loans.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault();
        //    b.belongings = _context.belongings.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault();
        //    b.socialHelp = _context.socialHelps.Where(b => b.BeneficiarID == BeneficiarID).FirstOrDefault(); ;


        //    return View(b);
        //}

        public IActionResult ChooseField(int? BeneficiarID) {
            if (BeneficiarID == null) BeneficiarID = (int)TempData.Peek("BenId");
            TempData["BenId"] = BeneficiarID;
            Beneficiar b = _context.Beneficiars.Where(b => b.Id == BeneficiarID).FirstOrDefault();
            TempData["Name"] = b.FullName;
            ViewData["Name"] += b.FullName;
            return View();
        }

       
        public IActionResult Edit(string Field) {
            int Bid =(int) TempData.Peek("BenId") ;
            string url = "~/" + Field + "/Edit/";
            TempData["F"] = Field;
            if (Field.Equals("Beneficiars"))
            {
                var O = _context.Beneficiars.Where(b => b.Id == Bid).FirstOrDefault();
                
                url += O.Id;
            }

            else if (Field.Equals("Wives"))
            {
                Wife wife = _context.Wives.Where(b => b.BeneficiarID == Bid).FirstOrDefault();
                if (wife == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                //CreateModel model = new CreateModel();
                //model.wife = wife;
                //int wid = wife.Id;
                //Disease disease = _context.diseases.Where(d => d.WifeID == wid).FirstOrDefault();
                //if (disease != null) model.disease = disease;
                //Work work = _context.works.Where(w => w.WifeID == wid).FirstOrDefault();
                //if (work != null) model.work = work;
                //string d = model.disease.DiseaseType;
                //string w = model.work.TypeOfWork;
                //model.disease = new Disease();
                //model.wife.work = new Work();

                //TempData.Put<CreateModel>("wife", model);
                int Wid = wife.Id;
                
                
                return RedirectToAction("WifeInfo", "Home", new { Wid });
                
                 //   url += O.Id;
            }
            else if (Field.Equals("Children"))
            {
               List<Child> children = _context.children.Where(b => b.BeneficiarID == Bid).ToList();
                if (children.Count() == 0)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                //foreach (Child c in children) {
                //    Disease disease = _context.diseases.Where(d => d.ChildID == c.Id).FirstOrDefault();
                //    if (disease != null) c.disease = disease;
                //    Work work = _context.works.Where(w => w.ChildID == c.Id).FirstOrDefault();
                //    if (work != null) c.work = work;
                //}
                //var myChildren = _context.children.Include(c => c.BeneficiarID == Bid);

                return RedirectToAction("ChildrenInfo", "Home", new { Bid });
                //url += O.Id;
            }

            else if (Field.Equals("Diseases"))
            {
                var O = _context.diseases.Where(b => b.BeneficiarID == Bid).FirstOrDefault();
                if (O == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                url += O.ID;
            }
            else if (Field.Equals("Addresses"))
            {
                var O = _context.addresses.Where(b => b.BeneficiarID == Bid).FirstOrDefault();
                if (O == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                url += O.Id;
            }
            else if (Field.Equals("Loans"))
            {
                var O = _context.loans.Where(b => b.BeneficiarID == Bid).FirstOrDefault();
                if (O == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                url += O.Id;
            }
            else if (Field.Equals("Belongings"))
            {
                var O = _context.belongings.Where(b => b.BeneficiarID == Bid).FirstOrDefault();
                if (O == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                url += O.Id;
            }
            else if (Field.Equals("Works"))
            {
                var O = _context.works.Where(b => b.BeneficiarID == Bid).FirstOrDefault();
                if (O == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                url += O.Id;
            }
            else if (Field.Equals("SocialHelps"))
            {
                var O = _context.socialHelps.Where(b => b.BeneficiarID == Bid).FirstOrDefault(); 
                if (O == null)
                {
                    return RedirectToAction("Notfound", "Home");
                }
                url += O.ID;
            }

            return Redirect(url);

        }

        public IActionResult Notfound() {
            ViewBag.Name = TempData.Peek("Name").ToString();
            ViewBag.Field = TempData.Peek("Field") as string;
            return View();
        }

        public IActionResult Back() {
           return RedirectToAction("ChooseField", "Home");
        }

        public IActionResult Back2() {
            return RedirectToAction("ChooseBeneficiary", "Home");
        }

        public IActionResult CreateField() {
            TempData["Field"] = "create";
            TempData["Field2"] = null;
            return RedirectToAction("Create", TempData.Peek("F").ToString());
        }

        public IActionResult NewChild()
        {   
            int Bid = (int)TempData.Peek("BenId");
            return RedirectToAction("Create", "Children", new { Bid });
        }

        public IActionResult WifeInfo(int Wid) {
            //int id = wife.Id;
            Wife wife = _context.Wives.Where(b => b.Id == Wid).FirstOrDefault();
            Disease disease = _context.diseases.Where(d => d.WifeID == Wid).FirstOrDefault();
            if (disease != null) wife.disease = disease;
            Work work = _context.works.Where(w => w.WifeID == Wid).FirstOrDefault();
            if (work != null) wife.work = work;

            ViewBag.Name = TempData.Peek("Name").ToString();
            return View(wife);
        }

        
        public IActionResult ChildrenInfo(int Bid)
        {
            
            List<Child> children = _context.children.Where(b => b.BeneficiarID == Bid).ToList();
            foreach (Child c in children)
            {
                Disease disease = _context.diseases.Where(d => d.ChildID == c.Id).FirstOrDefault();
                if (disease != null) c.disease = disease;
                Work work = _context.works.Where(w => w.ChildID == c.Id).FirstOrDefault();
                if (work != null) c.work = work;
            }

            ViewBag.Name = TempData.Peek("Name").ToString();
            return View(children);
        }

        [HttpPost]
        public IActionResult AddWD(string WifeWork, string WifeDisease , string ChildWork , string ChildDisease) {
            TempData["Field"] = null;
            TempData["wid"] = null;
            TempData["cid"] = null;
            if (!string.IsNullOrEmpty(WifeWork))
            {
                int wid = Int32.Parse(WifeWork);
                TempData["Field2"] = "create";
                TempData["wid"] = wid;
                return RedirectToAction("Create", "Works");
            }
            else if (!string.IsNullOrEmpty(WifeDisease)) {
                int wid = Int32.Parse(WifeDisease);
                TempData["Field2"] = "create";
                TempData["wid"] = wid;
                return RedirectToAction("Create", "Diseases");
            }
            else if (!string.IsNullOrEmpty(ChildWork))
            {
                int cid = Int32.Parse(ChildWork);
                TempData["Field2"] = "create";
                TempData["cid"] = cid;
                return RedirectToAction("Create", "Works");
            }
            else if (!string.IsNullOrEmpty(ChildDisease))
            {
                int cid = Int32.Parse(ChildDisease);
                TempData["Field2"] = "create";
                TempData["cid"] = cid;
                return RedirectToAction("Create", "Diseases");
            }
            return null;
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateDocument() {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
            
            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
        }
    }
}
