using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Disease
    {
        
        public int ID { get; set; }

        [Display(Name = "Disease Type")]
        [Required]
        public string DiseaseType { get; set; }

        [Display(Name = "Medicine Name")]
        [Required]
        public string MedicineName { get; set; }

        [Display(Name = "Medicine Cost per month")]
        [Required]
        public int MedicineCost { get; set; }

       // [BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }

        public int ChildID { get; set; }
        public Child child { get; set; }

        public int WifeID { get; set; }
        public Wife wife { get; set; }



    }
}
