using System;
using shared;
using cards;

using System.Collections.Generic;
using System.Linq;

namespace mainphasemanager
{

    public interface IMainPhaseManager : IPhaseManager
    {
        void Positioning(Card cardToBePositioned, int boardCellIndex, bool isTheAITurn);

    }
    public class MainPhaseManagerImpl : IMainPhaseManager
    {
        private bool _isTheAITurn;
        private bool _canPlace;
        private bool _cellEmpty;

        public bool CanPlace
        {
            get => _canPlace;
            set => _canPlace = value;
        }
        public bool CellEmpty
        {
            get => _cellEmpty;
            set => _cellEmpty = value;
        }

        private Player _player;
        private Player _playerAI;

        public MainPhaseManagerImpl(Player player, Player playerAI)
        {
            _player = player;
            _playerAI = playerAI;
        }
        public void HandleEffect()
        {

            if (_isTheAITurn)
            {
                ActiveEvent(_playerAI);
            }
            else
            {
                ActiveEvent(_player);
            }

        }

        public void Positioning(Card cardToBePositioned, int boardCellIndex, bool isTheAITurn)
        {
            _isTheAITurn = isTheAITurn;

            if (_isTheAITurn && IsEnoughTheMana(_playerAI, cardToBePositioned))
            {
                PlayerPositioning(_playerAI, cardToBePositioned, boardCellIndex);

                HandleEffect();
            }
            else if (!_isTheAITurn && IsEnoughTheMana(_player, cardToBePositioned))
            {
                PlayerPositioning(_player, cardToBePositioned, boardCellIndex);

                HandleEffect();
            }
        }

        private void PlayerPositioning(Player currentPlayer, Card cardToBePositioned, int boardCellIndex)
        {
            IList<Card> tmpBoard = currentPlayer.CurrentBoard;
            IList<Card> tmpHand = currentPlayer.Hand;

            if (IsCellEmpty(tmpBoard, boardCellIndex))
            {
                /* cardToBePositioned.SetPlacementRounds(Card.FirstRoundPlaced); */
                tmpBoard.Insert(boardCellIndex, cardToBePositioned);

                tmpHand.Remove(cardToBePositioned);
                /* currentPlayer.SetCurrentMana(-cardToBePositioned.Mana); */

            }
        }

        private void ActiveEvent(Player player)
        {
            IList<Card> tmpBoard = player.CurrentBoard;

            IEnumerable<int> range = Enumerable.Range(0, tmpBoard.Count);

            foreach (var index in range)
            {
                if (tmpBoard.ElementAt(index) != null)
                {
                    Card cardSaved = tmpBoard.ElementAt(index);

                    /* if () Miss Card class to complete this part */
                }
            }
        }

        private bool IsEnoughTheMana(Player player, Card cardToBePositioned)
        {
            /*
            CanPlace = player.CurrentMana - cardToBePositioned.Mana >= IMainPhaseManager.NO_ENOUGH_MANA;
            return CanPlace;
            */
            return false;
        }

        private bool IsCellEmpty(IList<Card> board, int boardCellIndex)
        {
            if (board.ElementAt(boardCellIndex) == null)
            {
                CellEmpty = true;
            }
            else
            {
                CellEmpty = false;
            }
            return CellEmpty;
        }


    }

}
