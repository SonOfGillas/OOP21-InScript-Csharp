using System;

namespace drawphasemanager
{
    public interface IDrawPhaseManager
    {
        void draw(bool isTheAITurn);

        void firstDraw();

        /* <da completare appena è stata aggiunta
         *  la classe Player> */
        /* void drawWithoutMana(Player player); */
    }

    public class DrawPhaseManagerImpl : IDrawPhaseManager
    {
        public void draw(bool isTheAITurn)
        {

        }

        public void firstDraw()
        {

        }

    }
}
