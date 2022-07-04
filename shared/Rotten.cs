using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cards;


namespace shared
{
    internal class Rotten : AbstractEffect 
    {
        public Rotten() : base(effectName: "Rotten", effectDescriprion: "When this card's life total drops to zero, it begins to rot, leaving Rot in the field", imageEffectURL: "effects/effect_rotten.png") // indirizzo dell immagine usata del progetto java
        {

        }

        public override ActivationEvent ActivationEvent { get => ActivationEvent.POSITIONING; }


        public override void UseEffect(Player cardOwner, Player enemy, int boardPosition)
        {
            cardOwner.CurrentBoard.ElementAt(boardPosition).LifePoints = 3;
            cardOwner.CurrentBoard.ElementAt(boardPosition).Attack = 0;
            cardOwner.CurrentBoard.ElementAt(boardPosition).Effect = null;
            cardOwner.CurrentBoard.ElementAt(boardPosition).Name = "Putridume";
            cardOwner.CurrentBoard.ElementAt(boardPosition).ImageURL = "standardDeckImage / Putridume.png"; // indirizzo dell immagine usata del progetto java
        }
    }
}
