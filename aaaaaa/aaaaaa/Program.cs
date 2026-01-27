using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaaaa
{// ================= PART A =================
    public class Computer
    {
        private string brand;
        private string model;
        private long serialnumber;
        private double price;

        private static int numberOfCreatedComputers = 0;

        public Computer(string brand, string model, long serialnumber, double price)
        {
            this.brand = brand;
            this.model = model;
            this.serialnumber = serialnumber;
            this.price = price;
            numberOfCreatedComputers++;
        }

        public string GetBrand()
        {
            return brand;
        }

        public string GetModel()
        {
            return model;
        }

        public long GetSerialNumber()
        {
            return serialnumber;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetBrand(string brand)
        {
            this.brand = brand;
        }

        public void SetModel(string model)
        {
            this.model = model;
        }

        public void SetSerialNumber(long serialnumber)
        {
            this.serialnumber = serialnumber;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public override string ToString()
        {
            return $"Brand: {brand}\nModel: {model}\nSN: {serialnumber}\nPrice: {price}";
        }

        public static int findNumberOfCreatedComputers()
        {
            return numberOfCreatedComputers;
        }
    }

    // ================= PART B =================
    internal class Program
    {
        const string STORE_PASSWORD = "password";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my computer store!");
            Console.Write("Enter maximum number of computers: ");
            int maxComputers = int.Parse(Console.ReadLine());

            Computer[] inventory = new Computer[maxComputers];
            int count = 0;
            int choice;

            do
            {
                DisplayMenu();
                choice = GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        if (!CheckPassword())
                            break;

                        Console.Write("How many computers do you want to add? ");
                        int numToAdd = int.Parse(Console.ReadLine());

                        int spaceLeft = maxComputers - count;
                        if (numToAdd > spaceLeft)
                        {
                            Console.WriteLine($"Only {spaceLeft} spaces available.");
                            numToAdd = spaceLeft;
                        }

                        for (int i = 0; i < numToAdd; i++)
                        {
                            Console.Write("Brand: ");
                            string brand = Console.ReadLine();

                            Console.Write("Model: ");
                            string model = Console.ReadLine();

                            Console.Write("Serial Number: ");
                            long sn = long.Parse(Console.ReadLine());

                            Console.Write("Price: ");
                            double price = double.Parse(Console.ReadLine());

                            inventory[count++] = new Computer(brand, model, sn, price);
                        }
                        break;

                    case 2:
                        if (!CheckPassword())
                            break;

                        Console.Write("Enter computer index to update: ");
                        int index = int.Parse(Console.ReadLine());

                        if (index < 0 || index >= maxComputers || inventory[index] == null)
                        {
                            Console.WriteLine("No computer found at this index.");
                            break;
                        }

                        UpdateComputer(inventory[index], index);
                        break;

                    case 3:
                        Console.Write("Enter brand name: ");
                        string searchBrand = Console.ReadLine();
                        FindComputersByBrand(inventory, searchBrand);
                        break;

                    case 4:
                        Console.Write("Enter a price: ");
                        double maxPrice = double.Parse(Console.ReadLine());
                        FindCheaperThan(inventory, maxPrice);
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using the computer store system!");
                        break;
                }

            } while (choice != 5);
        }

        // ================= HELPER METHODS =================

        public static void DisplayMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Enter new Computer");
            Console.WriteLine("2. Update Computer");
            Console.WriteLine("3. Find computer by brand");
            Console.WriteLine("4. Find computer cheaper than a price");
            Console.WriteLine("5. Exit");
        }

        public static int GetMenuChoice()
        {
            int choice;
            do
            {
                Console.Write("Enter your choice [1-5]: ");
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 5);

            return choice;
        }

        public static bool CheckPassword()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter password: ");
                string input = Console.ReadLine();
                if (input == STORE_PASSWORD)
                    return true;
            }

            Console.WriteLine("Incorrect password. Returning to menu.");
            return false;
        }

        public static void UpdateComputer(Computer c, int index)
        {
            int choice;
            do
            {
                Console.WriteLine($"\nComputer #{index}");
                Console.WriteLine(c);
                Console.WriteLine("\n1. Change Brand");
                Console.WriteLine("2. Change Model");
                Console.WriteLine("3. Change Serial Number");
                Console.WriteLine("4. Change Price");
                Console.WriteLine("5. Quit");

                choice = GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Write("New brand: ");
                        c.SetBrand(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("New model: ");
                        c.SetModel(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("New serial number: ");
                        c.SetSerialNumber(long.Parse(Console.ReadLine()));
                        break;
                    case 4:
                        Console.Write("New price: ");
                        c.SetPrice(double.Parse(Console.ReadLine()));
                        break;
                }

            } while (choice != 5);
        }

        public static void FindComputersByBrand(Computer[] inventory, string brand)
        {
            bool found = false;
            foreach (Computer c in inventory)
            {
                if (c != null && c.GetBrand().Equals(brand, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(c);
                    Console.WriteLine();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No computers found with this brand.");
        }

        public static void FindCheaperThan(Computer[] inventory, double price)
        {
            bool found = false;
            foreach (Computer c in inventory)
            {
                if (c != null && c.GetPrice() < price)
                {
                    Console.WriteLine(c);
                    Console.WriteLine();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No computers found cheaper than this price.");
        }
    }
}
