using shared;
using cards;

using System.Collections.Generic;

namespace gamemaster
{
    public interface IGameMasterController
    {
        public void OnCardPlacing(int indexOfTheCellInTheBoard);
        public void OnEndTurn();
    }

    public class GameMasterController : IGameMasterController
    {

        private GameMaster _gameMaster;
        private Player _humanPlayer;
        private Player _aiPlayer;
        public BaseCard? SelectedCardToPlace { get; set; }
        public BaseCard? SelectedCardToShow { get; set; }
        public Player HumanPlayer
        {
            get => _humanPlayer;
        }
        public Player AiPlayer
        {
            get => _aiPlayer;
        }

        public GameMasterController()
        {
            List<BaseCard> playerDeck = new List<BaseCard>();
            List<BaseCard> aIDeck = new List<BaseCard>();
            _gameMaster = new GameMaster(playerDeck, aIDeck);
            _gameMaster.StartGame();

            _humanPlayer = _gameMaster.HumanPlayer;
            _aiPlayer = _gameMaster.AiPlayer;
        }

        private bool CheckGameEnd()
        {
            if (HumanPlayer.LifePoints <= GameConst.MinPlayerLife)
            {
                return true;
            }
            if (AiPlayer.LifePoints <= GameConst.MinPlayerLife)
            {
                return true;
            }
            if (HumanPlayer.Deck.Count <= 0 || AiPlayer.Deck.Count <= 0)
            {
                return true;
            }
            return false;
        }

        public void OnCardPlacing(int indexOfTheCellInTheBoard)
        {
            if (SelectedCardToPlace != null)
            {
                _gameMaster.MainPhaseManager.Positioning(SelectedCardToPlace, indexOfTheCellInTheBoard, false);
                SelectedCardToPlace = null;
            }
        }

        public void OnEndTurn()
        {
            _gameMaster.BattlePhaseManager.StartBattle(false);
            if (CheckGameEnd()) return;
            _gameMaster.DrawPhaseManager.Draw(true);
            if (CheckGameEnd()) return;
            _gameMaster.MainPhaseManagerIA.StartAIMainPhase();
            if (CheckGameEnd()) return;
            _gameMaster.BattlePhaseManager.StartBattle(true);
            if (CheckGameEnd()) return;
            _gameMaster.DrawPhaseManager.Draw(false);
            if (CheckGameEnd()) return;
        }
    }

}
