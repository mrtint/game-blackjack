using System.Collections.Generic;

namespace Blackjack.Source
{
    public class Card
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

    public enum Suit
    {
        Spade = 0, Diamond = 1, Heart = 2, Clover = 3
    }

    public class Deck
    {
        private List<Card> cards = new List<Card>(52);

        public Deck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card c = new Card(i, j + 1);
                    cards.Add(c);
                }
            }
            Util.Shuffle(cards);
        }
    }

    public class Shoe
    {
        private List<Deck> decks;

        public Shoe() : this(1)
        {
            
        }

        public Shoe(int count)
        {
            decks = new List<Deck>(count);
            for (int i = 0; i < count; i++)
            {
                decks.Add(new Deck());
            }
        }
    }
}