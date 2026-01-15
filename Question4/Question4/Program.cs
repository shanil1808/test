using System;
using static System.Net.Mime.MediaTypeNames;

namespace OOPC1
{
    internal class Program
    {
        static double balance = 1000;
        static void Main(string[] args)
        {
            //int choice;
            //do
            //{
            //    Console.WriteLine("Calculator Menu");
            //    Console.WriteLine("1 . ADD ");
            //    Console.WriteLine("2 . Sub");
            //    Console.WriteLine("3. Mult");
            //    Console.WriteLine("4. Div");
            //    Console.WriteLine("5. Exit");

            //    Console.WriteLine("Give me your choice: ");
            //    choice = int.Parse(Console.ReadLine());

            //    if (choice >= 1 && choice <= 4)
            //    {
            //        Console.Write("Enter first number: ");
            //        double a = double.Parse(Console.ReadLine());

            //        Console.Write("Enter second number: ");
            //        double b = double.Parse(Console.ReadLine());

            //        switch (choice)
            //        {
            //            case 1:
            //                Add(a, b);
            //                break;
            //            case 2:
            //                Subtract(a, b);
            //                break;
            //            case 3:
            //                Multiply(a, b);
            //                break;
            //            case 4:
            //                Divide(a, b);
            //                break;
            //        }
            //    }


            //} while (choice != 5);

            //Console.WriteLine(isValidPass("Parsjgdsd"));

            // countVowelConst("pargol is a  teacher ");



        }

        //methods

        public static void Add(double a, double b)
        {
            Console.WriteLine("Result: " + (a + b));
        }

        public static void Subtract(double a, double b)
        {
            Console.WriteLine("Result: " + (a - b));
        }

        public static void Multiply(double a, double b)
        {
            Console.WriteLine("Result: " + (a * b));
        }

        public static void Divide(double a, double b)
        {
            if (b != 0)
                Console.WriteLine("Result: " + (a / b));
            else
                Console.WriteLine("Cannot divide by zero");
        }

        //q2

        public static bool isValidPass(string pass)
        {
            //checklength
            if (pass.Length < 8)
            {
                return false;
            }
            int digitCount = 0;
            int upperCount = 0;

            foreach (char ch in pass)
            {
                if (char.IsDigit(ch))
                {
                    digitCount++;
                }

                if (char.IsUpper(ch))
                {
                    upperCount++;
                }
            }
            if (digitCount > 0 && upperCount > 0)
            {
                return true;
            }
            return false;
        }


        //q3
        public static void countVowelConst(string text)
        {
            int vow = 0;
            int conts = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    if ("aieou".Contains(ch))
                    {
                        vow++;
                    }
                    else
                    {
                        conts++;
                    }
                }
            }
            Console.WriteLine("the number of vo is " + vow);
            Console.WriteLine("the number of const is " + conts);
        }


        //q4

        public static void CheckBalance()
        {
            Console.WriteLine("Current balance is " + balance);
        }

        public static void Deposit(double amount)
        {
            balance = balance + amount; // balance += amount
            Console.WriteLine("Deposit is success");
            Console.WriteLine("Current balance is " + balance);
        }

        public static void withdraw(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("amount is not valid");
                return;
            }
            if (amount < balance)
            {
                balance -= amount;
                Console.WriteLine("withdraw success");
                Console.WriteLine("Current balance is " + balance);
            }
            else
            {
                Console.WriteLine("you are poor you dont have that much money ");

            }

        }

      
        
    }
}