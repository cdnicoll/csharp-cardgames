using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Cards;

namespace Games
{
    public abstract class Game
    {
        public abstract void addCardToHand(Hand hand);
        public abstract void win();
    }
}
