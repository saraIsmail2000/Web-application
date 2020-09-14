using Social_orm.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Social_orm.Models;

namespace Social_orm.Models
{
    public class Beneficiar 
    {
      
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Place Of Birth")]
        public string PlaceOfBirth { get; set; }
        [Required]
        [Display(Name = "Record Place")]
        public string RecordPlace { get; set; }

        [Required]
        [Display(Name = "Record Number")]
        public int RecordNumber { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string sect { get; set; }

        [Required]
        public bool Insured { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Social Status")]
        public string SocialStatus { get; set; }
        [Required]
        [Display(Name = "Health Status")]
        public string HealthStatus { get; set; }

        [Display(Name = "Handicap Type")]
        public string? HandicapType { get; set; }

        public Address address { get; set; }

        public ICollection<Aid> aids { get; set; }


        public Belongings belongings { get; set;}

        public ICollection<Child> children { get; set; }

        public Disease disease { get; set; }

        public Loans loan { get; set; }

        public SocialHelp socialHelp { get; set; }

        public Wife wife { get; set; }

        public Work work { get; set; }





    }
}
