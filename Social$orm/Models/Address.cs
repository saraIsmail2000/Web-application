using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Location")]
        [Required]
        public string location { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string type { get; set; }

        [Display(Name = "Rent")]
        public string rent { get; set; }


        [Display(Name = "Number of rooms ")]
        [Required]
        public int roomnumber { get; set; }

       
        [NotMapped]
        [BindProperty]
        public List<string> misses  { get; set; }

        [Display(Name = "Missings")]
        public string missings { get; set; }

        //[BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }

    }
}
