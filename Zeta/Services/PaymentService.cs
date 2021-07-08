using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeta.Services
{
    public interface PaymentService
    {
        public double MakePaymentAndReturnChange(double cost, double amountPaid);
    }
}
