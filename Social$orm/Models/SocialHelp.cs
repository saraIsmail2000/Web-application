using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Social_orm.Models
{
    public class SocialHelp
    {
        public int ID { get; set; }

        
        [Display(Name = "Institution")]
        public string InstitutionName { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string type { get; set; }

        [Display(Name = "Duration")]
        [Required]
        public string duration { get; set; }

        [Display(Name = "Amount")]
        [Required]
        public int amount { get; set; }


        //[BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }



    }
}
