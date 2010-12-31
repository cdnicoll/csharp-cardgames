using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Cards
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Name
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Name Name {get; set;}
        public int Value { get; set; }

        public Card(Suit suit, Name name, int value)
        {
            Suit = suit;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return String.Format("Suit: {0} Value: {1}\r\n", Suit, Name);
        }
    }
}
