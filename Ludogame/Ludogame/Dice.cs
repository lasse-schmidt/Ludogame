using System;
using System.Collections.Generic;
using System.Text;

namespace Ludogame
{
    class Dice
    {
        public Random dice;
        public Dice() {
            dice = new Random();
        }
        public int kast()
        {
            return dice.Next(1, 7);
        }
    }
}
