using cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace shared
{
    public abstract class AbstactEffect : IEffect
    {
        private string _effectName;
        private string _effectDescription;
        private string _imageEffectURL;

        public AbstactEffect(string effectName, string effectDescriprion, string imageEffectURL) 
            : base()
        {
            _effectName = effectName;
            _effectDescription = effectDescriprion;
            _imageEffectURL = imageEffectURL;
        }

        public virtual ActivationEvent ActivationEvent => throw new NotImplementedException();

        public string NameEffect => throw new NotImplementedException();

        public string DescriptionEffect => throw new NotImplementedException();

        public string ImageEffectURL { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual void UseEffect(Player cardOwner, Player enemy, int boardPosition)
        {
            throw new NotImplementedException();
        }
    }
}
