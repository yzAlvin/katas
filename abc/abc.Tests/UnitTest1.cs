using System;
using Xunit;
using abc;

namespace abc.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanMakeWord_True_Test()
        {
            string[] words = new string[] {"A", "BARK", "TREAT", "SQUAD", "CONFUSE"};
            foreach (string word in words)
            {
                Assert.True(Blocks.can_make_word(word));
            }
        }
        [Fact]
        public void CanMakeWord_TrueCaseInsensitive_Test()
        {
            string[] words = new string[] {"a", "baRK", "treaT", "SquAD", "COnfuSE"};
            foreach (string word in words)
            {
                Assert.True(Blocks.can_make_word(word));
            }
        }

        [Fact]
        public void CanMakeWord_FalseCaseInsensitive_Test()
        {
            string[] words = new string[] {"BooK", "common"};
            foreach (string word in words)
            {
                Assert.False(Blocks.can_make_word(word));
            }
        }
        [Fact]
        public void CanMakeWord_False_Test()
        {
            string[] words = new string[] {"BOOK", "COMMON"};
            foreach (string word in words)
            {
                Assert.False(Blocks.can_make_word(word));
            }
        }
    }
}
