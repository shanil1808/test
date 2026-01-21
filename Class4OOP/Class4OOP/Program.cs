using System.Collections.Specialized;

namespace Class4OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book(); // -> serial = 10000
            Book b2 = new Book(200, "JavaBook", 500);
            Book b3 = new Book(400, "C#",800);
            Book b4 = new Book(b2);
            Book b5 = new Book(98, "html",400);
            Book b6 = new Book(b3);


            //create array of books
            //Book[] library = new Book[4]; Book[0] = 1; ... //option 1
            Book[] library = { b1, b2, b3, b4, b5, b6 }; //option 2

            //Sorting Using Array
            for(int i = 0; i < library.Length; i++)
            {
                Console.WriteLine(library[i]);
            }

            Console.WriteLine("------ Sorting with price --------");
            for (int i = 0; i < library.Length - 1; i++)
            {
                for (int j = i + 1; j < library.Length; j++)
                {
                    if (library[i].GetPrice() > library[j].GetPrice())
                    {
                        //swap
                        Book temp = library[i];
                        library[i] = library[j];
                        library[j] = temp;
                    }
                }
            }
            for (int i = 0; i < library.Length; i++)
            {
                Console.WriteLine(library[i]);
            }

                //if i change anything in b2 
                b2.SetName("Potato");

            b1.SetName("Harry Potter 1");
            //int np = b1.GetNumberOfPage();
            //b1.numberOfPage = 100;
            //b1.Price = -35;  // i will give it to u access


            //b1.showInfoOfTheBook();
            //b2.showInfoOfTheBook();
            //b3.showInfoOfTheBook();
            //b4.showInfoOfTheBook();

            //Console.WriteLine(b1);
            //Console.WriteLine(b2);
            //Console.WriteLine(b3);
            //Console.WriteLine(b4);

        }
    }
    public class Book
    {
        //attributes
        private double Price;
        private string name;
        private int numberOfPage;
        private long serialNum;
        //Create Counter
        private static long serialNumCounter = 10000;


        //make engine my constreuctor (first engine)

        public Book()
        {
            Console.WriteLine("Creating Object with default Constructor");
            Price = 100;
            name = "Book1";
            numberOfPage = 400;
            serialNum = serialNumCounter;
            serialNumCounter++;
        }

        //copy constructor
        public Book(Book b)
        {
            Console.WriteLine("Creating Object with Copy Constructor");
            this.Price = b.Price;
            this.name = b.name;
            this.numberOfPage = b.numberOfPage;
            this.serialNum = serialNumCounter;
            serialNumCounter++;
        }


        //overloaded constructor (second engine)
        public Book(double price, string name, int numberOfPage)
        {
            Console.WriteLine("Creating Object with Parameter Constructor");

            this.Price = price;
            this.name = name;
            this.numberOfPage = numberOfPage;
            serialNum = serialNumCounter;
            serialNumCounter++;
        }

        public double GetPrice()
        {
            return Price;
        }

        public string GetName()
        {
            return name;
        }

        public int GetNumberOfPage()
        {
            return numberOfPage;
        }

        public long GetSerialNum()
        {
            return serialNum;
        }

        public void SetPrice(double pr)
        {
            if (pr < 0 || pr > 10000)
            {
                Console.WriteLine("Price cannot be negative");
                return;
            }
            Price = pr;
        }

        public void SetName(string n)
        {
            if (n == null)
            {     
                Console.WriteLine("Name cannot be null");
                return;
            }
            name = n;
        }

        public void SetNumberOfPage(int np)
        {
            if (np <0 || np > 5000)
            {                
                Console.WriteLine("Number of page cannot be negative");
                return;
            }
            numberOfPage = np;
        }

        public void showInfoOfTheBook()
        {
            Console.WriteLine( name + " is a book which has " + numberOfPage + " pages and its price is " + Price + "$" + " and has serial number " + serialNum );
        }

        public override string? ToString()
        {
            return $"{name} | Pages : {numberOfPage} | Price : {Price} | serial# : {serialNum}";
        }
    }
}
