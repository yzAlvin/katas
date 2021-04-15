using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(Console.In, Console.Out);
            game.Run();
        }
    }
}
