using drawphasemanager;
using gamemaster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{

    [TestClass]

    public class EffectTest
    {
        readonly static int LEFT = 0;
        readonly static int CENTER_LEFT = 1;
        readonly static int CENTER = 2;
        readonly static int CENTER_RIGHT = 3;
        readonly static int RIGHT = 4;

        private GameMaster _gameMaster;
        private IDrawPhaseManager _drawPhase;
        private Player _humanPlayer;
        private Player _aiPlayer;

        public static bool AiTurn = true;
        public static bool PlayerTurn = false;


        [TestInitialize]
        public void TestInitialize()
        {
            List<BaseCard> deck1 = new List<BaseCard>();
            List<BaseCard> deck2 = new List<BaseCard>();

            _gameMaster = new GameMaster(deck1, deck2);
            _drawPhase = _gameMaster.DrawPhaseManager;
            _humanPlayer = _gameMaster.HumanPlayer;
            _aiPlayer = _gameMaster.AiPlayer;

        }


        [TestMethod]
        public void rottenTest()
        {
            _aiPlayer.CurrentBoard.Insert(CENTER, new BaseCard("melma", 2, 2, 0, "melma.png", new Rotten()));
            

            _aiPlayer.CurrentBoard[CENTER].Effect.UseEffect(_aiPlayer, _humanPlayer, CENTER);

            Assert.AreEqual("Putridume", _aiPlayer.CurrentBoard[CENTER].Name);

        }
    }
}
