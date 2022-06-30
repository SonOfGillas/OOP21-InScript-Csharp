using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cards;
using shared;

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
        public Card? SelectedCardToPlace { get; set; }
        public Card? SelectedCardToShow { get; set; }
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
            List<Card>  playerDeck = new List<Card>();
            List<Card> aIDeck = new List<Card>();
            _gameMaster = new GameMaster(playerDeck, aIDeck);

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
