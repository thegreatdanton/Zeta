using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta.Models
{
    public abstract class VendingMachine
    {
        public string Id { get; set; }

        public Display Display { get; set; }

        public Menu Menu { get; set; }

        public VendingMachine(string Id) 
        {
        
        }
    }
}
