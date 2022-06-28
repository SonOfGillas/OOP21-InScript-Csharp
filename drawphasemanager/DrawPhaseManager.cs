using System;
using shared;
using cards;

using System.Collections.Generic;
using System.Linq;

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

        private static Player _player;
        private static Player _playerAI;
        private readonly Random _rng = new Random();

        public DrawPhaseManagerImpl(Player player, Player playerAI)
        {
            _player = player;
            _playerAI = playerAI;
        }

        public void firstDraw()
        {

            IEnumerable<int> range = Enumerable.Range(0, IDrawPhaseManager.INITIAL_CARD_IN_THE_HAND);

            foreach(var elem in range)
            {
                generalDraw(_player);
                generalDraw(_playerAI);
            }

        }

        private void generalDraw(Player player)
        {
            IList<Card> tmpDeck = player.Deck;
            IList<Card> tmpHand = player.Hand;

            if (tmpDeck.Count > IDrawPhaseManager.NO_MORE_CARD)
            {
                int randInt = _rng.Next() % (tmpDeck.Count);
                int index = Math.Abs(randInt);
                int i = 0;

                IEnumerator<Card> iterCard = tmpDeck.GetEnumerator();
                for (;i < index; i++)
                {
                    iterCard.MoveNext();
                }
                tmpHand.Add(iterCard.Current);
                tmpDeck.Remove(iterCard.Current);
            }
        }

        public void draw(bool isTheAITurn)
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
