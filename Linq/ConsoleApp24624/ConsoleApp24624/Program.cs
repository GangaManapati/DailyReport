using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string Product { get; set; }
}

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Alice" },
            new Customer { CustomerId = 2, Name = "Bob" },
            new Customer { CustomerId = 3, Name = "Charlie" }
        };

        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 101, CustomerId = 1, Product = "Laptop" },
            new Order { OrderId = 102, CustomerId = 1, Product = "Mouse" },
            new Order { OrderId = 103, CustomerId = 2, Product = "Keyboard" },
            new Order { OrderId = 104, CustomerId = 3, Product = "Monitor" },
            new Order { OrderId = 105, CustomerId = 3, Product = "Printer" }
        };

        var customerOrders = customers.GroupJoin(
            orders,
            customer => customer.CustomerId,
            order => order.CustomerId,
            (customer, Order) => new { CustomerName = customer, Orders = Order });




        foreach (var customerOrder in customerOrders)
        {
            Console.WriteLine($"Customer: {customerOrder.CustomerName}");
            foreach (var order in customerOrder.Orders)
            {
                Console.WriteLine($"\tOrder ID: {order.OrderId}, Product: {order.Product}");
            }
            Console.ReadLine();
        }
    }
}
