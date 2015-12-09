using System;
using System.Collections.Generic;

namespace Blackjack.Model
{
    public interface IPlayer
    {
        /// <summary>
        /// 손에 있던 카드를 모두 턴다.
        /// </summary>
        void InitCards();

        /// <summary>
        /// 카드를 핸드에 넣는다.
        /// </summary>
        /// <param name="gacha">게임 매니저가 준 카드</param>
        void AddCard(Card gacha);

        /// <summary>
        /// 카드 정보를 출력
        /// </summary>
        void DisplayMyCard();

        /// <summary>
        /// 핸드에 있는 카드 정보를 가져옴.
        /// </summary>
        /// <returns></returns>
        List<Card> GetCards();

        /// <summary>
        /// 카드 숫자 합을 계산
        /// </summary>
        /// <returns></returns>
        int GetCount();
    }

    abstract class AbstractPlayer : IPlayer
    {
        private List<Card> cards;
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

        public List<Card> GetCards()
        {
            return cards;   
        }

        public int GetCount()
        {
            int count = 0;
            if(cards != null && cards.Count > 0)
            {
                foreach (var c in cards)
                {
                    int cardCount = c.Number;
                    
                    // 알파벳인 경우 (JQK)
                    if(c.Number > 10)
                    {
                        cardCount = 10; // 10으로 강제 치환
                    }

                    if(c.Number == 1)
                    {
                        cardCount = 1;
                    }
                    // 에이스 인경우
                    count = count + c.Number;
                }
            }
            return count;
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