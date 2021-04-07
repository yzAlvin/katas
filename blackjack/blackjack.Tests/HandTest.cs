using System;
using Xunit;
using blackjack;
using System.Collections.Generic;
using System.Linq;

namespace blackjack.Tests
{

    public class HandTests
    {
        [Fact]
        public void CanAddCard_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Three, Card.CardSuit.Spade);
            Card cardTwo = new Card(Card.CardValue.Two, Card.CardSuit.Spade);

            var hand = new List<Card>(){cardOne, cardTwo};

            h.AddCard(cardOne);
            h.AddCard(cardTwo);

            Assert.True(h.HandSize  == 2);
            Assert.True(h.Value == 5);
            Assert.True(h.Cards.All(card => hand.Contains(card)));
        }
        [Fact]
        public void AceValue_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            Card cardTwo = new Card(Card.CardValue.Two, Card.CardSuit.Spade);

            var hand = new List<Card>(){cardOne, cardTwo};

            h.AddCard(cardOne);
            h.AddCard(cardTwo);

            Assert.True(h.HandSize  == 2);
            Assert.True(h.Value == 13);
            Assert.True(h.Cards.All(card => hand.Contains(card)));
        }
        [Fact]
        public void IsBust_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Ten, Card.CardSuit.Spade);
            Card cardTwo = new Card(Card.CardValue.Ten, Card.CardSuit.Heart);
            Card cardThree = new Card(Card.CardValue.Ten, Card.CardSuit.Club);

            h.AddCard(cardOne);
            h.AddCard(cardTwo);
            h.AddCard(cardThree);

            Assert.True(h.IsBust());
        }
        [Fact]
        public void IsBust_False_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Ten, Card.CardSuit.Spade);
            Card cardTwo = new Card(Card.CardValue.Ten, Card.CardSuit.Heart);

            h.AddCard(cardOne);
            h.AddCard(cardTwo);

            Assert.False(h.IsBust());
        }
        [Fact]
        public void ValueWithAce_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            Card cardTwo = new Card(Card.CardValue.Ten, Card.CardSuit.Heart);
            Card cardThree = new Card(Card.CardValue.Ten, Card.CardSuit.Club);

            h.AddCard(cardOne);
            h.AddCard(cardTwo);
            h.AddCard(cardThree);

            Assert.True(h.Value == 21);
        }
        [Fact]
        public void ValueWithTwoAces_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);
            Card cardTwo = new Card(Card.CardValue.Ace, Card.CardSuit.Heart);
            Card cardThree = new Card(Card.CardValue.Ten, Card.CardSuit.Club);

            h.AddCard(cardOne);
            h.AddCard(cardTwo);
            h.AddCard(cardThree);

            Assert.True(h.Value == 12);
        }
        [Fact]
        public void ValueWithFiveAces_Test()
        {
            Hand h = new Hand();
            Card cardOne = new Card(Card.CardValue.Ace, Card.CardSuit.Spade);

            h.AddCard(cardOne);
            h.AddCard(cardOne);
            h.AddCard(cardOne);
            h.AddCard(cardOne);
            h.AddCard(cardOne);

            Assert.True(h.Value == 15);
        }
    }
}