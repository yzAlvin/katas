using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System;

namespace blackjack
{
    public class Card
    {
        public enum CardValue
        {
            Ace = 11,
            One = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack = 10,
            Queen = 10,
            King = 10
        }
        public enum CardSuit
        {
            Spade,
            Heart,
            Club,
            Diamond
        }

        static public Dictionary<string,CardValue> cardValueDict = new Dictionary<string, CardValue> {
            { "Ace", CardValue.Ace },
            {"One", CardValue.One}, 
            {"Two", CardValue.Two},
            {"Three", CardValue.Three},
            {"Four", CardValue.Four},
            {"Five", CardValue.Five},
            {"Six", CardValue.Six},
            {"Seven", CardValue.Seven},
            {"Eight", CardValue.Eight},
            {"Nine", CardValue.Nine},
            {"Ten", CardValue.Ten},
            {"Jack", CardValue.Jack},
            {"Queen", CardValue.Queen},
            {"King", CardValue.King}
        };

        public CardValue Value
        {
            get; private set;
        }
        public CardSuit Suit
        {
            get; private set;
        }

        public Card(CardValue value, CardSuit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"{this.Value} of {this.Suit}s";
        }

        public bool IsHigher(Card other)
        {
            int ResultOfComparison = this.Value.CompareTo(other.Value);
            return ResultOfComparison > 0;
        }
        
    }
}

