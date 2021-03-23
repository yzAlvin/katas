/*
1. Pass Tests
2. No Duplication
3. Reveal Intention
4. Minimal Elements
*/
using System;

namespace basic_coding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program a = new Program();
            a.MultiplicationTable();

        }

        public string GreetUser(string name)
        {
            return $"Hello {name}";
        }

        public string GreetBobOrAlice(string name)
        {
            if (name.ToLower() == "bob" || name.ToLower() == "alice")
            {
                return GreetUser(name);
            }
            else
            {
                return "";
            }
            
        }

        public int SumOneToN(int n)
        {
            if (n <= 0)
            {
                throw new InvalidOperationException("N must be greater than 0");
            }
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }


        public int SumOneToNIfMultipleOf3Or5(int n)
        {
            if (n <= 0)
            {
                throw new InvalidOperationException("N must be greater than 0");
            }
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public int ProducOneToN(int n)
        {
            if (n <= 0)
            {
                throw new InvalidOperationException("N must be greater than 0");
            }
            int product = 1;
            for (int i = 1; i <= n; i++)
            {
                product *= i;
            }
            return product;
        }

        public int[][] MultiplicationTable()
        {
            int[][] TwelveTimesTable = new int[12][];
            for (int i = 0; i < 12; i++)
            {
                TwelveTimesTable[i] = new int[12];
                for (int j = 0; j < 12; j++)
                {
                    TwelveTimesTable[i][j] = (j+1) * (i+1);
                }
            }
            // foreach (int[] i in TwelveTimesTable)
            // {
            //     foreach (int j in i)
            //     {
            //         Console.Write($"{j} ");
            //     }
            //     Console.WriteLine();
            // }   
            return TwelveTimesTable;
        }

    }
}
