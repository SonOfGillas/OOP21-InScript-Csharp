using System.Collections.Generic;
using cards;
using shared;

namespace gamemaster
{

    public interface IGameMaster
    {
        public void StartGame();
    }
    class GameMaster : IGameMaster
    {

        private Player humanPlayer;
        private Player aiPlayer;

        boolean isTheAIturn; // TODO verify if change must be do here or in the board controller

        private DrawPhaseManager drawPhaseManager;
        private MainPhaseManager mainPhaseManager;
        private BattlePhaseManager battlePhaseManager;
        private MainPhaseManagerIA mainPhaseManagerIA;

        public GameMaster(IList<Card> humanPlayerDeck, IList<Card> aiPlayerDeck)
        {

        }

        public void StartGame() { }
    }
}
