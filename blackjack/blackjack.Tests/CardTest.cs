using System;
using Xunit;
using blackjack;
using System.Collections.Generic;
using System.Linq;

namespace blackjack.Tests
{
    public class CardTests
    {
        [Fact]
        public void HasSuit_Test()
        {
            Card a = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            Assert.True(a.Suit == Card.CardSuit.Spade);            
        }
        [Fact]
        public void HasValue_Test()
        {
            Card a = new Card(Card.CardValue.Ace, Card.CardSuit.Heart);
            Assert.True(a.Value == Card.CardValue.Ace);            
        }
        [Fact]
        public void ToString_Test()
        {
            Card a = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            Assert.Equal("Ace of Spades", a.ToString());       
        }
        [Fact]
        public void CanCompareValue_Test()
        {
            Card a = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            Card b = new Card(Card.CardValue.Two, Card.CardSuit.Spade);
            Assert.True(a.IsHigher(b));            
        }
        [Fact]
        public void CanCompareValue_False_Test()
        {
            Card a = new Card(Card.CardValue.Three, Card.CardSuit.Spade);
            Card b = new Card(Card.CardValue.Two, Card.CardSuit.Spade);
            Assert.False(b.IsHigher(a));            
        }
        [Fact]
        public void CanCompareValue_PictureCards_Test()
        {
            Card a = new Card(Card.CardValue.Jack, Card.CardSuit.Spade);
            Card b = new Card(Card.CardValue.Queen, Card.CardSuit.Spade);
            Assert.False(a.IsHigher(b));            
        }
        [Fact]
        public void CanCompareValue_SameValues_Test()
        {
            Card a = new Card(Card.CardValue.Three, Card.CardSuit.Spade);
            Card b = new Card(Card.CardValue.Three, Card.CardSuit.Heart);
            Assert.False(a.IsHigher(b));            
        }
        [Fact]
        public void CanCompareValue_TenAndPicture_Test()
        {
            Card a = new Card(Card.CardValue.Ten, Card.CardSuit.Spade);
            Card b = new Card(Card.CardValue.King, Card.CardSuit.Heart);
            Assert.False(a.IsHigher(b));            
        }
        
    }
    
}
