using System;

namespace string_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var calc = new StringCalculator();
            calc.Add("//[*]\n1*2*3");
        }
    }
}
