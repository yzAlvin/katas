using System.Linq;
using System;


using System.Collections.Generic;

namespace blackjack
{
    public class Deck
    {
        
        public int Size
        {
            get{ return CardDeck.Count(); }
        }

        public List<Card> CardDeck = new List<Card>();

        public void CreateDeck()
        {
            foreach (string v in Enum.GetNames(typeof(Card.CardValue)).Where(c => c != "One"))
            {
                foreach (string s in Enum.GetNames(typeof(Card.CardSuit)))
                {
                    Card c = new Card(Card.cardValueDict[v], Enum.Parse<Card.CardSuit>(s));
                    CardDeck.Add(c);
                }
            }
        }

        public Card Draw()
        {
            Random random = new Random();
            Card c = CardDeck[random.Next(CardDeck.Count)];
            CardDeck.Remove(c);
            return c;
        }
        
    }
}