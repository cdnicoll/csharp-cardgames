using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utilities;

namespace BusinessLogic.Cards
{
    public class Deck : List<Card>
    {
        private const int TIMES_TO_SHUFFLE = 20;
        private const int SINGLE_CARD = 1;

        public Card DrawCard()
        {
            if(!canDrawCards(SINGLE_CARD)) 
            {
                throw new Exception("Not enough cards in deck to draw from");
            }

            Card card = this[0];
            this.RemoveAt(0);

            return card;
        }

        /// <summary>
        /// shuffle (X) amount of times
        /// swap indexA with indexB
        ///     index will be a random number dependent on the size of the deck
        /// </summary>
        public void Shuffle()
        {
            int count = 0;
            int amountOfCardsInDeck = this.Count;
            Random rand = new Random();
            int cardA = 0;
            int cardB = 0;

            while (count < TIMES_TO_SHUFFLE)
            {
                cardA = rand.Next(amountOfCardsInDeck);
                cardB = rand.Next(amountOfCardsInDeck);

                if (cardA != cardB)
                {
                    this.Swap(cardA, cardB);
                    count++;
                }
                
            }
        }

        private bool canDrawCards(int amountToDraw)
        {
            if (this.Count >= amountToDraw && this.Count != 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// String output
        /// </summary>
        /// <returns>String of cards in deck</returns>
        public override string ToString()
        {
            string cards = null;

            foreach (Card card in this)
            {
                cards += card.ToString();
            }

            return cards;
        }
    }
}
