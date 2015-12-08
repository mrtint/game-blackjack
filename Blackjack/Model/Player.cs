using System;
using System.Collections.Generic;

namespace Blackjack.Model
{
    public interface Player
    {
        void InitCards();
        void AddCard(Card gacha);
        void DisplayMyCard();
    }

    abstract class AbstractPlayer : Player
    {
        private List<Card> cards;

        public List<Card> Cards { get; private set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int Bet { get; set; }

        public AbstractPlayer()
        {
            cards = new List<Card>();
        }

        public void InitCards()
        {
            cards.Clear();
        }

        public void AddCard(Card gacha)
        {
            cards.Add(gacha);
        }

        public void DisplayMyCard()
        {
            Console.WriteLine(string.Format("==============={0}'s Card===============", Name));
            foreach (var item in cards)
            {
                Console.WriteLine(item);
            }
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
        public User(String name, int money)
        {
            this.Name = name;
            this.Money = money;
        }
    }
}