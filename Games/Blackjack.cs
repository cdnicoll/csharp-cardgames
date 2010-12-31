using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Cards;

namespace Games.Blackjack
{

    public class Blackjack : Game
    {
        private const int BLACK_JACK = 21;
        private const int BOT_STAND_LIMIT = 18;

        public Deck Deck { get; set; }
        // TODO: allow for read-only access
        private Player _playerOne { get; set; }
        private Player _playerTwo { get; set; }
        private Player _playerTurn { get; set; }
        private bool _playingBot { get; set; }

        public Blackjack()
        {
            Deck = new Deck();
            buildDeck();
            Deck.Shuffle();

            bool win = false;
            _playingBot = true;
            
            // play
            _playerOne = new Player("Player One");
            _playerTwo = new Player("Player Two");
            _playerTurn = _playerOne;

            addCardToHand(_playerTurn.PlayerHand);
            endTurn();
            addCardToHand(_playerTurn.PlayerHand);
            endTurn();
            addCardToHand(_playerTurn.PlayerHand);
            endTurn();
            addCardToHand(_playerTurn.PlayerHand);
            endTurn();

            Console.WriteLine("====== {0}'s turn ======",_playerTurn.PlayerName);
            Console.WriteLine(_playerOne.PlayerHand.ToString());
            Console.WriteLine("Count: {0}",countHand());

            // check for black jack
            if (countHand() == BLACK_JACK)
            {
                Console.WriteLine("Blackjack!");
                win = true;
            }
            else
            {
                Console.WriteLine("====== {0}'s turn ======", _playerTurn.PlayerName);
                Console.WriteLine(_playerTwo.PlayerHand[0].ToString());
                Console.WriteLine("Count: {0}", _playerTwo.PlayerHand[0].Value);
            }

            while (!win)
            {
                Console.Write("Please type 'hit' or 'stand': ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "hit":
                        addCardToHand(_playerTurn.PlayerHand);

                        Console.WriteLine("====== {0}'s turn ======", _playerTurn.PlayerName);
                        Console.WriteLine(_playerOne.PlayerHand.ToString());
                        Console.WriteLine("Count: {0}", countHand());
                        break;

                    case "stand":
                        endTurn();

                        // check to see if playerTwo is a bot, if they are automate their actions
                        if (_playingBot)
                        {
                            while (countHand() <= BOT_STAND_LIMIT)
                            {
                                addCardToHand(_playerTurn.PlayerHand);

                                Console.WriteLine("====== {0}'s turn ======", _playerTurn.PlayerName);
                                Console.WriteLine(_playerOne.PlayerHand.ToString());
                                Console.WriteLine("Count: {0}", countHand());
                            }
                        }

                        // check for winner
                        if (countHand(_playerOne) > countHand(_playerTwo) || countHand(_playerTwo) > BLACK_JACK)
                        {
                            Console.WriteLine("{0} win's this round", _playerOne.PlayerName);
                            win = true;
                        }


                        break;
                }

                

            }


        }

        public override void addCardToHand(Hand hand)
        {
            hand.Add(Deck.DrawCard());
        }

        public override void win()
        {
            
        }

        private int countHand()
        {
            int handCount = 0;

            foreach (Card card in _playerTurn.PlayerHand)
            {
                handCount += card.Value;    
            }

            return handCount;
        }

        private int countHand(Player player)
        {
            int handCount = 0;

            foreach (Card card in player.PlayerHand)
            {
                handCount += card.Value;
            }

            return handCount;
        }

        private void endTurn()
        {
            if (_playerTurn == _playerOne)
            {
                _playerTurn = _playerTwo;
                
            }

            else
            {
                _playerTurn = _playerOne;
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
