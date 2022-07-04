using gamemaster;
using shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace test
{
    [TestClass]
    public class GameMasterTests
    {
        private GameMaster _gameMaster;

        [TestInitialize]
        public void TestInitialize()
        {
            List<BaseCard> deck = new List<BaseCard>();
            IEnumerable<int> range = Enumerable.Range(0, 20);

            foreach (int i in range)
            {
                deck.Add(new BaseCard("cane", 1,1,1,"",null));
            }

            _gameMaster = new GameMaster(deck, deck);

        }

        [TestMethod]
        public void PhaseManagersInizialization()
        {
            Assert.IsNotNull(_gameMaster.DrawPhaseManager);
            Assert.IsNotNull(_gameMaster.MainPhaseManager);
            Assert.IsNotNull(_gameMaster.MainPhaseManagerIA);
            Assert.IsNotNull(_gameMaster.BattlePhaseManager);
            Assert.IsNotNull(_gameMaster.HumanPlayer);
            Assert.IsNotNull(_gameMaster.AiPlayer);
        }

        [TestMethod]
        public void StartGame()
        {
            _gameMaster.StartGame();
            Assert.AreEqual(GameConst.InitialNumCardsInHand + 1, NumberOfCard(_gameMaster.HumanPlayer.CurrentBoard));
            Assert.AreEqual(GameConst.InitialNumCardsInHand + 1, NumberOfCard(_gameMaster.AiPlayer.CurrentBoard));
        }

        private int NumberOfCard(IList<BaseCard> list)
        {
            int numberOfCard = 0;

            foreach (BaseCard card in list)
            {
                if (card != null) { numberOfCard++; }
            }

            return numberOfCard;
        }
    }
}
