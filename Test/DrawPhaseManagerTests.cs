using gamemaster;
using drawphasemanager;
using shared;
using effects;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    [TestClass]
    public class DrawPhaseManagerTests
    {
        public static bool AiTurn = true;
        public static bool PlayerTurn = false;

        private GameMaster _gameMaster;
        private IDrawPhaseManager _drawPhase;
        private Player _humanPlayer;
        private Player _aiPlayer;

        [TestInitialize]
        public void TestInitialize()
        {
            List<BaseCard> deck1 = new List<BaseCard>();
            List<BaseCard> deck2 = new List<BaseCard>();
            IEnumerable<int> range = Enumerable.Range(0, 20);

            foreach (int i in range)
            {
                deck1.Add(new BaseCard("cane", 1, 1, 2, "cane.png", new Draw()));
                deck2.Add(new BaseCard("cane", 1, 1, 2, "cane.png", new Draw()));
            }

            _gameMaster = new GameMaster(deck1, deck2);
            _drawPhase = _gameMaster.DrawPhaseManager;
            _humanPlayer = _gameMaster.HumanPlayer;
            _aiPlayer = _gameMaster.AiPlayer;

        }

        [TestMethod]
        public void FirstDraw()
        {
            Assert.AreEqual(20, _humanPlayer.Deck.Count);
            Assert.AreEqual(20, _aiPlayer.Deck.Count);

            _drawPhase.FirstDraw();

            Assert.AreEqual(17, _humanPlayer.Deck.Count);
            Assert.AreEqual(17, _aiPlayer.Deck.Count);
        }

        [TestMethod]
        public void NormalDraw()
        {
            Assert.AreEqual(20, _humanPlayer.Deck.Count);
            Assert.AreEqual(20, _aiPlayer.Deck.Count);

            _drawPhase.Draw(DrawPhaseManagerTests.AiTurn);
            Assert.AreEqual(19, _aiPlayer.Deck.Count);
            Assert.AreEqual(1, _aiPlayer.Hand.Count);

            _drawPhase.Draw(DrawPhaseManagerTests.PlayerTurn);
            Assert.AreEqual(19, _humanPlayer.Deck.Count);
            Assert.AreEqual(1, _humanPlayer.Hand.Count);
        }

        [TestMethod]
        public void ManaRestored()
        {
            _drawPhase.FirstDraw();

            Assert.AreEqual(0, _humanPlayer.Mana);
            Assert.AreEqual(0, _aiPlayer.Mana);

            _drawPhase.Draw(DrawPhaseManagerTests.AiTurn);
            _drawPhase.Draw(DrawPhaseManagerTests.PlayerTurn);
            Assert.AreEqual(1, _aiPlayer.Mana);
            Assert.AreEqual(1, _humanPlayer.Mana);

            _drawPhase.Draw(DrawPhaseManagerTests.AiTurn);
            _drawPhase.Draw(DrawPhaseManagerTests.PlayerTurn);
            Assert.AreEqual(2, _aiPlayer.Mana);
            Assert.AreEqual(2, _humanPlayer.Mana);
        }

        [TestMethod]
        public void DrawWithoutMana()
        {
            _drawPhase.DrawWithoutMana(_aiPlayer);
            Assert.AreEqual(0, _aiPlayer.Mana);

            _drawPhase.DrawWithoutMana(_humanPlayer);
            Assert.AreEqual(0, _humanPlayer.Mana);

        }

        [TestMethod]
        public void PlaceaDrawEffectCard()
        {
            // TODO
        }
    }
}
