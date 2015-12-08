using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Model
{
    public class GameManager
    {
        private const int CARD_COUNT = 52;
        private const int SUIT_SIZE = 4;
        private const int MAX_SIZE = 13;

        private List<Card> Cards;
        private List<Player> Players;

        public GameManager()
        {
            Cards = new List<Card>(CARD_COUNT);
        }

        public void InitCards()
        {
            Cards.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card c = new Card(i, j + 1);
                    Cards.Add(c);
                }
            }
            Shuffle(Cards, 5);
        }

        public void DisplayCards()
        {
            foreach (var item in Cards)
            {
                Console.WriteLine(item);
            }
        }

        private void Shuffle(List<Card> listToShuffle, int numberOfTimesToShuffle = 5)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            List<Card> newList = new List<Card>();

            for (int i = 0; i < numberOfTimesToShuffle; i++)
            {
                while (listToShuffle.Count > 0)
                {
                    int index = random.Next(listToShuffle.Count);
                    newList.Add(listToShuffle[index]);
                    listToShuffle.RemoveAt(index);
                }
                listToShuffle.AddRange(newList);
                newList.Clear();
            }
        }
    }
}
