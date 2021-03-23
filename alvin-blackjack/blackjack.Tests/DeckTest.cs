using System;
using Xunit;
using blackjack;
using System.Collections.Generic;
using System.Linq;

namespace blackjack.Tests
{
    public class DeckTests
    {

        [Fact]
        public void CreateDeck_52Cards_Test()
        {
            Deck d = new Deck();
            d.CreateDeck();
            Assert.Equal(52, d.Size);
        }
    
        [Fact]
        public void CreateDeck_13ValuesForEachSuit_Test()
        {
            Deck d = new Deck();
            d.CreateDeck();
            foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
            {
                Assert.True(d.CardDeck.Where(c => c.Suit == (suit)).Count() == 13);
            }
        }
    
        [Fact]
        public void DrawFromDeck_Test()
        {
            Deck d = new Deck();
            d.CreateDeck();
            // Set random seed
            // Card c = new Card(.. , ..);

            Assert.True(true);
            // Assert.Equal(d.Draw(), c);
        }
    
    }
}