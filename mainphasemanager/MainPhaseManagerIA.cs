using System;
using shared;
using cards;
using System.Linq;

namespace mainphasemanager
{
    public interface IMainPhaseManagerIA
    {
        void StartAIMainPhase();

    }

    public class MainPhaseManagerIA : IMainPhaseManagerIA
    {
        private Player _player;
        private Player _playerAI;
        private MainPhaseManagerImpl _mainPhaseManager;
        private Random _rand;
        private int _cheaperPlacableCard;

        public MainPhaseManagerIA(Player player, Player playerAI)
        {
            _player = player;
            _playerAI = playerAI;
            _mainPhaseManager = new MainPhaseManagerImpl(player, playerAI);
            _rand = new Random();
            _cheaperPlacableCard = GameConst.MaximumMana + 1;
        }

        public void StartAIMainPhase()
        {
            if (NumberOfEmptyBoardCell() != 0)
            {
                do
                {
                    BaseCard cardToPlace = GetMostExpensivePlacebleCard();
                    if (cardToPlace != null)
                    {
                        _mainPhaseManager.Positioning(cardToPlace, IndexOfTheDungerousEnemyCardNotAlreadyCovered(), true);
                    }
                    else
                    {
                        break;
                    }
                } while (_cheaperPlacableCard <= _playerAI.CurrentMana && NumberOfEmptyBoardCell() != 0);
            }
        }

        private int NumberOfEmptyBoardCell()
        {
            int emptyCell = 0;
            foreach (BaseCard card in _playerAI.CurrentBoard)
            {
                if (card == null)
                {
                    emptyCell += 1;
                }
            }

            return emptyCell;
        }

        private BaseCard GetMostExpensivePlacebleCard()
        {
            BaseCard mostExpensiveCard = null;
            _cheaperPlacableCard = GameConst.MaximumMana + 1;

            foreach (BaseCard card in _playerAI.Hand)
            {
                if (mostExpensiveCard != null)
                {
                    if (card.Mana > mostExpensiveCard.Mana && card.Mana <= _playerAI.CurrentMana)
                    {
                        mostExpensiveCard = card;
                    }
                }
                else
                {
                    if (card.Mana <= _playerAI.CurrentMana)
                    {
                        mostExpensiveCard = card;
                    }
                }
                if (card.Mana < _cheaperPlacableCard)
                {
                    _cheaperPlacableCard = card.Mana;
                }
            }
            return mostExpensiveCard;
        }

        private int IndexOfTheDungerousEnemyCardNotAlreadyCovered()
        {
            int indexOfTheDungerous = _rand.Next(0, Player.NumCardBoard);
            do { indexOfTheDungerous = _rand.Next(0, Player.NumCardBoard); } while (_playerAI.CurrentBoard.ElementAt(indexOfTheDungerous) != null);

            int dungerousCardAttack = _player.CurrentBoard.ElementAt(indexOfTheDungerous) != null ? _player.CurrentBoard.ElementAt(indexOfTheDungerous).Attack : 0;

            foreach (BaseCard card in _player.CurrentBoard)
            {
                if (card != null && card.Attack > dungerousCardAttack && _playerAI.CurrentBoard.ElementAt(_player.CurrentBoard.IndexOf(card)) == null)
                {
                    indexOfTheDungerous = _player.CurrentBoard.IndexOf(card);
                    dungerousCardAttack = card.Attack;
                }
            }

            return indexOfTheDungerous;

        }

    }
}
