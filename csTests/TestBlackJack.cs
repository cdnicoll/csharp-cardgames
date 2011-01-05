using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using csUnit;

using Games.Blackjack;
using BusinessLogic.Cards;

namespace csTests
{
    [TestFixture]
    public class TestBlackJack
    {
        [Test]
        public void BlackJack()
        {
            Hand hand = new Hand();
            hand.Add(new Card(Suit.Clubs, Name.Ace, 11));
            hand.Add(new Card(Suit.Clubs, Name.Jack, 10));

            int count = hand[0].Value + hand[1].Value;

            Assert.Equals(21, count);
        }

    }
}
