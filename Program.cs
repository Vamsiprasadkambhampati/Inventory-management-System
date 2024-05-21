using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class Item
    {
        public int ID { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Item(int id, string name, decimal price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Price: {Price:C}, Quantity: {Quantity}";
        }
    }
    public class Inventory
    {
        private List<Item> items;
        private int nextId;
        public Inventory()
        {
            items = new List<Item>();
            nextId = 1;
        }
        public void AddItem(string name, decimal price, int quantity)
        {
            Item item = new Item(nextId++, name, price, quantity);
            items.Add(item);
            Console.WriteLine("Item added successfully!");
        }
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public Item FindItemById(int id)
        {
            return items.Find(item => item.ID == id);
        }
        public bool UpdateItem(int id, string name, decimal price, int quantity)
        {
            Item item = FindItemById(id);
            if (item != null)
            {
                item.Name = name;
                item.Price = price;
                item.Quantity = quantity;
                return true;
            }
            return false;
        }
        public bool DeleteItem(int id)
        {
            Item item = FindItemById(id);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddNewItem(inventory);
                        break;
                    case "2":
                        inventory.DisplayItems();
                        break;
                    case "3":
                        FindItem(inventory);
                        break;
                    case "4":
                        UpdateExistingItem(inventory);
                        break;
                    case "5":
                        DeleteExistingItem(inventory);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddNewItem(Inventory inventory)
        {
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Item Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            inventory.AddItem(name, price, quantity);
        }

        static void FindItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to find: ");
            int id = int.Parse(Console.ReadLine());

            Item item = inventory.FindItemById(id);
            if (item != null)
            {
                Console.WriteLine("Item found: " + item);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        static void UpdateExistingItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter new Item Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new Item Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter new Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            if (inventory.UpdateItem(id, name, price, quantity))
            {
                Console.WriteLine("Item updated successfully!");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
        static void DeleteExistingItem(Inventory inventory)
        {
            Console.Write("Enter Item ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            if (inventory.DeleteItem(id))
            {
                Console.WriteLine("Item deleted successfully!");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }
}

