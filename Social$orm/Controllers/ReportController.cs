using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Social_orm.Controllers;
using Social_orm.Data;
using Social_orm.Models;
using Social_orm.ViewModel;


namespace Social_orm.Controllers
{
    public class ReportController : Controller
    {

        private readonly ApplicationDbContext _context;

        // GET: Report
        public ReportController(ApplicationDbContext _context)
        {
            this._context = _context;

        }
        ///////////////////////////////////////////////////////////
        public ActionResult FamilyReports()
        {
            var beneficiars = _context.Beneficiars.Where(b => b.Id > 0).ToList();
            List<SpecialFormForAFamily> AllReports = new List<SpecialFormForAFamily>();
            foreach (var model in beneficiars)
            {
                var form = new SpecialFormForAFamily
                {

                    BeneficiarName = model.FullName,
                    BeneficiarId = model.Id,
                    HomeRent = HomeRent(model.Id),
                    TotalNbOfFamily = NbOfFamilyMembers(model.Id),
                    TotalNbofStudents = NbOfChildrenInSchool(model.Id),
                    TotalNbOfstudInUni = NbOfChildrenInUni(model.Id),
                    TotalNbofRooms = TotalnbOfRooms(model.Id),
                    TotalFamilyWorkers = NbOfWorkersInAFamily(model.Id),
                    TotalMonthIncome = TotalMonthIncome(model.Id),
                    JobType = TypeOfWork(model.Id),
                    NbDiseaseAndHandicap = NbOfDiseasesAndHandicap(model.Id),
                    totalRate = totalRate(model.Id)

                };
                AllReports.Add(form);
            }
            return View(AllReports);
        }
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SpecialFormForAFamily()
        {

            var AllBeneficiars = _context.Beneficiars.Where(b => b.Id > 0).ToList();
            var BeneficiarItems = AllBeneficiars.Select(q => new SelectListItem
            {
                Text = q.FullName,
                Value = q.Id.ToString()
            });
            var model = new SpecialFormForAFamily
            {
                AllBeneficiars = BeneficiarItems
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SpecialFormForAFamily(SpecialFormForAFamily model)
        {
            var AllBeneficiars = _context.Beneficiars.Where(b => b.Id > 0).ToList();
            var BeneficiarItems = AllBeneficiars.Select(q => new SelectListItem
            {
                Text = q.FullName,
                Value = q.Id.ToString()
            });
            var b = new SpecialFormForAFamily
            {

                AllBeneficiars = BeneficiarItems
            };
            if (!ModelState.IsValid)
            {
                return View(b);
            }
            var form = new SpecialFormForAFamily
            {
                HomeRent = HomeRent(model.BeneficiarId),
                AllBeneficiars = BeneficiarItems,
                BeneficiarId = model.BeneficiarId,
                TotalNbOfFamily = NbOfFamilyMembers(model.BeneficiarId),
                TotalNbofStudents = NbOfChildrenInSchool(model.BeneficiarId),
                TotalNbOfstudInUni = NbOfChildrenInUni(model.BeneficiarId),
                TotalNbofRooms = TotalnbOfRooms(model.BeneficiarId),
                TotalFamilyWorkers = NbOfWorkersInAFamily(model.BeneficiarId),
                TotalMonthIncome = TotalMonthIncome(model.BeneficiarId),
                JobType = TypeOfWork(model.BeneficiarId),
                NbDiseaseAndHandicap = NbOfDiseasesAndHandicap(model.BeneficiarId),
                totalRate = totalRate(model.BeneficiarId)
            };

            return View(form);
        }
        public bool isInsured(int id)
        {
            var beneficar = _context.Beneficiars.Where(q => q.Id == id).FirstOrDefault();
            return beneficar.Insured;


        }
        public string TypeOfWork(int id)
        {
            var beneficar = _context.Beneficiars.Where(q => q.Id == id)
                  .Include(q => q.work).FirstOrDefault();
            if (beneficar.work != null)
                return beneficar.work.sector;
            else return "";

        }
        public int NbOfDiseasesAndHandicap(int id)
        {
            int NbDiseases = 0;
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id).Where(b => b.Id > 0)
                .Include(q => q.wife)
                .Include(q => q.children)
                .FirstOrDefault();
            if (beneficiar.HealthStatus.Equals("Handicaped") || beneficiar.HealthStatus.Equals("Diseased"))
            {
                NbDiseases += 1;
            }
            if (beneficiar.wife != null)
            {
                if (beneficiar.wife.HealthStatus.Equals("Handicaped") || beneficiar.wife.HealthStatus.Equals("Diseased"))
                {
                    NbDiseases += 1;
                }
            }
            var alldiseaseschildren = beneficiar.children.Where(q => q.HealthStatus.Equals("Handicaped") || q.HealthStatus.Equals("Diseased")).Count();
            NbDiseases += alldiseaseschildren;
            return NbDiseases;
        }

        public string HomeRent(int id)
        {
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id).Where(b => b.Id > 0)
                .Include(q => q.address)
                .FirstOrDefault();
            if (beneficiar.address == null) return "No";
            string rent = beneficiar.address.rent;
            if (rent == null) return "No";
            return beneficiar.address.rent;
        }

        public int NbOfFamilyMembers(int id)
        {
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id)
                .Include(q => q.wife)
                .Include(q => q.children)
                .FirstOrDefault();
            if (beneficiar.SocialStatus.Equals("Single"))
            {
                return 1;
            }
            if (beneficiar.SocialStatus.Equals("Married"))
            {
                var nbOfFamilyMembers = beneficiar.children.Count() + 2;
                return nbOfFamilyMembers;
            }
            if (beneficiar.SocialStatus.Equals("Divorced") || beneficiar.SocialStatus.Equals("Widowed") || beneficiar.SocialStatus.Equals("Dead"))
            {
                var nbOfFamilyMembers = beneficiar.children.Count() + 1;
                return nbOfFamilyMembers;
            }
            return 1;
        }

        /// ////////////////////////////////////////////////////////////////////
        // get nb of children in school
        public int NbOfChildrenInSchool(int id)
        {
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id)
                .Include(q => q.children)
                .FirstOrDefault();

            var nbofChildrenInschool = beneficiar.children.Where(q => q.EducationLevel.Equals("school")).Count();
            return nbofChildrenInschool;
        }

        /// ///////////////////////////////////////////////////////////////////////

        public int NbOfChildrenInUni(int id)
        {
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id)
                .Include(q => q.children)
                .FirstOrDefault();

            var nbofChildrenInUni = beneficiar.children.Where(q => q.EducationLevel.Equals("university")).Count();
            return nbofChildrenInUni;
        }
        /// ////////////////////////////////////////////////////////////////////////
        public int TotalnbOfRooms(int id)
        {
            var nb = 1;
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id)
                .Include(q => q.address)
                .FirstOrDefault();
            if (beneficiar.address != null)
            {
                nb = beneficiar.address.roomnumber;
            }
            return nb;
        }
        ///////////////////////////////////////////////////////////////////////////////
        public int NbOfWorkersInAFamily(int id)
        {
            var nb = 0;
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id)
                .Include(q => q.work)
                .Include(q => q.children)
                .ThenInclude(q => q.work)
                .Include(q => q.wife)
                .ThenInclude(q => q.work)

                .FirstOrDefault();
            if (beneficiar.work != null)
            {
                nb += 1;
            }
            if (beneficiar.wife != null)
                if (beneficiar.wife.work != null)
                    nb += 1;

            nb += beneficiar.children.Where(c => c.work != null).Count();


            return nb;
        }
        /////////////////////////////////////////////////////////////////////////
        public int TotalMonthIncome(int id)
        {
            var salary = 0;
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id)
                .Include(q => q.work)
                .Include(q => q.children)
                .ThenInclude(q => q.work)
                .Include(q => q.wife)
                .ThenInclude(q => q.work)

                .FirstOrDefault();
            if (beneficiar.work != null)
            {
                salary += beneficiar.work.Salary;
            }
            if (beneficiar.wife != null)
                if (beneficiar.wife.work != null)
                    salary += beneficiar.wife.work.Salary;

            var allworkingChildren = beneficiar.children.Where(q => q.work != null).ToList();

            foreach (var item in allworkingChildren)
            {
                if(item.monthlyContribution != null)
                    salary += (int)item.monthlyContribution;
            }

            return salary;
        }
        public double HealthRate(int id)
        {
            var beneficiar = _context.Beneficiars.Where(q => q.Id == id).FirstOrDefault();

            double r1 = 0, r2 = 0, totalRate = 0;

            int nbDiseasesAndHandicap = NbOfDiseasesAndHandicap(id);

            bool insured = isInsured(id);
            if (nbDiseasesAndHandicap == 0)
            {
                r1 = 10;
            }
            else
            {
                if (nbDiseasesAndHandicap == 1)
                {
                    r1 = 5;
                }
                else
                {
                    if (nbDiseasesAndHandicap > 1)
                    {
                        r1 = 0;
                    }
                }
            }
            if (insured.Equals("true"))
            {
                r2 = 10;
            }
            else
            {
                r2 = 0;
            }

            totalRate = (r1 + r2 * 3) / 4;
            return totalRate;
        }


        public double livingRate(int id)
        {
            double totalRate = 0;
            double r2 = 0;
            double r = 0;
            double r1 = 0;

            int familyMembers = NbOfFamilyMembers(id);
            int roomNumber = TotalnbOfRooms(id);

            r2 = (familyMembers / roomNumber) * 1.0;

            if (!HomeRent(id).Equals("No"))  
            {
                r1 = 4;
                r1 = r1 * 2;
            }
            else
            {
                r1 = 10;
                r1 = r1 * 2;

            }
            if (r2 < 0.5)
            {
                r = r2 * 2;
            }
            else
            {
                r = 10;
            }
            totalRate = (r1 + r) / 3;
            return totalRate;
        }

        public double EducationRate(int id)
        {
            int nbOfChildrenInUni = NbOfChildrenInUni(id);
            int nbOfChildrenInSchool = NbOfChildrenInSchool(id);
            if (nbOfChildrenInSchool == 0 && nbOfChildrenInUni == 0)
            {
                return 10;
            }
            else
            {
                return (10 - (nbOfChildrenInSchool * 2 + nbOfChildrenInUni * 3));
            }
        }
        public double WorkingRate(int id)
        {
            double rate = 1;
            string typeWork = TypeOfWork(id);
            //if (typeWork == null) return 1;
            if (typeWork.Equals("حر"))
            {
                rate = 8;
            }
            else
            {
                if (typeWork.Equals("متقطع"))
                {
                    rate = 5;
                }
                else
                {
                    rate = 10;
                }
            }
            return rate;
        }
        public double EconomicRate(int id)
        {
            double P26 = 0, S26 = 0;
            double R26 = 0;
            double Q26 = 0;
            double O26 = 0;
            double x = 0, Q = 0, y = 0;
            string homeRent = HomeRent(id);
            int rooms = TotalnbOfRooms(id);
            int totalIncome = TotalMonthIncome(id);
            int nbOfWorkingInFamily = NbOfWorkersInAFamily(id);
            int nbOfFamily = NbOfFamilyMembers(id);
            if (nbOfWorkingInFamily == 0)
            {
                R26 = 0;
            }
            else
            {
                if (nbOfFamily / nbOfWorkingInFamily <= 5)
                {
                    R26 = 7;
                }
                else
                {
                    R26 = 5;
                }
            }
            Q26 = (totalIncome / nbOfFamily) / 30;
            O26 = nbOfFamily / rooms;

            if (!homeRent.Equals("No")) // homeRent.Equals("Rent")
            {
                x = 4 * 2;
            }
            else
            {
                x = 10 * 2;
            }
            if (O26 < 0.5)
            {
                y = O26 * 2;
            }
            else
            {
                if (O26 == 0.5)
                {
                    y = 10;
                }
                else
                {
                    y = 10;
                }
            }
            P26 = x + y / 3;

            if (Q26 < 7000)
            {
                Q = 0;
            }
            else
            {
                if (P26 < 10000)
                {
                    Q = 7;
                }
                else
                {
                    if (P26 < 15000)
                    {
                        Q = 10;
                    }
                    else
                    {
                        Q = 12;
                    }
                }
            }
            S26 = (Q * 3 + R26) / 4;
            return S26;
        }
        public double totalRate(int id)
        {
            double total = 0.0;
            double N26 = HealthRate(id);
            double P26 = livingRate(id);
            double S26 = EconomicRate(id);
            double T26 = EducationRate(id);
            double U26 = WorkingRate(id);
            total = (N26 + P26 / 2 + S26 * 3 + T26 / 2 + U26) / 5;
            return total;
        }




        //    ///nb of children under 25
        //    public ActionResult PieEducationAverage()
        //    {
        //        int totalChildren = 0;
        //        int totalWorkingChildren = 0;
        //        int nonWorkingChildren = 0;
        //        int totalChildrenInSchool = 0;
        //        int totalChildrenInUni = 0;
        //        var beneficiars = _context.Beneficiars
        //            .Include(q => q.children)
        //            .ThenInclude(q => q.work)
        //            .ToList();
        //        foreach (var item in beneficiars)
        //        {
        //            int nbOfChildren = item.children.Count();
        //            int nbOfWorkingChildren = item.children.Where(q => q.work != null).Count();
        //            int nbOfChildrenInSchool = item.children.Where(q => q.EducationLevel.Equals("School")).Count();
        //            int nbOfChildrenInUniversity = item.children.Where(q => q.EducationLevel.Equals("University")).Count();
        //            totalChildrenInSchool += nbOfChildrenInSchool;
        //            totalChildrenInUni += nbOfChildrenInUniversity;
        //            totalWorkingChildren += nbOfWorkingChildren;
        //            totalChildren += nbOfChildren;
        //        }
        //        nonWorkingChildren = totalChildren - totalWorkingChildren;
        //        var pie = new PieEducationViewModel
        //        {
        //            totalChildren = totalChildren,
        //            totalWorkingChildren = (totalWorkingChildren / totalChildren) * 100,
        //            nonWorkingChildren = (nonWorkingChildren / totalChildren) * 100,
        //            totalChildrenInSchool = (totalChildrenInSchool / (totalChildrenInSchool + totalChildrenInUni)) * 100,
        //            totalChildrenInUni = (totalChildrenInUni / (totalChildrenInSchool + totalChildrenInUni)) * 100
        //        };

        //        return View(pie);
        //    }

        //}

    }
}















    