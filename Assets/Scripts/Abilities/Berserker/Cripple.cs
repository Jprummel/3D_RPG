[System.Serializable]
public class Cripple : BaseAbility {

    public Cripple()
    {
        AbilityName         = "Cripple";
        AbilityDescription  = "Drops the enemies current hp by 1/4";
        AbilityType         = AbilityTypes.PHYSICAL;
        AbilityID           = 2;
        AbilityBaseDamage   = (int)EnemyInformation.EnemyHealth/4;
        AbilityDamageStatModifier = 0f;
        AbilityCost         = 40;
        AbilityStatusEffect = null;
        AbilityCritChance   = 0; // 0% Chance to crit
        AbilityCritModifier = 0f;
        AbilityHitChance    = 80;//80%chance to hit
    }
	
}
