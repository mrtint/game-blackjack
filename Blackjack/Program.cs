using Blackjack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Player user = new User("Hansan", 5000);
            GameManager gm = new GameManager();
            gm.InitCards();
            gm.DisplayCards();
            gm.AddPlayer(user);

            gm.Start();
        }
    }
}
