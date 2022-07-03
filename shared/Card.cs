using System;

namespace shared
{
    public class Card
    {
        public int Attack { get; set; }
        public int Mana { get; set; }
        public int PlacementRounds { get; set; }
        public int LifePoints { get; set; }
        public IEffect Effect { get; }

        public Card()
        {

        }
    }
}
