using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Models;

namespace Zeta.Repository
{
    public class PaymentRepository
    {
        public Dictionary<string, Payment> Payments { get; set; }

        public PaymentRepository()
        {
            Payments = new();
        }
    }
}
