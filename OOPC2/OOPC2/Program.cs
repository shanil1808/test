using System;
using System.Security.Cryptography.X509Certificates;

namespace OOPC2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            double num;
            do
            {

                Console.WriteLine("Calculator Menu");
                Console.WriteLine("1 .ADD");
                Console.WriteLine("2 .Sub");
                Console.WriteLine("3 .Mult");
                Console.WriteLine("4 .DIV");
                Console.WriteLine("5 .Exit");

                Console.WriteLine("Give me your choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= 4)

                    Console.Write("Enter your first number");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter your second number");
                double b = double.Parse(Console.ReadLine());

                switch (choice)
                {

                }




            } while (choice != 5);

            Console.WriteLine(isValidPass(Shanil1));
        }
        //method
        public static void Add(double a, double b)
        {
            Console.WriteLine(
        }

        public 

        //question 2

         public static bool isValidPass(string pass)
        {
            //checklength
            if (pass.Length < 8)
            {
                return false;
            }
            int digitcount = 0; 
            int uppercount = 0;

            foreach (char ch in pass)
            {
                if (!char.IsDigit(ch))
                {
                    digitcount++;
                }
                if (char.IsUpper(ch))
                {
                    uppercount++;
                }
                if (digitcount > 0 && uppercount)
                {
                    return true;
                }
                return false;
            }

        }
        Public static void countVowelConst(string text)
         {
            int vow = 0;
            int conts = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    if ("a,i,e,o,u".Contains(ch))
                    {
                        vow++;
                    }
                    else
                    {
                        conts++;
                    }
                }
            }
            Console.WriteLine ("the number of vo is " + vow);
            Console.WriteLine("the number of const is " + conts);
         }


    } 
}
