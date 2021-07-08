using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta.Services
{
    public class PaymentServiceImpl : PaymentService
    {
        public PaymentServiceImpl()
        {
        }

        public double MakePaymentAndReturnChange(double cost, double amountPaid)
        {
            return amountPaid - cost;
        }
    }
}
