using gamemaster;
using cards;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testInit()
        {
            List<Card> playerDeck = new List<Card>();
            List<Card> aIDeck = new List<Card>();
            GameMaster _gameMaster = new GameMaster(playerDeck, aIDeck);

            Assert.IsTrue(_gameMaster.MainPhaseManagerIA != null);
        }
    }
}