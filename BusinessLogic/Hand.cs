using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Cards
{
    public class Hand : List<Card>
    {

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
