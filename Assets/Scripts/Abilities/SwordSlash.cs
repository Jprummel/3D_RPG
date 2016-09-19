[System.Serializable]
public class SwordSlash : BaseAbility {

    public SwordSlash()
    {
        AbilityName         = "Sword Slash";
        AbilityDescription  = "A strong slash";
        AbilityType         = AbilityTypes.PHYSICAL;
        AbilityID           = 2;
        AbilityBaseDamage   = 120;
        AbilityDamageStatModifier = 1.1f;
        AbilityCost         = 10;
        AbilityStatusEffects.Add(new BurnStatusEffect());
        AbilityStatusEffect = new BurnStatusEffect();
        AbilityCritChance   = 10; // 85% Chance to crit
        AbilityCritModifier = 1.2f;
        AbilityHitChance    = 99;
        AbilityDamageToSelf = 0;
    }
}
