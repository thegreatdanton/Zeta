using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;

namespace Zeta.Services
{
    public class CostServiceImpl : CostService
    {
        public Dictionary<DrinkType, double> CostsPerType { get; private set; }

        public CostServiceImpl()
        {
            CostsPerType = new();
            InitializeCosts();
        }

        private void InitializeCosts()
        {
            CostsPerType.Add(DrinkType.COFFEE, 12.99);
        }

        public double FindCost(DrinkType drinkType, int quantity)
        {
            return CostsPerType[drinkType] * quantity;
        }
    }
}
