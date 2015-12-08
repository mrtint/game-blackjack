﻿namespace Blackjack.Model
{
    class Card
    {
        public Suit Suit { get; }
        public int Number { get; }

        public Card(int SuitNumber, int Number)
        {
            this.Suit = (Suit)SuitNumber;
            this.Number = Number;
        }

        public override string ToString()
        {
            return Suit + " | " + Number;
        }
    }

    internal enum Suit
    {
        Spade = 0, Diamond = 1, Heart = 2, Clover = 3
    }
}