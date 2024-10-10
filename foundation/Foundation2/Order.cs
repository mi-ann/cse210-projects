public class Order
{
    private Customer _customer;
    private List<Product> _products;
    private const decimal DomesticShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal TotalCost()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.ProductCost();
        }
        total += _customer.LivesInUSA() ? DomesticShippingCost : InternationalShippingCost;
        return total;
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetProductId()}: {product.ProductCost():C}\n";
        }
        return label.Trim();
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetCustomerInfo()}";
    }

    public void Display()
    {
        Console.WriteLine($"Order for: {_customer.GetCustomerInfo()}");
        Console.WriteLine("Products:");
        foreach (var product in _products)
        {
            product.Display();
        }
        Console.WriteLine($"Total Cost: {TotalCost():C}");
        Console.WriteLine(PackingLabel());
        Console.WriteLine(ShippingLabel());
    }
}