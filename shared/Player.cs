using System;

namespace shared
{

    public class Player
    {
        public static int NUM_CARD_BOARD=5;

        private int _mana;
        private int _currentMana;
        private IList<Card?> _currentBoard;

        public boolean IsAiPlayer = { get ; }
        public IList<Card> Deck = { get ; }
        public int LifePoints = { get ; set ; }
        public int CurrentMana  = { get ; set ; }
        public IList<Card> Hand  = { get ;  }

        public int Mana
        {
            get => _mana ;
            set = > _mana = _mana + value;
        }

        public int CurrentMana
        {
            get => _currentMana ;
            set = > _currentMana = _currentMana + value;
        }

        public int CurrentBoard
        {
            get => _currentBoard.take(NUM_CARD_BOARD);
        }

        public Player(final boolean isAiplayer, final List<Card> deck, final int lifePoints, final int mana, final int currentMana, final List<Optional<Card>> currentBoard, final List<Card> hand) {
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
