using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Game_of_Life
{
    public class FakeInput : TextReader
    {
        private Queue<string> strings = new Queue<string>();
        public Dictionary<string, int> readStrings = new Dictionary<string, int>();
        public FakeInput()
        {
        }

        public override string ReadLine()
        {
            var returnString = strings.Dequeue();
            AddStringToReadStrings(returnString);
            return returnString;
        }

        private void AddStringToReadStrings(string returnString)
        {
            if (readStrings.ContainsKey(returnString))
            {
                readStrings[returnString]++;
            }
            else
            {
                readStrings.Add(returnString, 1);
            }
        }

        public void SetupSequence(string someString)
        {
            strings.Enqueue(someString);
        }
    }
}