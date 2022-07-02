using System;
using shared;
using cards;

using System.Collections.Generic;
using System.Linq;

namespace drawphasemanager
{
    public interface IDrawPhaseManager : IPhaseManager
    {
        public static readonly int InitialCardInTheHand = 3;
        public static readonly int NoMoreCard = 0;
        void Draw(bool isTheAITurn);

        void FirstDraw();

        void DrawWithoutMana(Player player);
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

            SelectEventAndPlayer(ActivationEvent.EVERYDRAW, _playerAI);
            SelectEventAndPlayer(ActivationEvent.EVERYDRAW, _player);

            if (_isTheAITurn)
            {
                SelectEventAndPlayer(ActivationEvent.MYDRAW, _playerAI);
                SelectEventAndPlayer(ActivationEvent.ENEMYDRAW, _player);
            } else
            {
                SelectEventAndPlayer(ActivationEvent.MYDRAW, _player);
                SelectEventAndPlayer(ActivationEvent.ENEMYDRAW, _playerAI);
            }
        }

        public void FirstDraw()
        {

            IEnumerable<int> range = Enumerable.Range(0, IDrawPhaseManager.InitialCardInTheHand);

            foreach(var elem in range)
            {
                GeneralDraw(_player);
                GeneralDraw(_playerAI);
            }

        }

        public void Draw(bool isTheAITurn)
        {
            _isTheAITurn = isTheAITurn;

            if (_isTheAITurn && _playerAI.Deck.Count > 0)
            {
                UpdatePlacementRounds(_playerAI);
                RestoreMana(_playerAI);
                GeneralDraw(_playerAI);

                HandleEffect();
            } else if (_player.Deck.Count > 0)
            {
                UpdatePlacementRounds(_player);
                RestoreMana(_player);
                GeneralDraw(_player);

                HandleEffect();
            }
        }

        private void GeneralDraw(Player player)
        {
            IList<Card> tmpDeck = player.Deck;
            IList<Card> tmpHand = player.Hand;

            if (tmpDeck.Count > IDrawPhaseManager.NoMoreCard)
            {
                int randInt = _rng.Next() % (tmpDeck.Count);
                int index = Math.Abs(randInt);

                tmpHand.Add(tmpDeck.ElementAt(index));
                tmpDeck.RemoveAt(index);
            }
        }

        public void DrawWithoutMana(Player player)
        {
            GeneralDraw(player);
        }

        private void SelectEventAndPlayer(ActivationEvent event_, Player player) 
        {

            IList<Card> tmpBoard = player.CurrentBoard;

            for (int pos = 0; pos <= tmpBoard.Count - 1; pos++)
            {
                if(tmpBoard.ElementAt(pos) != null)
                {
                    Card cardSaved = tmpBoard.ElementAt(pos);

                    if (cardSaved.Effect != null && cardSaved.Effect.ActivationEvent == event_)
                    {
                        if (player.IsAiPlayer)
                        {
                            cardSaved.Effect.UseEffect(_playerAI, _player, pos);
                        }
                        else
                        {
                            cardSaved.Effect.UseEffect(_player, _playerAI, pos);
                        }
                    }
                }
            }

        }

        private void RestoreMana(Player player)
        {
            if (player.Mana + GameConst.ManaPlusOne <= GameConst.MaximumMana)
            {
                player.Mana = GameConst.MaximumMana;
            }

            player.CurrentMana = player.Mana - player.CurrentMana;
        }

        private void UpdatePlacementRounds(Player player)
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
