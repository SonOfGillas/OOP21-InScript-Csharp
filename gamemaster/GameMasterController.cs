using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamemaster
{
   public interface IGameMasterController
    {
        public void onCardPlacing(int indexOfTheCellInTheBoard);
        public void onEndTurn();
    }

    public class GameMasterController : IGameMasterController
    {

        public GameMasterController()
        {

        }

        public void onCardPlacing(int indexOfTheCellInTheBoard)
        {

        }

        public void onEndTurn()
        {

        }
    }

}
