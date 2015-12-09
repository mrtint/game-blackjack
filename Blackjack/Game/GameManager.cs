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
        public const int BLACK_JACK = 21;
        private const int CARD_COUNT = 52;
        private const int SUIT_SIZE = 4;
        private const int MAX_SIZE = 13;

        private List<Card> cards;
        private List<IPlayer> players;

        private Random random;

        public GameManager()
        {
            cards = new List<Card>(CARD_COUNT);
            players = new List<IPlayer>();

            players.Add(new Dealer());
            random = new Random((int)DateTime.Now.Ticks);
        }

        /// <summary>
        /// Init Cards.
        /// </summary>
        public void InitCards()
        {
            cards.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Card c = new Card(i, j + 1);
                    cards.Add(c);
                }
            }
            Shuffle(cards, 5);
            foreach (var p in players)
            {
                // init Player cards;
                p.InitCards();
            }
        }

        /// <summary>
        /// Show all cards in deck (Only for test)
        /// </summary>
        public void DisplayCards()
        {
            foreach (var item in cards)
            {
                Console.WriteLine(item);
            }
        }

        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public void Hit(IPlayer player)
        {
            int index = random.Next(cards.Count);
            Card gacha = cards[index];
            player.AddCard(gacha);
            cards.RemoveAt(index);
        }

        public void Stay(IPlayer player)
        {

        }

        public void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var p in players)
                {
                    Hit(p);
                }
            }

            Console.WriteLine(string.Format("Deck Size : {0}", cards.Count));

            foreach (var p in players)
            {
                p.DisplayMyCard();
            }
        }

        /// <summary>
        /// Shuffle Card Deck.
        /// </summary>
        /// <param name="listToShuffle"></param>
        /// <param name="numberOfTimesToShuffle"></param>
        private void Shuffle(List<Card> listToShuffle, int numberOfTimesToShuffle = 5)
        {
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
