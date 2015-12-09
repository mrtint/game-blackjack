using Blackjack.Source;
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
            IPlayer user = new User("Hansan", 5000);
            Game gm = new Game();
            gm.InitCards();
            gm.DisplayCards();
            gm.AddPlayer(user);

            gm.Start();
        }
    }
}
