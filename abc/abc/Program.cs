using System;

namespace abc
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a string to see if you can spell it with the given blocks.");
            string word = Console.ReadLine();

            if (Blocks.can_make_word(word))
            {
                Console.WriteLine($"{word} can be made.");
            }
            else
            {
                Console.WriteLine($"{word} cannot be made.");
            }
        }    
    }
}
