[System.Serializable]
public class PoisonStatusEffect : BaseStatusEffect
{

    public PoisonStatusEffect()
    {
        StatusEffectName = "Poison";
        StatusEffectDescription = "Poisons the target for a number of turns";
        StatusEffectID = 1;
        StatusEffectPower = 25; //Damage amount
        StatusEffectApplyPercentage = 50; //75% chance to apply this effect
        StatusEffectStayAppliedPercentage = 75;
        StatusEffectMinTurnApplied = 3;
        StatusEffectMaxTurnApplied = 6;
    }

}