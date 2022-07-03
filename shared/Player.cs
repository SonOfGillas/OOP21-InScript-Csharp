using System;
using cards;
using System.Collections.Generic;

namespace shared
{

    public class Player
    {
        public static readonly int NumCardBoard = 5;

        private int _mana;
        private int _currentMana;

        public bool IsAiPlayer { get ; }
        public IList<Card> Deck { get ; }
        public IList<Card> Hand  { get ;  }
        public IList<Card> CurrentBoard { get; set; }
        public int LifePoints { get; set; } 

        public int Mana
        {
            get => _mana ;
            set => _mana = _mana + value;
        }

        public int CurrentMana
        {
            get => _currentMana ;
            set => _currentMana = _currentMana + value;
        }

        public Player(bool isAiplayer,  List<Card> deck,  int lifePoints,  int mana,  int currentMana,  List<Card> currentBoard,  List<Card> hand) {
            IsAiPlayer= isAiplayer;
            Deck = deck;
            LifePoints = lifePoints;
            Mana = mana;
            CurrentMana = currentMana;
            CurrentBoard = currentBoard;
            Hand = hand;
        }
    }

}
