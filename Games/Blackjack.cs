using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Cards;

namespace Games.Blackjack
{
   
    public class Blackjack : Game
    {
        private enum printHand
        {
            playerHand,
            dealerHand
        }

        private const int BLACK_JACK = 21;
        private const int BOT_STAND_LIMIT = 18;

        public Deck Deck { get; set; }
        // TODO: allow for read-only access
        private Player _playerTurn { get; set; }
        private bool _playingBot { get; set; }

        public Blackjack(string playerOneName)
        {
            Deck = new Deck();
            buildDeck();
            Deck.Shuffle();

            bool isStillPlaying = true;
            _playingBot = true;
            
            // play
            players = new PlayerCollection();
            players.Add(new Player(playerOneName));
            players.Add(new Player("Dealer"));
            
            _playerTurn = players[0];

            dealNewGame();

            while (isStillPlaying)
            {
                Console.Write("Please type 'hit' or 'stand': ");
                string action = Console.ReadLine();

                switch (action.ToLower())
                {
                    case "hit":
                        addCardToHand(_playerTurn.PlayerHand);
                        // print player hand
                        Console.WriteLine(handToString(printHand.playerHand, true));
                        break;

                    case "stand":
                        endTurn();

                        // check to see if playerTwo is a bot, if they are automate their actions
                        if (_playingBot)
                        {
                            Console.WriteLine(handToString(printHand.playerHand, true));

                            while (countHand() <= BOT_STAND_LIMIT)
                            {
                                Console.WriteLine("-------> Dealer hit's <-------");
                                addCardToHand(_playerTurn.PlayerHand);

                                // print player hand
                                Console.WriteLine(handToString(printHand.playerHand, true));
                            }
                            endTurn();
                        }

                        break;
                }

                // check for winner
                // --- Player 1 WINS ---
                if (
                    countHand(players[0]) > countHand(players[1]) ||
                    countHand(players[0]) == BLACK_JACK ||
                    countHand(players[1]) > BLACK_JACK
                )
                {
                    if (countHand(players[0]) == BLACK_JACK)
                    {
                        Console.WriteLine("Blackjack!");
                    }

                    Console.WriteLine("{0} win's this round", players[0].PlayerName);
                    players[0].GamesWon += 1;
                }
                else
                {
                    Console.WriteLine("{0} win's this round", players[1].PlayerName);
                    players[1].GamesWon += 1;
                }

                players[0].GamesPlayed += 1;
                players[1].GamesPlayed += 1;

                Console.Write("Play again? (Y/N): ");
                string playAgain = Console.ReadLine();

                switch (playAgain.ToLower())
                {
                    case "y":
                        isStillPlaying = true;

                        // deal cards again
                        dealNewGame();
                        break;

                    case "n":
                        isStillPlaying = false;
                        break;
                    
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hand"></param>
        public override void addCardToHand(Hand hand)
        {
            try
            {
                hand.Add(Deck.DrawCard());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void win()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int countHand()
        {
            int handCount = 0;

            foreach (Card card in _playerTurn.PlayerHand)
            {
                handCount += card.Value;    
            }

            return handCount;
        }

        private void dealNewGame()
        {
            addCardToHand(_playerTurn.PlayerHand);  // player 1
            endTurn();  // end player 1 turn

            addCardToHand(_playerTurn.PlayerHand);  // player 2
            endTurn();  // end player 2 turn

            addCardToHand(_playerTurn.PlayerHand);  // player 1
            Console.WriteLine(handToString(printHand.playerHand, true));
            endTurn();  // end player 1 turn

            addCardToHand(_playerTurn.PlayerHand);  // player 2
            Console.WriteLine(handToString(printHand.dealerHand, false));
            endTurn();  // end player 2 turn
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private int countHand(Player player)
        {
            int handCount = 0;

            foreach (Card card in player.PlayerHand)
            {
                handCount += card.Value;
            }

            return handCount;
        }

        /// <summary>
        /// Prints the cards within the players hand
        /// </summary>
        /// <param name="handToPrint">Which hand will be printed, deal will have two cards, but only the first will be printed</param>
        /// <returns></returns>
        private string handToString(printHand handToPrint, bool showDealerHand)
        {
            string handString = null;

            handString += "====== " + _playerTurn.PlayerName + "'s Hand ======\r\n";

            if (handToPrint == printHand.playerHand && showDealerHand)
            {
                handString += _playerTurn.PlayerHand.ToString();
                handString += "Count: " + countHand();
            }
            else if (handToPrint == printHand.dealerHand)
            {
                handString += _playerTurn.PlayerHand[0].ToString();
                handString += "Hidden Card\r\n";
                handString += "Count: " + players[1].PlayerHand[0].Value;
            }
            
            return handString + "\r\n";
        }

        /// <summary>
        /// 
        /// </summary>
        private void endTurn()
        {
            if (_playerTurn == players[0])
            {
                _playerTurn = players[1];
                
            }

            else
            {
                _playerTurn = players[0];
            }
        }

        /// <summary>
        /// Build the deck
        /// </summary>
        private void buildDeck()
        {
            // Hearts
            Deck.Add(new Card(Suit.Hearts, Name.Two, 2));
            Deck.Add(new Card(Suit.Hearts, Name.Three, 3));
            Deck.Add(new Card(Suit.Hearts, Name.Four, 4));
            Deck.Add(new Card(Suit.Hearts, Name.Five, 5));
            Deck.Add(new Card(Suit.Hearts, Name.Six, 6));
            Deck.Add(new Card(Suit.Hearts, Name.Seven, 7));
            Deck.Add(new Card(Suit.Hearts, Name.Eight, 8));
            Deck.Add(new Card(Suit.Hearts, Name.Nine, 9));
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
