using cards;
using drawphasemanager;

namespace shared
{
    internal class Draw : AbstractEffect
    {
       public Draw() : base(effectName: "Draw", effectDescriprion: "When this card enters the battlefield, the owner draws a card", imageEffectURL: "effects/effect_draw.png") // indirizzo dell immagine usata del progetto java
        {

        }

        public override ActivationEvent ActivationEvent { get => ActivationEvent.POSITIONING; }


        public override void UseEffect(Player cardOwner, Player enemy, int boardPosition)
        {
            new DrawPhaseManagerImpl(cardOwner, enemy).DrawWithoutMana(cardOwner);
        }
    }
}
