using System;
using System.Collections.Generic;
using System.Text;
using cards;
using shared;

namespace effects
{
    class Effect : IEffect
    {
        public ActivationEvent ActivationEvent => throw new NotImplementedException();

        public string NameEffect => throw new NotImplementedException();

        public string DescriptionEffect => throw new NotImplementedException();

        public string ImageEffectURL { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void UseEffect(Player cardOwner, Player enemy, int boardPosition)
        {
            throw new NotImplementedException();
        }
        public Effect() { }
    }
}
