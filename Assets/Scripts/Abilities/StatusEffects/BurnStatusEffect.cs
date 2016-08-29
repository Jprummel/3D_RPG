[System.Serializable]
public class BurnStatusEffect : BaseStatusEffect{

    public BurnStatusEffect()
    {
        StatusEffectName                    = "Burn";
        StatusEffectDescription             = "Burns the target for a number of turns";
        StatusEffectID                      = 1;
        StatusEffectPower                   = 10; //Damage amount
        StatusEffectApplyPercentage         = 75; //75% chance to apply this effect
        StatusEffectStayAppliedPercentage   = 75;
        StatusEffectMinTurnApplied          = 2;
        StatusEffectMaxTurnApplied          = 4;
    }
	
}
