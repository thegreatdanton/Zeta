using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;

namespace Zeta.Models
{
    public class Order
    {
        public string OrderId { get; set; }

        public int Quantity { get; set; }

        public DrinkType DrinkType { get; set; }

        public Payment Payment { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
