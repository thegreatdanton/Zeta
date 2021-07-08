using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;

namespace Zeta.Repository
{
    public class Inventory
    {
        public Dictionary<DrinkType, double> QuantitiesByType { get; private set; }

        public string VendingMachineId { get; set; }
        public Inventory(string VendingMachineId) 
        {
            this.VendingMachineId = VendingMachineId;
            QuantitiesByType = new();
        }
    }
}
