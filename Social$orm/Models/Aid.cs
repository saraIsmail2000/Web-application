using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Social_orm.Models
{
    public class Aid
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; }

        public string type { get; set; }

        public int amount { get; set; }

        public int BeneficiarID { get; set; }

        public Beneficiar beneficiar { get; set; }

    }
}
