using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Models;
using Zeta.Repository;
using Zeta.Services;

namespace Zeta
{
    class Driver
    {
        public static void Main(string[] args)

        {
            CoffeeVendingMachine vendingMachine = new CoffeeVendingMachine(Guid.NewGuid().ToString());
            Inventory inventory = new Inventory(vendingMachine.Id);
            OrderRepository orderRepository = new OrderRepository();
            PaymentRepository paymentRepository = new PaymentRepository();
            CostService costService = new CostServiceImpl();
            PaymentService paymentService = new PaymentServiceImpl();

            VendingMachineService vendingMachineService = new VendinMachineServiceImpl(inventory, paymentRepository, orderRepository, costService, paymentService);

            inventory.QuantitiesByType.Add(Enums.DrinkType.COFFEE, 10);

            // user selects Items 
            Order order = vendingMachineService.CreateOrder(Enums.DrinkType.COFFEE, 10);

            //user accepts prompt to place order
            order = vendingMachineService.PlaceOrder(order);

            Console.WriteLine($"order chares : {order.Payment.Charges}");

            //User is prompted to make payment and clicks on payment
            Notification notification = vendingMachineService.MakePaymentAndNotifyUser(Enums.PaymentType.CASH, 15, order.Payment.Charges, order);

            Order order1 = orderRepository.Orders[order.OrderId];

            //order status is in progress
            Console.WriteLine($"Order status : {order1.OrderStatus.ToString()}");

            //less paid, pay full amount
            Console.WriteLine($"Notification message : {notification.Message}");

            //quantity should be 10 (should not change)
            Console.WriteLine($"Coffe Quantity : {inventory.QuantitiesByType[Enums.DrinkType.COFFEE]}");

            Notification notification2 = vendingMachineService.MakePaymentAndNotifyUser(Enums.PaymentType.CASH, 140, order.Payment.Charges, order);

            Order order2 = orderRepository.Orders[order.OrderId];

            Console.WriteLine($"Order status : {order2.OrderStatus.ToString()}");

            Console.WriteLine($"Notification message : {notification2.Message}");

            //quantity should be 0
            Console.WriteLine($"Coffe Quantity : {inventory.QuantitiesByType[Enums.DrinkType.COFFEE]}");
        }
    }
}
