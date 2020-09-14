using Microsoft.AspNetCore.Mvc.Rendering;
using Social_orm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_orm.ViewModel
{
    public class SpecialFormForAFamily
    {
        [Display(Name = "Beneficiary Name")]
        public string BeneficiarName { get; set; }

        [Display(Name = "Id")]
        public int BeneficiarId { get; set; }
        public Beneficiar beneficiar { get; set; }
        public IEnumerable<SelectListItem> AllBeneficiars { get; set; }

        [Display(Name = "Family Members")]
        public int TotalNbOfFamily { get; set; }

        [Display(Name = "Family Workers")]
        public int TotalFamilyWorkers { get; set; }

        [Display(Name = "Number Of Rooms")]
        public int TotalNbofRooms { get; set; }

        [Display(Name = "Total Month Income")]
        public int TotalMonthIncome { get; set; }

        [Display(Name = "School Students")]
        public int TotalNbofStudents { get; set; }

        [Display(Name = "University Students")]
        public int TotalNbOfstudInUni { get; set; }

        [Display(Name = "Home Rent")]
        public string HomeRent { get; set; }
        public int Diseases { get; set; }

        [Display(Name = "Job Type")]
        public string JobType { get; set; }

        [Display(Name = "Number Of Diseases And Handicaps")]
        public int NbDiseaseAndHandicap { get; set; }

        [Display(Name = "Total Rate")]
        public double totalRate { get; set; }







    }
}
