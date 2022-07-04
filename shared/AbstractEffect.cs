using cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace shared
{
    public abstract class AbstractEffect : IEffect
    {
        private string _effectName;
        private string _effectDescription;
        private string _imageEffectURL;

        public AbstractEffect(string effectName, string effectDescriprion, string imageEffectURL) 
            : base()
        {
            _effectName = effectName;
            _effectDescription = effectDescriprion;
            _imageEffectURL = imageEffectURL;
        }

        public virtual ActivationEvent ActivationEvent => throw new NotImplementedException();

        public string NameEffect
        {
            get => _effectName;
        }

        public string DescriptionEffect
        {
            get => _effectDescription;
        }

        public string ImageEffectURL 
        { 
            get => _imageEffectURL; 
            set => _imageEffectURL = value; 
        }

        public virtual void UseEffect(Player cardOwner, Player enemy, int boardPosition)
        {
            throw new NotImplementedException();
        }
    }
}
