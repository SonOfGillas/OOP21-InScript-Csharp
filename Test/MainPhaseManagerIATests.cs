using gamemaster;
using mainphasemanager;
using shared;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    [TestClass]
    public class MainPhaseManagerIATests
    {

        private GameMaster _gameMaster;
        private IMainPhaseManagerIA _mainPhaseAI;
        private Player _AiPlayer;

        [TestInitialize]
        public void TestInitialize()
        {
            List<BaseCard> deck = new List<BaseCard>();
            IEnumerable<int> range = Enumerable.Range(0, 20);

            foreach (int i in range)
            {
                deck.Add(new BaseCard("cane", 1, 1, 1, "", null));
            }

            _gameMaster = new GameMaster(deck, deck);
            _mainPhaseAI = _gameMaster.MainPhaseManagerIA;
            _AiPlayer = _gameMaster.AiPlayer;

        }

        [TestMethod]
        public void startAIMainPhase()
        {
            while (!AiHavePlacableCardInHand())
            {
                _gameMaster.DrawPhaseManager.Draw(true);
            }

            Assert.AreEqual(0, NumberCardInTheAIBoard());

            int prevCardInHand = _AiPlayer.Hand.Count;

            _mainPhaseAI.StartAIMainPhase();

            int cardPlaced = NumberCardInTheAIBoard();

            Assert.IsTrue(cardPlaced > 0);

            int expectedHandDimension = prevCardInHand - cardPlaced;

            Assert.AreEqual(expectedHandDimension,_AiPlayer.Hand.Count);
        }

    
        private bool AiHavePlacableCardInHand()
        {

            foreach (BaseCard card in _AiPlayer.Hand)
            {
                if(card.Mana <= _AiPlayer.CurrentMana) { return true; }
            }

            return false;
        }

        private int NumberCardInTheAIBoard()
        {
            int numberOfCard = 0;

            foreach (BaseCard card in _AiPlayer.Hand)
            {
                if (card != null) { numberOfCard++; }
            }

            return numberOfCard;
        }
    }
}
