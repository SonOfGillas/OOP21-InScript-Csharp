using System;

namespace gamemaster
{

    public interface IGameMaster
    {
        public static int DEFAULT_PLAYER_LIFE = 0;
        public static int MIN_PLAYER_LIFE = -10;
        public static int INITIAL_MANA = 0;
        public static int MAXIMUM_MANA = 10;
        public static int MANA_PLUS_ONE = 1;

        /**
         * this is the number of card that each player have in the hand before the drawingPhase
         */
        public static int INTIAL_NUM_CARDS_IN_HAND = 3;
    }
    class GameMaster
    {

    }
}
