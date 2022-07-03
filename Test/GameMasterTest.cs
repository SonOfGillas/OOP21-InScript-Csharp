﻿using gamemaster;
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
            List<Card> deck = new List<Card>();
            IEnumerable<int> range = Enumerable.Range(0, 20);

            foreach (int i in range)
            {
                deck.Add(new Card());
            }

            _gameMaster = new GameMaster(deck, deck);

        }

        [TestInitialize]
        void PhaseManagersInizialization()
        {
            Assert.IsNotNull(_gameMaster.DrawPhaseManager);
            Assert.IsNotNull(_gameMaster.MainPhaseManager);
            Assert.IsNotNull(_gameMaster.MainPhaseManagerIA);
            Assert.IsNotNull(_gameMaster.BattlePhaseManager);
            Assert.IsNotNull(_gameMaster.HumanPlayer);
            Assert.IsNotNull(_gameMaster.AiPlayer);
        }

        [TestInitialize]
        void StartGame()
        {
            _gameMaster.StartGame();
            Assert.AreEqual(GameConst.InitialNumCardsInHand + 1, _gameMaster.HumanPlayer.Hand.Count + NumberOfCard(_gameMaster.HumanPlayer.CurrentBoard));
            Assert.AreEqual(GameConst.InitialNumCardsInHand + 1, _gameMaster.AiPlayer.Hand.Count + NumberOfCard(_gameMaster.AiPlayer.CurrentBoard));
        }

        private int NumberOfCard(IList<Card> list)
        {
            int numberOfCard = 0;

            foreach (Card card in list)
            {
                if (card != null) { numberOfCard++; }
            }

            return numberOfCard;
        }
    }
}