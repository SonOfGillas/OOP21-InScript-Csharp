using gamemaster;
using drawphasemanager;
using cards;
using shared;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    [TestClass]
    public class DrawPhaseManagerTests
    {

        private GameMaster _gameMaster;
        private IDrawPhaseManager _drawPhase;
        private Player _humanPlayer;
        private Player _aiPlayer;

        [TestInitialize]
        public void TestInitialize()
        {
            List<Card> deck = new List<Card>();
            IEnumerable<int> range = Enumerable.Range(0, 20);

            foreach (int i in range)
            {
                deck.Add(new Card());
            }

            _gameMaster = new GameMaster(deck, deck);
            _drawPhase = _gameMaster.DrawPhaseManager;
            _humanPlayer = _gameMaster.HumanPlayer;
            _aiPlayer = _gameMaster.AiPlayer;

        }

        [TestMethod]
        public void FirstDraw()
        {
            Assert.AreEqual(19, _humanPlayer.Deck.Count);
        }
    }
}
