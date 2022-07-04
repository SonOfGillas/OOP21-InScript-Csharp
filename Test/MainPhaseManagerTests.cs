using gamemaster;
using mainphasemanager;
using shared;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    [TestClass]
    public class MainPhaseManagerTests
    {

        public static bool AiTurn = true;
        public static bool PlayerTurn = false;

        private GameMaster _gameMaster;
        private IMainPhaseManager _mainPhase;
        private Player _humanPlayer;

        [TestInitialize]
        public void TestInitialize()
        {
            List<BaseCard> deck = new List<BaseCard>();
            IEnumerable<int> range = Enumerable.Range(0, 20);

            foreach (int i in range)
            {
                deck.Add(new BaseCard());
            }

            _gameMaster = new GameMaster(deck, deck);
            _mainPhase = _gameMaster.MainPhaseManager;
            _humanPlayer = _gameMaster.HumanPlayer;

        }

        [TestMethod]
        public void NormalPositioning()
        {
            _gameMaster.DrawPhaseManager.FirstDraw();
            _humanPlayer.CurrentMana = GameConst.MaximumMana;
            _humanPlayer.Mana = GameConst.MaximumMana;

            Assert.AreEqual(3, _humanPlayer.Hand.Count);

            _mainPhase.Positioning(_humanPlayer.Hand.ElementAt(0), 1, MainPhaseManagerTests.PlayerTurn);

            Assert.AreEqual(2, _humanPlayer.Hand.Count);
        }

        [TestMethod]
        public void CellFullDontPlace()
        {
            _gameMaster.DrawPhaseManager.FirstDraw();
            _humanPlayer.CurrentMana = GameConst.MaximumMana;
            _humanPlayer.Mana = GameConst.MaximumMana;

            _mainPhase.Positioning(_humanPlayer.Hand.ElementAt(0), 1, MainPhaseManagerTests.PlayerTurn);

            Assert.AreEqual(2, _humanPlayer.Hand.Count);
            Assert.AreEqual(true, _mainPhase.CellEmpty);

            _mainPhase.Positioning(_humanPlayer.Hand.ElementAt(0), 1, MainPhaseManagerTests.PlayerTurn);

            Assert.AreEqual(2, _humanPlayer.Hand.Count);
            Assert.AreEqual(false, _mainPhase.CellEmpty);
        }
        /* DA SCOMMENTARE QUANDO SARANNO STATE CREATE EFFETTIVAMENTE DELLE
         * CARTE CON DELLE STAT.
        [TestMethod]
        public void NotEnoughtManaToPlaceCard()
        {
            _gameMaster.DrawPhaseManager.FirstDraw();
            _gameMaster.DrawPhaseManager.Draw(MainPhaseManagerTests.PlayerTurn);

            bool stop = false;
            BaseCard cardToPlace = null;
            while(!stop)
            {

                foreach (var card in _humanPlayer.Hand)
                {
                    if(card.Mana > _humanPlayer.CurrentMana)
                    {
                        cardToPlace = card;
                        stop = true;
                        break;
                    }
                }

                _gameMaster.DrawPhaseManager.DrawWithoutMana(_humanPlayer);
            }

            int actualHandSize = _humanPlayer.Hand.Count;

            Assert.AreEqual(actualHandSize, _humanPlayer.Hand.Count);

            _mainPhase.Positioning(cardToPlace, 1, MainPhaseManagerTests.PlayerTurn);

            Assert.AreEqual(actualHandSize, _humanPlayer.Hand.Count);
            Assert.AreEqual(false, _mainPhase.CanPlace);
        }
        */
    }
}
