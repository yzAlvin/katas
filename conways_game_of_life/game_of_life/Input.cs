using System.Collections.Generic;
using System.IO;

namespace game_of_life
{
    public class Input
    {
        private readonly TextReader _textReader;

        public Input(TextReader textReader)
        {
            _textReader = textReader;
        }

        public IEnumerable<char> ReadLine() => _textReader.ReadLine();
    }
}