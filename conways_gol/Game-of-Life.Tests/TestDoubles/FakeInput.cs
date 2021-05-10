using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Game_of_Life
{
    public class FakeInput : TextReader
    {
        private Queue<string> stringQueue = new Queue<string>();
        public Dictionary<string, int> readStrings = new Dictionary<string, int>();

        public void SetupSequence(string someString) => stringQueue.Enqueue(someString);
        public void SetupSequence(string[] arrayOfStrings) => Array.ForEach(arrayOfStrings, s => SetupSequence(s));

        public override string ReadLine()
        {
            var returnString = stringQueue.Dequeue();
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


    }
}