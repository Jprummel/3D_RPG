[System.Serializable]
public class SwordSlash : BaseAbility {

    public SwordSlash()
    {
        AbilityName         = "Sword Slash";
        AbilityDescription  = "A strong slash";
        AbilityID           = 2;
        AbilityPower        = 25;
        AbilityCost         = 10;
        AbilityStatusEffects.Add(new BurnStatusEffect());
        AbilityStatusEffect = new BurnStatusEffect();
        AbilityCritChance   = 85; // 85% Chance to crit
        AbilityCritModifier = 1.2f; 
    }
}
