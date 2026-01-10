using System;
using System.Collections.Generic;

namespace EcommerceAssessment
{
    class Repository<T>
    {
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> GetAll()
        {
            return items;
        }


    }

    class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"id : {orderId} , customer name : {CustomerName} , amount : {Amount}";
        }


    }

    delegate string orderCallback(string mess);

    class OrderProcessor
    {
        public event Action<string> OrderProcessed;

        public void ProcessOrder(Order order, Func<double, double> taxCalculator, Func<double, double> discountCalculator, Predicate<Order> validator, OrderCallback callback)
        {
            if (!validator(order))
            {
                callback($"order {order.OrderId} valudation failed");
                return;
            }

            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);

            order.Amount = order.Amount + tax - discount;
            callback($"order {order.OrderId} valudation done ,  final amount  {order.Amount}");
            OrderProcessed?.Invoke("event processed");
        }
    }

    class Main2
    {
        public static void main2()
        {
            Repository<Order> repository = new Repository<Order>();

            repository.Add(new Order{orderId=1 , CustomerName="alice",Amount = 500});
            repository.Add(new Order{orderId=2 , CustomerName="bob",Amount = 200});
            repository.Add(new Order{orderId=3 , CustomerName="charlie",Amount = 1000});

            Func<double,  double> taxCalculator = amount => amount * 0.1;
            Func<double,  double> discountCalculator = amount => amount * 0.05;
            Predicate<Order> validate =  order => order.Amount >= 300;

            OrderCallback callback = message => Console.WriteLine(message);

            Action<string> logger = msg => Console.WriteLine($"logges {msg}");
            Action<string> logger = msg => Console.WriteLine($"notify {msg}");

            OrderProcess process = new OrderProcess();

        }
    }
}