using System;
using shared;
using cards;

using System.Collections.Generic;
using System.Linq;

namespace mainphasemanager
{

    public interface IMainPhaseManager : IPhaseManager
    {
        bool CanPlace { get; set; }
        bool CellEmpty { get; set; }
        void Positioning(BaseCard cardToBePositioned, int boardCellIndex, bool isTheAITurn);

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

        public void Positioning(BaseCard cardToBePositioned, int boardCellIndex, bool isTheAITurn)
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

        private void PlayerPositioning(Player currentPlayer, BaseCard cardToBePositioned, int boardCellIndex)
        {
            IList<BaseCard> tmpBoard = currentPlayer.CurrentBoard;
            IList<BaseCard> tmpHand = currentPlayer.Hand;

            if (IsCellEmpty(tmpBoard, boardCellIndex))
            {
                cardToBePositioned.PlacementRounds = GameConst.FirstRoundPlaced;
                tmpBoard.Insert(boardCellIndex, cardToBePositioned);

                tmpHand.Remove(cardToBePositioned);
                currentPlayer.Mana = -cardToBePositioned.Mana;

            }
        }

        private void ActiveEvent(Player player)
        {
            IList<BaseCard> tmpBoard = player.CurrentBoard;

            IEnumerable<int> range = Enumerable.Range(0, tmpBoard.Count - 1);

            foreach (var index in range)
            {
                if (tmpBoard.ElementAt(index) != null && index <= tmpBoard.Count - 1)
                {
                    BaseCard cardSaved = tmpBoard.ElementAt(index);

                    if (cardSaved.Effect != null && cardSaved.Effect.ActivationEvent == ActivationEvent.POSITIONING 
                        && cardSaved.PlacementRounds <= GameConst.MaximumUseEffect)
                    {

                        if(player.IsAiPlayer)
                        {
                            cardSaved.Effect.UseEffect(_playerAI, _player, index);
                            cardSaved.PlacementRounds += 1;
                        }
                        else
                        {
                            cardSaved.Effect.UseEffect(_player, _playerAI, index);
                            cardSaved.PlacementRounds += 1;
                        }

                    }
                }
            }
        }

        private bool IsEnoughTheMana(Player player, BaseCard cardToBePositioned)
        {
            CanPlace = player.CurrentMana - cardToBePositioned.Mana >= GameConst.NoEnoughMana;
            return CanPlace;
        }

        private bool IsCellEmpty(IList<BaseCard> board, int boardCellIndex)
        {
            BaseCard card = board.ElementAt(boardCellIndex);
            if (card == null)
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
