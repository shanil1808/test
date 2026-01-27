using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------- Welcome to my computer store --------- ");
            Console.WriteLine("Enter maximum number of computers :");
            int maxComputers = int.Parse(Console.ReadLine());

            Computer[] inventory = new Computer[maxComputers];

            int computerCount = 0;
            int choice;
            const string STORE_PASSWORD = "password";


            do
            {
                DisplayMenu();
                choice = GetMenuChoice();

                switch (choice)
                {
                    case 1: // Enter new computer(s)
                        {
                            int attempts = 0;
                            bool accessGranted = false;

                            while (attempts < 3)
                            {
                                Console.Write("Enter password: ");
                                string inputPassword = Console.ReadLine();

                                if (inputPassword == STORE_PASSWORD)
                                {
                                    accessGranted = true;
                                    break;
                                }
                                else
                                {
                                    attempts++;
                                    Console.WriteLine("Incorrect password.");
                                }
                            }

                            if (!accessGranted)
                            {
                                Console.WriteLine("Too many failed attempts. Returning to main menu.");
                                break;
                            }

                            Console.Write("How many computers do you want to add? ");
                            int numberToAdd = int.Parse(Console.ReadLine());

                            int remainingSpace = maxComputers - computerCount;

                            if (remainingSpace <= 0)
                            {
                                Console.WriteLine("Inventory is full. Cannot add more computers.");
                                break;
                            }

                            if (numberToAdd > remainingSpace)
                            {
                                Console.WriteLine($"Not enough space. You can only add {remainingSpace} computer(s).");
                                numberToAdd = remainingSpace;
                            }

                            for (int i = 0; i < numberToAdd; i++)
                            {
                                Console.WriteLine($"Computer #{i + 1}");

                                Console.Write("Enter brand: ");
                                string brand = Console.ReadLine();

                                Console.Write("Enter model: ");
                                string model = Console.ReadLine();

                                Console.Write("Enter serial number: ");
                                long sn = long.Parse(Console.ReadLine());

                                Console.Write("Enter price: ");
                                double price = double.Parse(Console.ReadLine());

                                inventory[computerCount] = new Computer(brand, model, sn, price);
                                computerCount++;
                            }

                            Console.WriteLine("Computer(s) added successfully!");
                            break;
                        }

                    case 2: // Update computer
                        {
                            int attempts = 0;
                            bool accessGranted = false;

                            while (attempts < 3)
                            {
                                Console.Write("Enter password: ");
                                string inputPassword = Console.ReadLine();

                                if (inputPassword == STORE_PASSWORD)
                                {
                                    accessGranted = true;
                                    break;
                                }
                                else
                                {
                                    attempts++;
                                    Console.WriteLine("Incorrect password.");
                                }
                            }

                            if (!accessGranted)
                            {
                                Console.WriteLine("Too many failed attempts. Try again.");
                                break;
                            }
                        }
                        Console.Write("Enter serial number of computer to update: ");
                        long updateSN = long.Parse(Console.ReadLine());
                        bool updated = false;

                        for (int i = 0; i < computerCount; i++)
                        {
                            if (inventory[i].GetSerialNumber() == updateSN)
                            {
                                Console.Write("Enter new price: ");
                                inventory[i].SetPrice(double.Parse(Console.ReadLine()));
                                Console.WriteLine("Computer updated!");
                                updated = true;
                                break;
                            }
                        }

                        if (!updated)
                            Console.WriteLine("Computer not found.");
                        break;

                    case 3: // Find by brand
                        Console.Write("Enter brand to search: ");
                        string searchBrand = Console.ReadLine();
                        bool foundBrand = false;

                        for (int i = 0; i < computerCount; i++)
                        {
                            if (inventory[i].GetBrand().Equals(searchBrand, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(inventory[i]);
                                foundBrand = true;
                            }
                        }

                        if (!foundBrand)
                            Console.WriteLine("No computers found for that brand.");
                        break;

                    case 4: // Find cheaper than price
                        Console.Write("Enter maximum price: ");
                        double maxPrice = double.Parse(Console.ReadLine());
                        bool foundPrice = false;

                        for (int i = 0; i < computerCount; i++)
                        {
                            if (inventory[i].GetPrice() < maxPrice)
                            {
                                Console.WriteLine(inventory[i]);
                                foundPrice = true;
                            }
                        }

                        if (!foundPrice)
                            Console.WriteLine("No computers found under that price.");
                        break;

                    case 5: // Exit
                        Console.WriteLine("Thank you for using the computer store system!");
                        break;


                }


            } while (choice != 5);
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Main Menu : ");
            Console.WriteLine("1. Enter new Computer");
            Console.WriteLine("2. Update Computer ");
            Console.WriteLine("3. Find computer by brand");
            Console.WriteLine("4. Find Computer cheaper than a price");
            Console.WriteLine("5. Exit");
        }

        public static int GetMenuChoice()
        {
            int choice;
            do
            {
                Console.WriteLine("Enter your Choice[1-5] :");
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 5);

            return choice;
        }

    }

    public class Computer
    {
        private string brand;
        private string model;
        private long serialnumber;
        private double price;

        private static int numberOFCreatedComputer = 0;

        public Computer(string brand, string model, long serialnumber, double price)
        {
            this.brand = brand;
            this.model = model;
            this.serialnumber = serialnumber;
            this.price = price;
            numberOFCreatedComputer++;
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
            return $"Brand: {brand}  \nModel: {model} \nSN: {serialnumber} \nPrice: {price}";
        }


        public static int findNumberOfCreatedComputers()
        {
            return numberOFCreatedComputer;
        }
    }
}
