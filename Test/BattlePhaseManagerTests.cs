using System;
using System.Collections.Generic;
using System.Text;
using battlephasemanager;

using shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace test
{
    [TestClass]
    public class BattlePhaseManagerTests
    {
        public Player _player, _enemy;
        public BattlePhaseManager _manager;
        public List<BaseCard> _boardPlayer = new List<BaseCard>(Player.NumCardBoard), _boardEnemy = new List<BaseCard>(Player.NumCardBoard);


        [TestInitialize]
        public void TestInitialize()
        {
            _manager = new BattlePhaseManager( _player = new Player(false, null, 0, 0, 0, _boardPlayer, null),
                _enemy = new Player(false, null, 0, 0, 0, _boardEnemy, null));
        }

        [TestMethod]
        public void DirectAttackToEnemy()
        {
            for (int i = 0; i < Player.NumCardBoard; i++)
            {
                _boardPlayer.Add(new BaseCard("Dog", 1, 1, 1, "cane.png", new Rotten()));
                _boardEnemy.Add(null);
            }
            _manager.StartBattle(false);
            Assert.AreEqual(-5, _enemy.LifePoints);
        }

        [TestMethod]
        public void DefaultPlayerBattle()
        {
            for (int i = 0; i < Player.NumCardBoard; i++)
            {
                _boardPlayer.Add(new BaseCard("Dog", 1, 1, 1, "cane.png", null));
                _boardEnemy.Add(new BaseCard("Dog", 1, 1, 1, "cane.png", null));
            }
            _manager.StartBattle(false);

            foreach(BaseCard card in _boardEnemy)
            {
                Assert.AreEqual(null, card.Name);
                Assert.AreEqual(0, card.LifePoints);
                Assert.AreEqual(0, card.Attack);
                Assert.AreEqual(0, card.Mana);
                Assert.AreEqual(null, card.ImageURL);
            }
        }

        [TestMethod]
        public void RottenEffectActivation()
        {
            for (int i = 0; i < Player.NumCardBoard; i++)
            {
                _boardPlayer.Add(new BaseCard("Dog", 1, 1, 1, "cane.png", null));
                _boardEnemy.Add(new BaseCard("Dog", 1, 1, 1, "cane.png", new Rotten()));
            }
            _manager.StartBattle(false);

            foreach (BaseCard card in _boardEnemy)
            {
                Assert.AreEqual("Putridume", card.Name);
                Assert.AreEqual(3, card.LifePoints);
                Assert.AreEqual(0, card.Attack);
                Assert.AreEqual(1, card.Mana);
                Assert.AreEqual("standardDeckImage / Putridume.png", card.ImageURL);
                Assert.AreEqual(null, card.Effect);
            }
        }

    }
}
