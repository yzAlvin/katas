using System;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Hand
    {
        private int _value;
        public int Value
        { 
            get 
            { 
                int total = Cards.Sum(c => (int) c.Value);
                return total; 
            }
            private set { _value = value; }
        }
        public int HandSize { get; private set; }
        public List<Card> Cards = new List<Card>();

        public void AddCard(Card c)
        {
            HandSize += 1;
            Cards.Add(c);
            IncreaseValue(c); 
        }

        private void IncreaseValue(Card c)
        {
            int cardValue = (int) c.Value;
            this.Value += cardValue;

            while (IsBust() && Cards.Where(c => c.Value == Card.CardValue.Ace).Count() > 0)
            {
                Card aceToRemove = Cards.Find(c => c.Value == Card.CardValue.Ace);
                Cards.Remove(aceToRemove);
                Cards.Add(new Card(Card.CardValue.One, aceToRemove.Suit));
            }
        }

        public bool IsBust()
        {
            return Value > 21;
        }

        public override string ToString()
        {
            return String.Join(", ", Cards.Select(c => $"{c.ToString()}")) + $" [{Value}]";
        }

    }
}