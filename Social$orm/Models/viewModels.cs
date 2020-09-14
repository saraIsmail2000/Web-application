using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social_orm.Models
{
    public class viewModels
    {
        public Beneficiar beneficiar { get; set; }
        public Work work { get; set; }
        public Disease disease { get; set; }
        public Wife wife { get; set; }
        public IEnumerable<Child> children { get; set; }
        public Loans loan { get; set; }
        public SocialHelp socialhelp { get; set; }
        public Belongings belongings { get; set; }
        public Address address { get; set; }
    }
}
