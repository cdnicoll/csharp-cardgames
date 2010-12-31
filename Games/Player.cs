using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Cards;

namespace Games
{
    public class Player
    {
        public Hand PlayerHand { get; set; }
        public String PlayerName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

        public Player(string name)
        {
            PlayerHand = new Hand();
            PlayerName = name;
            GamesPlayed = 0;
            GamesWon = 0;
        }
    }
}
