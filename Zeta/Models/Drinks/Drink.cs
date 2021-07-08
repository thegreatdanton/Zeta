using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;

namespace Zeta.Models.Drinks
{
    public abstract class Drink
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DrinkType DrinkType { get; set; }

        public Drink(string Name, DrinkType DrinkType) 
        {
            this.DrinkType = DrinkType;
            Id = Guid.NewGuid().ToString();
            
        }


    }
}
