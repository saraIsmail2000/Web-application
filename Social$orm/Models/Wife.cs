using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Wife 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }


        [Required]
        [Display(Name = "Place of birth")]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string sect { get; set; }

        [Required]
        public bool Insured { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
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
