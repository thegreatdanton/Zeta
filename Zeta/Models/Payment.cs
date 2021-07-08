using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;

namespace Zeta.Models
{
    public class Payment
    {
        public string Id { get; set; }

        public double Charges { get; set; }

        public string OrderId { get; set; }

        public PaymentType PaymentType { get; set; }

        public PaymentStatus PaymentStatus {get; set;}
    }
}
