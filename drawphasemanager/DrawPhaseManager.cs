using System;
using shared;
using cards;
using gamemaster;

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

        public void HandleEffect()
        {

            selectEventAndPlayer(ActivationEvent.EVERYDRAW, _playerAI);
            selectEventAndPlayer(ActivationEvent.EVERYDRAW, _player);

            if (_isTheAITurn)
            {
                selectEventAndPlayer(ActivationEvent.MYDRAW, _playerAI);
                selectEventAndPlayer(ActivationEvent.ENEMYDRAW, _player);
            } else
            {
                selectEventAndPlayer(ActivationEvent.MYDRAW, _player);
                selectEventAndPlayer(ActivationEvent.ENEMYDRAW, _playerAI);
            }
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

        public void draw(bool isTheAITurn)
        {
            _isTheAITurn = isTheAITurn;

            if (_isTheAITurn && _playerAI.Deck.Count > 0)
            {
                updatePlacementRounds(_playerAI);
                restoreMana(_playerAI);
                generalDraw(_playerAI);

                HandleEffect();
            } else if (_player.Deck.Count > 0)
            {
                updatePlacementRounds(_player);
                restoreMana(_player);
                generalDraw(_player);

                HandleEffect();
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

                tmpHand.Add(tmpDeck.ElementAt(index));
                tmpDeck.RemoveAt(index);
            }
        }

        public void drawWithoutMana(Player player)
        {
            generalDraw(player);
        }

        private void selectEventAndPlayer(ActivationEvent event_, Player player) 
        {

            IList<Card?> tmpBoard = player.CurrentBoard;

            for (int pos = 0; pos <= tmpBoard.Count - 1; pos++)
            {
                if(tmpBoard.ElementAt(pos) != null)
                {
                    Card cardSaaved = tmpBoard.ElementAt(pos);

                    /* if (Card) */
                }
            }

        }

        private void restoreMana(Player player)
        {
            if (player.Mana + IGameMaster.MANA_PLUS_ONE <= IGameMaster.MAXIMUM_MANA)
            {
                player.Mana = IGameMaster.MAXIMUM_MANA;
            }

            player.CurrentMana = player.Mana - player.CurrentMana;
        }

        private void updatePlacementRounds(Player player)
        {
            IList<Card> tmpBoard = player.CurrentBoard;

            foreach (var card in tmpBoard)
            {
                if (card != null)
                {
                    /* card.get set placement */
                }
            }
        }

    }
}
