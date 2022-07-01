using shared;
using cards;

using System.Collections.Generic;
using System.Linq;

namespace battlephasemanager
{
    public struct Optional<T>
    {
        public bool HasValue { get; private set; }
        private T value;
        public T Value
        {
            get
            {
                if (HasValue)
                    return value;
                else
                    throw new InvalidOperationException();
            }
        }

        public Optional(T value)
        {
            this.value = value;
            HasValue = true;
        }

        public static explicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }
        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }
        public override bool Equals(object obj)
        {
            if (obj is Optional<T>)
                return this.Equals((Optional<T>)obj);
            else
                return false;
        }
        public bool Equals(Optional<T> other)
        {
            if (HasValue && other.HasValue)
                return object.Equals(value, other.value);
            else
                return HasValue == other.HasValue;
        }
        public Optional<T> Empty()
        {
            return new Optional<T>(null);
        }
    }


    public interface IBattlePhaseManager
    {
        public void startBattle(bool isAITurn);
    }
    public class BattlePhaseManager : IBattlePhaseManager
    {
        private readonly Player player, enemy;
        private IList<Optional<Effect>> effectPlayer, effectEnemy;
        private readonly IList<ActivationEvent> eventTarget = { ActivationEvent.ONATTACKING, ActivationEvent.ONDEFENDING, ActivationEvent.ONDEATH };

        public BattlePhaseManager(Player player, Player playerAI) {
            this.player = player;
            this.enemy = playerAI;
        }

        private IList<Optional<Effect>> extractEffect(Player target)
        {
            //IList<Optional<Effect>> tmp = new IList();
            List<Optional<Effect>> tmp = new List<Optional<Effect>>(5);
            foreach (Optional<Card> card in target.CurrentBoard)
            {
                if (card.HasValue)
                {
                    //if(card.Value.)
                    //tmp.add(card.Value.);
                }
                else
                    tmp.add(card.Empty);
            }
            return tmp;
        }

        private IList<Optional<Card>> CheckDead(IList<Optional<Card>> battleBoard)
        {
            List<Optional<Card>> tmp = new List<Optional<Card>>(5);
            foreach (Optional<Card> card in battleBoard)
            {
                if (card.HasValue && card.Value.Attack > 0)
                    tmp.add(card);
                else
                    tmp.add(card.Empty);
            }
            return tmp;
        }
    }
}