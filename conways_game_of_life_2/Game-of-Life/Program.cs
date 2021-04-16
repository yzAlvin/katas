using System.IO;
using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            // if read from console, Console.In, if read from file... 
            var game = new Game(Console.In, Console.Out);
            game.Run();
        }
    }
}
