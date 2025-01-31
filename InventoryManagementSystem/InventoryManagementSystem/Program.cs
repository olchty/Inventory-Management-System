using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    // Product class representing a product in the inventory
    public class Product
    {
        public int ProductId { get; set; }       // Unique identifier
        public string Name { get; set; }         // Product name
        public int QuantityInStock { get; set; } // Quantity in stock
        public double Price { get; set; }        // Product price

        public Product(int productId, string name, int quantityInStock, double price)
        {
            ProductId = productId;
            Name = name;
            QuantityInStock = quantityInStock;
            Price = price;
        }
    }

    // InventoryManager class to manage the inventory
    public class InventoryManager
    {
        private List<Product> _products; // List to store products

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        // Add a product to the inventory
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product cannot be null.");
                return;
            }

            // Check if the product ID is unique
            if (_products.Exists(p => p.ProductId == product.ProductId))
            {
                Console.WriteLine($"Product with ID {product.ProductId} already exists.");
                return;
            }

            // Validate product properties
            if (product.ProductId <= 0)
            {
                Console.WriteLine("Product ID must be a positive integer.");
                return;
            }

            if (product.QuantityInStock < 0)
            {
                Console.WriteLine("Quantity in stock cannot be negative.");
                return;
            }

            if (product.Price < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            _products.Add(product);
            Console.WriteLine($"Product '{product.Name}' added to inventory.");
        }

        // Remove a product from the inventory by ID
        public void RemoveProduct(int productId)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
                Console.WriteLine($"Product with ID {productId} removed from inventory.");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }

        // Update the quantity of a product by ID
        public void UpdateProduct(int productId, int newQuantity)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                if (newQuantity < 0)
                {
                    Console.WriteLine("Quantity cannot be negative.");
                    return;
                }

                product.QuantityInStock = newQuantity;
                Console.WriteLine($"Quantity of product with ID {productId} updated to {newQuantity}.");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }

        // List all products in the inventory
        public void ListProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("Inventory Products:");
            foreach (var product in _products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.QuantityInStock}, Price: ${product.Price:F2}");
            }
        }

        // Calculate and return the total value of the inventory
        public double GetTotalValue()
        {
            double totalValue = 0;
            foreach (var product in _products)
            {
                totalValue += product.QuantityInStock * product.Price;
            }
            return totalValue;
        }
    }

    // Main program to demonstrate the inventory management system
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventory = new InventoryManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Product Quantity");
                Console.WriteLine("4. List Products");
                Console.WriteLine("5. Get Total Inventory Value");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Add Product
                        Console.Write("Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Product newProduct = new Product(id, name, quantity, price);
                        inventory.AddProduct(newProduct);
                        break;

                    case "2": // Remove Product
                        Console.Write("Enter Product ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        inventory.RemoveProduct(removeId);
                        break;

                    case "3": // Update Product Quantity
                        Console.Write("Enter Product ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new quantity: ");
                        int newQuantity = int.Parse(Console.ReadLine());
                        inventory.UpdateProduct(updateId, newQuantity);
                        break;

                    case "4": // List Products
                        inventory.ListProducts();
                        break;

                    case "5": // Get Total Inventory Value
                        Console.WriteLine($"Total Inventory Value: ${inventory.GetTotalValue():F2}");
                        break;

                    case "6": // Exit
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}