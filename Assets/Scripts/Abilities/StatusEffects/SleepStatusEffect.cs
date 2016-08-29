[System.Serializable]
public class SleepStatusEffect : BaseStatusEffect {

	 public SleepStatusEffect()
    {
        StatusEffectName                    = "Sleep";
        StatusEffectDescription             = "Puts the target to sleep";
        StatusEffectID                      = 2;
        StatusEffectPower                   = 0;   //Damage amount
        StatusEffectApplyPercentage         = 100; //100% chance to apply this effect
        StatusEffectStayAppliedPercentage   = 33;
        StatusEffectMinTurnApplied          = 2;
        StatusEffectMaxTurnApplied          = 3;
    }
}
