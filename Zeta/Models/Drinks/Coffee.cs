using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta.Models.Drinks
{
    public class Coffee : Drink
    {

        public Coffee(string Name) : base(Name, Enums.DrinkType.COFFEE)
        {
        
        }
    }
}
