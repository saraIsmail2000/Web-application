using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Belongings
    {
        [Key]
        public int Id { get; set; }
        
        public int  cars { get; set; }
        
        public int houses { get; set; }
        
        public int lands { get; set; }


        [Display(Name = "Rentings")]
        public string? rentIncomeType { get; set; } //EZA FE SHI M2AJAR

        [Display(Name = "Total Income")]
        public int? rentIncomeAmount { get; set; }


        //[BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }







    }
}
