using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;
using Zeta.Models;

namespace Zeta.Services
{
    public interface VendingMachineService
    {
        public Order PlaceOrder(Order order);

        public Notification MakePaymentAndNotifyUser(PaymentType paymentType, double amountPaid, double cost, Order order);

        public Order CreateOrder(DrinkType drinkType, int Quantity);

       // public Order SelectItems();

        //public Notification CanceOrder();
    }
}
