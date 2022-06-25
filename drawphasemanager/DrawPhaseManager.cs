using System;
using shared;

namespace drawphasemanager
{
    public interface IDrawPhaseManager : IPhaseManager
    {
        public const int INITIAL_CARD_IN_THE_HAND = 3;
        public const int NO_MORE_CARD = 0;
        void draw(bool isTheAITurn);

        void firstDraw();

        void drawWithoutMana(Player player);
    }

    public class DrawPhaseManagerImpl : IDrawPhaseManager
    {

        private bool _isTheAITurn;

        private readonly Player _player;
        private readonly Player _playerAI;
        private readonly Random _rng = new Random();

        public DrawPhaseManagerImpl(Player player, Player playerAI)
        {
            _player = player;
            _playerAI = playerAI;
        }
        public void draw(bool isTheAITurn)
        {

        }

        public void firstDraw()
        {

        }

        public void drawWithoutMana(Player player)
        {
            
        }

        public void HandleEffect()
        {

        }

    }
}
