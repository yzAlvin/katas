using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game_of_Life
{
    public class FakeOutput : TextWriter
    {
        public Dictionary<string, int> wroteStrings = new Dictionary<string, int>();
        public override Encoding Encoding => throw new System.NotImplementedException();

        public override void WriteLine(string someString)
        {
            AddStringToWroteStrings(someString);
        }
        
        private void AddStringToWroteStrings(string returnString)
        {
            if (wroteStrings.ContainsKey(returnString))
            {
                wroteStrings[returnString]++;
            }
            else
            {
                wroteStrings.Add(returnString, 1);
            }
        }
    }
}