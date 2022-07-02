using cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace shared
{
    public interface IEffect
    {
        
        ActivationEvent ActivationEvent { get; }
        string NameEffect { get; }
        string DescriptionEffect { get; }
        string ImageEffectURL { get; set; }
        void UseEffect(Player cardOwner, Player enemy, int boardPosition);

    }
}
