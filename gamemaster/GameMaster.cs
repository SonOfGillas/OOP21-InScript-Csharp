using System.Collections.Generic;
using cards;
using shared;
using drawphasemanager;


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

        bool isTheAIturn; // TODO verify if change must be do here or in the board controller

        private IDrawPhaseManager drawPhaseManager;
        private IMainPhaseManager mainPhaseManager;
        private IBattlePhaseManager battlePhaseManager;
        private IMainPhaseManagerIA mainPhaseManagerIA;

        public GameMaster(IList<Card> humanPlayerDeck, IList<Card> aiPlayerDeck)
        {

        }

        public void StartGame() { }
    }
}
