using shared;

namespace battlephasemanager
{

    public interface IBattlePhaseManager
    {

        void StartBattle(bool isTheAITurn);

    }
    public class BattlePhaseManager : IBattlePhaseManager
    {
        public BattlePhaseManager(Player player, Player playerAI) { }

        public void StartBattle(bool isTheAITurn)
        {

        }
    }
}