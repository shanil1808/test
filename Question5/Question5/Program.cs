namespace Question5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 50, 22, 39, 7, 18, 22, 52, 29, 10 };
            Console.WriteLine("Second Largest: " + FindSecondLargest(numbers));
            FindSumAndAverage(numbers);
            CountEvenAndOdd(numbers);


            //type[] nameArray = new type[size]
            int[] myarr = new int[] { 2, 5, 22, 39, 7, 18, 22, 52, 29, 10 };
            Console.WriteLine("Please enter the number you are looking for : ");
            int v = int.Parse(Console.ReadLine());
            int count = 0;  

            for (int i = 0; i < myarr.Length; i++)
            {
                if (myarr[i] == v)
                {
                    Console.WriteLine("Value found in the index : " + i);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("I didnt found index");
                count = 0;
            }
        }
        //q5
        private static int FindSecondLargest (int[] arr)
        {
            int largest = int.MinValue;
            int Secondlargest = int.MinValue;

            foreach (int num  in arr)
            {
                if (num > largest)
                {
                    Secondlargest = largest;
                    largest = num;
                }
                else if ( num > Secondlargest && num != largest)
                {
                    Secondlargest = num;
                }
            }
            return Secondlargest;
        }

        //q6
        static void FindSumAndAverage (int[] arr)
        {
            int Sum = 0;

            foreach (int num in arr)
            {
                Sum += num; // or can write (sum=sum+num)
            }
            double Average = (double)Sum / arr.Length;

            Console.WriteLine("Sum =" + Sum);
            Console.WriteLine("Average =" + Average);
        }

        //q7
        static void CountEvenAndOdd(int[] arr)
        {
            int evenCount = 0;
            int oddCount = 0;  

            foreach(int num in arr)
            {
               if (num % 2 == 0)
                    evenCount++;
               else
                    oddCount++;
            }
            Console.WriteLine("Even numbers: " + evenCount);
            Console.WriteLine("Odd numbers: " + oddCount);
        }
    }
}
