using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
class Address
{
private string street;
private string city;
private string stateOrProvince;
private string country;

    public Address(string street, string city, string stateOrProvince, string country)  
    {  
        this.street = street;  
        this.city = city;  
        this.stateOrProvince = stateOrProvince;  
        this.country = country;  
    }  

    public bool IsInUSA()  
    {  
        return country.ToUpper() == "USA";  
    }  

    public string GetFullAddress()  
    {  
        return $"{street}\n{city}, {stateOrProvince}\n{country}";  
    }  
}  

class Customer  
{  
    private string name;  
    private Address address;  

    public Customer(string name, Address address)  
    {  
        this.name = name;  
        this.address = address;  
    }  

    public bool IsInUSA()  
    {  
        return address.IsInUSA();  
    }  

    public string GetName()  
    {  
        return name;  
    }  

    public string GetAddress()  
    {  
        return address.GetFullAddress();  
    }  
}  

class Product  
{  
    private string name;  
    private string productId;  
    private double price;  
    private int quantity;  

    public Product(string name, string productId, double price, int quantity)  
    {  
        this.name = name;  
        this.productId = productId;  
        this.price = price;  
        this.quantity = quantity;  
    }  

    public double GetTotalPrice()  
    {  
        return price * quantity;  
    }  

    public string GetPackingInfo()  
    {  
        return $"{name} (ID: {productId}) x{quantity}";  
    }  
}  

class Order  
{  
    private Customer customer;  
    private List<Product> products;  

    public Order(Customer customer)  
    {  
        this.customer = customer;  
        this.products = new List<Product>();  
    }  

    public void AddProduct(Product product)  
    {  
        products.Add(product);  
    }  

    public double CalculateTotalCost()  
    {  
        double total = 0;  
        foreach (var p in products)  
        {  
            total += p.GetTotalPrice();  
        }  
        double shippingCost = customer.IsInUSA() ? 5 : 35;  
        total += shippingCost;  
        return total;  
    }  

    public string GetPackingLabel()  
    {  
        string label = "Packing Label:\n";  
        foreach (var p in products)  
        {  
            label += "- " + p.GetPackingInfo() + "\n";  
        }  
        return label;  
    }  

    public string GetShippingLabel()  
    {  
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";  
    }  
}  

class Program  
{  
    static void Main(string[] args)  
    {  
        Address address1 = new Address("123 Main St", "El Espino", "La Chorrera", "Panama");  
        Customer customer1 = new Customer("Emily Ureña", address1);  
        Order order1 = new Order(customer1);  
        order1.AddProduct(new Product("Laptop", "L001", 999.99, 1));  
        order1.AddProduct(new Product("Mouse", "M001", 25.50, 2));  

        Address address2 = new Address("456 Second St", "El Coco", "Potrero Grande", "Panama");  
        Customer customer2 = new Customer("Diana Gracía", address2);  
        Order order2 = new Order(customer2);  
        order2.AddProduct(new Product("Keyboard", "K001", 49.99, 1));  
        order2.AddProduct(new Product("Monitor", "MN001", 199.99, 2));  
        order2.AddProduct(new Product("USB Cable", "U001", 9.99, 3));  

        List<Order> orders = new List<Order> { order1, order2 };  
        int count = 1;  
        foreach (var order in orders)  
        {  
            Console.WriteLine($"--- Order {count} ---");  
            Console.WriteLine(order.GetPackingLabel());  
            Console.WriteLine(order.GetShippingLabel());  
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");  
            Console.WriteLine();  
            count++;  
        }  
    }  
}  
}
