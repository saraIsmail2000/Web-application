using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Social_orm.Models
{
    public class CreateModel
    {

        public Beneficiar beneficiar { get; set; }
        public Disease disease { get; set; }
        public Work work { get; set; }
        public Address address { get; set; }
        public Wife wife { get; set; }
        public List<Child> children { get; set; } = new List<Child>();
        public Belongings belongings { get; set; }
        public Loans loans { get; set; }
        public SocialHelp SocialHelp { get; set; }

    }
}
