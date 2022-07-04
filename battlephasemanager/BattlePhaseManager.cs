using shared;
using cards;
using System.Collections.Generic;
using System.Linq;
using System;

namespace battlephasemanager
{

    public interface IBattlePhaseManager
    {
        public void StartBattle(bool isAITurn);
    }
    public class BattlePhaseManager : IBattlePhaseManager
    {
        private readonly Player _player, _enemy;
        private IList<IEffect> _effectPlayer, _effectEnemy;
        private readonly IList<ActivationEvent> _eventTarget = new List<ActivationEvent>() { ActivationEvent.ONATTAKING, ActivationEvent.ONDEFENDING, ActivationEvent.ONDEATH };

        public BattlePhaseManager(Player player, Player playerAI) {
            this._player = player;
            this._enemy = playerAI;
        }

        private IList<IEffect> extractEffect(Player target)
        {
            List<IEffect> tmp = new List<IEffect>(5);
            foreach (BaseCard card in target.CurrentBoard)
            {
                if (card != null)
                {
                    if (card.Effect != null && _eventTarget.Contains(card.Effect.ActivationEvent))
                    {
                        tmp.Add(card.Effect);
                    }
                    else
                        tmp.Add(null);
                }
                else
                    tmp.Add(null);
            }
            return tmp;
        }

        private IList<BaseCard> CheckDead(IList<BaseCard> battleBoard)
        {
            List<BaseCard> tmp = new List<BaseCard>(Player.NumCardBoard);
            foreach (BaseCard card in battleBoard)
            {
                if (card != null && card.LifePoints <= 0)
                { 
                    card.Name = null;
                    card.Attack = 0;
                    card.Mana = 0;
                    card.ImageURL = null;
                }
            }
            return tmp;
        }

        private IList<BaseCard> HandleBattle(Player protagonist, Player antagonist, bool isAITurn)
        {
            List<BaseCard> tmp = new List<BaseCard>(5);
            for(int i = 0; i < protagonist.CurrentBoard.Count; i++)
            {
                if(protagonist.CurrentBoard.ElementAt(i) != null && protagonist.CurrentBoard.ElementAt(i).LifePoints > 0)
                {
                    if(antagonist.CurrentBoard.ElementAt(i) != null)
                    {
                        antagonist.CurrentBoard.ElementAt(i).LifePoints = antagonist.CurrentBoard.ElementAt(i).LifePoints 
                            - protagonist.CurrentBoard.ElementAt(i).Attack;
                        if (isAITurn)
                        {
                            if(_effectEnemy.ElementAt(i) != null && _effectEnemy.ElementAt(i).ActivationEvent 
                                == ActivationEvent.ONATTAKING)
                            {
                                _effectEnemy.ElementAt(i).UseEffect(protagonist, antagonist, i);
                            }

                            if (_effectPlayer.ElementAt(i) != null && _effectPlayer.ElementAt(i).ActivationEvent
                                == ActivationEvent.ONDEFENDING)
                            {
                                _effectPlayer.ElementAt(i).UseEffect(protagonist, antagonist, i);
                            }
                        }
                        else
                        {
                            if (_effectPlayer.ElementAt(i) != null && _effectPlayer.ElementAt(i).ActivationEvent
                                == ActivationEvent.ONATTAKING)
                            {
                                _effectPlayer.ElementAt(i).UseEffect(protagonist, antagonist, i);
                            }

                            if (_effectEnemy.ElementAt(i) != null && _effectEnemy.ElementAt(i).ActivationEvent
                                == ActivationEvent.ONDEFENDING)
                            {
                                _effectEnemy.ElementAt(i).UseEffect(protagonist, antagonist, i);
                            }

                        }

                        if(antagonist.CurrentBoard.ElementAt(i) != null && 
                            antagonist.CurrentBoard.ElementAt(i).LifePoints <= 0 && 
                            antagonist.CurrentBoard.ElementAt(i).Effect != null &&
                            antagonist.CurrentBoard.ElementAt(i).Effect.ActivationEvent == ActivationEvent.ONDEATH) 
                        {
                            antagonist.CurrentBoard.ElementAt(i).Effect.UseEffect(antagonist, protagonist, i);
                        }
                        tmp.Add(antagonist.CurrentBoard.ElementAt(i));
                    }
                    else
                    {
                        antagonist.LifePoints = antagonist.LifePoints - protagonist.CurrentBoard.ElementAt(i).Attack;
                        protagonist.LifePoints = protagonist.LifePoints + protagonist.CurrentBoard.ElementAt(i).Attack;
                        tmp.Add(null);
                    }
                }
                else
                {
                    tmp.Add(antagonist.CurrentBoard.ElementAt(i));
                }
            }
            return CheckDead(tmp);
        }

        public void HandleEffect()
        {
            _effectPlayer = extractEffect(_player);
            _effectEnemy = extractEffect(_enemy);
        }

        public void StartBattle(bool isAITurn)
        {
            HandleEffect();
            if (isAITurn)
            {
                _player.CurrentBoard = HandleBattle(_enemy, _player, isAITurn);
            }
            else
            {
                _enemy.CurrentBoard = HandleBattle(_player, _enemy, isAITurn);
            }
        }
    }
}