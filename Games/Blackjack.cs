using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Cards;

namespace Games.Blackjack
{
    public class Blackjack : Game
    {
        public Deck Deck { get; set; }
        public Hand Hand { get; set; }
        private int _handCount;

        public Blackjack()
        {
            Deck = new Deck();
            buildDeck();
            Deck.Shuffle();

            // play
            deal();
            Console.WriteLine(Hand.ToString());
        }

        public override void deal()
        {
            if (Hand == null)
            {
                Hand = new Hand();
            }

            Hand.Add(Deck.DrawCard());
            Hand.Add(Deck.DrawCard());
        }

        public override void win()
        {
            
        }

        private int countHand()
        {
            int handCount = 0;

            foreach (Card card in Hand)
            {
                handCount += card.Value;    
            }

            return handCount;
        }

        /// <summary>
        /// Build the deck
        /// </summary>
        private void buildDeck()
        {
            // Hearts
            Deck.Add(new Card(Suit.Hearts, Name.Two, 2));
            Deck.Add(new Card(Suit.Hearts, Name.Three,3));
            Deck.Add(new Card(Suit.Hearts, Name.Four,4));
            Deck.Add(new Card(Suit.Hearts, Name.Five,5));
            Deck.Add(new Card(Suit.Hearts, Name.Six,6));
            Deck.Add(new Card(Suit.Hearts, Name.Seven,7));
            Deck.Add(new Card(Suit.Hearts, Name.Eight,8));
            Deck.Add(new Card(Suit.Hearts, Name.Nine,9));
            Deck.Add(new Card(Suit.Hearts, Name.Ten,10));
            Deck.Add(new Card(Suit.Hearts, Name.Jack,10));
            Deck.Add(new Card(Suit.Hearts, Name.Queen,10));
            Deck.Add(new Card(Suit.Hearts, Name.King,10));
            Deck.Add(new Card(Suit.Hearts, Name.Ace, 11));
            // Clubs

            // Diamonds

            // Spades
        }
    }
}
