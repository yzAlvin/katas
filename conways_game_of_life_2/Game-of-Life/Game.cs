using System.IO;

namespace Game_of_Life
{
    public class Game
    {
        private readonly TextReader _consoleReader;
        private readonly TextWriter _consoleWriter;

        public Game(TextReader consoleReader)
        {
            _consoleReader = consoleReader;
            // _consoleWriter = consoleWriter;
        }

        public void Run()
        {
            var size = _consoleReader.ReadLine().ToString();
        }
    }
}