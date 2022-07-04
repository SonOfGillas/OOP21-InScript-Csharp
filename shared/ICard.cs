using System;

namespace shared
{
    public interface ICard
    {
        public string IdCard { get; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Mana { get; set; }
        public int PlacementRounds { get; set; }
        public int LifePoints { get; set; }
        public IEffect Effect { get; set; }
        public string ImageURL { get; set; }

       
    }
}
