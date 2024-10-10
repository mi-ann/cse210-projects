using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Choclate", "CHOCL-001", 10.00m, 2));
        order1.AddProduct(new Product("Donuts", "DONUT-002", 15.00m, 1));
        
        // Displaying details of the first order
        Console.WriteLine("Order 1 Details:");
        order1.Display();
        Console.WriteLine();

        // Creating second customer and order
        Address address2 = new Address("456 Another Rd", "Othertown", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Flower bouqet", "FLOWR-001", 20.00m, 3));
        order2.AddProduct(new Product("Chinese takeout", "CHINTK-002", 25.00m, 2));
        
        // Displaying details of the second order
        Console.WriteLine("Order 2 Details:");
        order2.Display();
    }
}