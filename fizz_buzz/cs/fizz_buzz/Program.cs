using System.Linq;
using System;

namespace fizz_buzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 1; i <= 100; i++)
            // {
            //     Console.WriteLine(FizzBuzz(i));
            // }

            foreach(string i in Enumerable.Range(1, 100).Select(n => FizzBuzz(n)))
                Console.WriteLine(i);
        
        }

        static public string FizzBuzz(int n)
        {
            if (n % 15 == 0)
            {
                return "FizzBuzz";
            }
            if (n % 3 == 0)
            {
                return "Fizz";
            }
            if (n % 5 == 0)
            {
                return "Buzz";
            }
            return n.ToString();
        }
    }
}
