using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Models;

namespace Zeta.Repository
{
    public class OrderRepository
    {
        public Dictionary<string, Order> Orders { get; private set; }

        public OrderRepository()
        {
            Orders = new();
        }
    }
}
