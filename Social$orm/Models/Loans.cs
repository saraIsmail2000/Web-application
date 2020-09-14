using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Loans
    {
        
        public int Id { get; set; }
        [Required]
        public string source { get; set; }
        [Required]
        public string reason { get; set; }
        [Required]
        public int amount { get; set; }

        [Display(Name = "Payment Frequency")]
        [Required]
        public string paymentfrequency { get; set; }

        [Display(Name = "Paying Amount")]
        [Required]
        public int paymentvalue { get; set; }

        [Display(Name = "Other debts")]
        public int? OtherDebts { get; set; }


        //[BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }




    }
}
