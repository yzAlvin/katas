using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleReader = new Input(Console.In);
            var consoleWriter = new Output(Console.Out);
            var game = new Game(consoleReader, consoleWriter);
            game.Play();
        }
    }
}
