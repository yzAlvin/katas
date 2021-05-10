using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game_of_Life.Tests
{
    public class FakeOutput : TextWriter
    {
        public Dictionary<string, int> writtenStrings = new Dictionary<string, int>();

        public override Encoding Encoding => throw new NotImplementedException();

        public override void WriteLine(string someString)
        {
            AddStringToWrittenStrings(someString);
        }
        
        private void AddStringToWrittenStrings(string writtenString)
        {
            if (writtenStrings.ContainsKey(writtenString))
            {
                writtenStrings[writtenString]++;
            }
            else
            {
                writtenStrings.Add(writtenString, 1);
            }
        }
    }
}