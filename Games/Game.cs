using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Cards;

namespace Games
{
    public abstract class Game
    {
        public PlayerCollection players;

        public virtual void defaultCommands(string input)
        {
            switch (input)
            {
                case "score":
                    break;
            }
        }
        public abstract void addCardToHand(Hand hand);
        public abstract void win();
    }
}
