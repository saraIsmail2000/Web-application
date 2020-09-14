using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Social_orm.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string sector { get; set; }

        [Display(Name = "Type Of Work")]
        [Required]
        public string TypeOfWork { get; set; }

        [Required]
        public int Salary { get; set; }

        //[BindProperty(Name = "Id", SupportsGet = true)]
        public int BeneficiarID { get; set; }
        public Beneficiar beneficiar { get; set; }

        public int ChildID { get; set; }
        public Child child { get; set; }

        public int WifeID { get; set; }
        public Wife wife { get; set; }
    }
}
