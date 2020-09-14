using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Child
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Educational")]
        public string EducationLevel { get; set; }

        [Display(Name = "Educational Institute")]
        public string? EducationalInstitute { get; set; }

        [Display(Name = "Yearly education cost")]
        public int? yearlyCost { get; set; }

        [Display(Name = "Monthly Contributions")]
        public int? monthlyContribution { get; set; }

        public bool Insured { get; set; }

        [Display(Name = "Social Status")]
        [Required]
        public string SocialStatus { get; set; }

        [Display(Name = "Health Status")]
        public string HealthStatus { get; set; }

        [Display(Name = "Handicap Type")]
        public string? HandicapType { get; set; }

        //[BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }

        public Work work { get; set; }

        public Disease disease { get; set; }








    }
}
