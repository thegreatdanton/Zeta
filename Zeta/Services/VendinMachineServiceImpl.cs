using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeta.Enums;
using Zeta.Models;
using Zeta.Repository;

namespace Zeta.Services
{
    public class VendinMachineServiceImpl : VendingMachineService
    {
        public Inventory inventory;
        public PaymentRepository paymentRepository;
        public OrderRepository orderRepository;
        public CostService costService;
        public PaymentService paymentService;

        public VendinMachineServiceImpl(Inventory inventory, PaymentRepository paymentRepository, OrderRepository orderRepository, CostService costService, PaymentService paymentService)
        {
            this.inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            this.paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this.costService = costService;
            this.paymentService = paymentService;
        }

        public Order CreateOrder(DrinkType drinkType, int Quantity)
        {
            Order order = new Order()
            {
                DrinkType = drinkType,
                OrderId = Guid.NewGuid().ToString(),
                OrderStatus = OrderStatus.INPROGRESS,
                Quantity = Quantity
            };
            orderRepository.Orders.Add(order.OrderId, order);
            return order;
        }

        public Notification MakePaymentAndNotifyUser(PaymentType paymentType, double amountPaid, double cost, Order order)
        {
            string message = string.Empty;
            double change = 0.0;
            if (amountPaid < cost)
            {
                message = "Please pay full amount";
                order.Payment.PaymentStatus = PaymentStatus.INPROGRESS;
            }
            else
            {

                change = paymentService.MakePaymentAndReturnChange(cost, amountPaid);
                order.Payment.PaymentStatus = PaymentStatus.PAID;
                paymentRepository.Payments[order.Payment.Id] = order.Payment;
                DrinkType drinkType = order.DrinkType;
                order.OrderStatus = OrderStatus.SUCCESS;
                orderRepository.Orders[order.OrderId] = order;
                inventory.QuantitiesByType[drinkType] = inventory.QuantitiesByType[drinkType] - order.Quantity;
                message = "Order placed successfully !!";
                if(change != 0.0) 
                {
                    string.Concat(message, "Please collect your change");
                }
            }

            return NotifyUser(order, message, change);
        }

        //
        private Notification NotifyUser(Order order, string message, double change)
        {
            Notification notification = new Notification()
            {
                OrderId = order.OrderId,
                Message = message,
                Change = change
            };

            return notification;
        }

        public Order PlaceOrder(Order order)
        {
            Payment payment = new Payment()
            {
                OrderId = order.OrderId,
                Id = Guid.NewGuid().ToString(),
                PaymentStatus = PaymentStatus.NOTPAID,
                Charges = FindCost(order.DrinkType, order.Quantity)
            };

            order.Payment = payment;

            paymentRepository.Payments.Add(payment.Id, payment);

            return order;
        }

        private double FindCost(DrinkType drinkType, int quantity)
        {
            return costService.FindCost(drinkType, quantity);
        }
    }
}

