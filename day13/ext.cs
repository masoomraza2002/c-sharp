// using System;

// delegate void PaymentDelegate(decimal amount);
// delegate void OrderDelegate(string orderId);

// class PaymentService
// {
//     public void ProcessPayment(decimal amount)
//     {
//         Console.WriteLine("Payment processed: " + amount);
//     }
// }

// delegate void Action(string );

// class OrderService
// {
//     public void DeleteOrder(string orderId)
//     {
//         Console.WriteLine("Order deleted: " + orderId);
//     }
// }



// static class PaymentExtension
// {
//     public static bool IsValid(this decimal amount)
//     {
//         return amount > 0 && amount <= 1_000_000;
//     }
// }

// class Main2
// {
//     static void main2()
//     { 
//         PaymentService paymentService = new PaymentService();
//         PaymentDelegate payment = paymentService.ProcessPayment;

//         decimal amount = 5000;

//         if (amount.IsValid())
//         {
//             payment(amount);
//         }
//         else
//         {
//             Console.WriteLine("Invalid payment amount");
//         }
 
//         OrderService orderService = new OrderService();
//         OrderDelegate deleteOrder = orderService.DeleteOrder;

//         deleteOrder("ORD123");


//         Action<string> logAction = message => Console.WriteLine("log entry : "+message);
//         logAction("user logged");
//     }
// }