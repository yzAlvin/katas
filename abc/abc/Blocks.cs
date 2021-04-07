using System.Linq.Expressions;
using System.Linq;
using System;
using System.Collections.Generic;

namespace abc
{
    static public class Blocks
    {
        static List<string> blockList = new List<string>()
            {
                "B O", 
                "X K", 
                "D Q", 
                "C P", 
                "N A", 
                "G T", 
                "R E", 
                "T G", 
                "Q D", 
                "F S", 
                "J W", 
                "H U", 
                "V I", 
                "A N", 
                "O B", 
                "E R", 
                "F S", 
                "L Y", 
                "P C", 
                "Z M"
            };

        static public bool can_make_word(string word)
        {
            List<string> availableBlocks = new List<string>(blockList);
            foreach (char letter in word.ToUpper())
            {
                if (!availableBlocks.Any(b => b.Contains(letter)))
                    return false;
                    
                availableBlocks.Remove(availableBlocks.First(b => b.Contains(letter)));
            }
            return true;
        }
    }
}


