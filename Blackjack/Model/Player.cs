using System;
using System.Collections.Generic;

namespace Blackjack.Model
{
    interface Player
    {
        void InitCards();
    }

    abstract class AbstractPlayer : Player
    {
        List<Card> Cards;
        public string Name { get; set; }
        

        public long Money { get; set; }

        public long Bet { get; set; }
        

        public AbstractPlayer()
        {
            Cards = new List<Card>();
        }

        public void InitCards()
        {
            Cards.Clear();
        }
    }

    class Dealer : AbstractPlayer
    {
        public Dealer()
        {
            Name = "Dealer";
        }
    }

    class User : AbstractPlayer
    {
        public User(String Name)
        {
            this.Name = Name;
        }
    }
}