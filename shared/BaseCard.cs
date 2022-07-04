using System;
using System.Collections.Generic;
using System.Text;

namespace shared
{
    public class BaseCard : ICard
    {
       // private string _idCard;
        private string _name;
        private int _lifeValue;
        private int _attackValue;
        private int _manaCost;
        private int _palcementRounds;
        private IEffect _effect;
        private string _imageURL;

        public BaseCard (string name, int lifeValue, int attackValue, int manaCost, string imageURL, IEffect effect )
        {
            _name = name;
            _lifeValue = lifeValue;
            _attackValue = attackValue;
            _manaCost = manaCost;
            _effect = effect;
            _palcementRounds = 0;
            _imageURL = imageURL;
        }



        public string IdCard => throw new NotImplementedException();
        public string Name { get => _name; set => _name = value; }
        public int Attack { get => _attackValue; set => _attackValue = value; }
        public int Mana { get => _manaCost; set => _manaCost = value; }
        public int PlacementRounds { get => _palcementRounds; set => _palcementRounds = value; }
        public int LifePoints { get => _lifeValue; set => _lifeValue = value; }
        public IEffect Effect { get => _effect; set => _effect = value; }
        public string ImageURL { get => _imageURL; set => _imageURL = value; }
    }
}
