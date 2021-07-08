using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;

namespace Zeta.Services
{
    public interface CostService
    {
        public double FindCost(DrinkType drinkType, int quantity);
    }
}
