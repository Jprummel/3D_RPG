[System.Serializable]
public class Rampage : BaseAbility {

	public Rampage()
    {
        AbilityName         = "Rampage";
        AbilityDescription  = "A heavy and wild hit, has a high chance to miss but deals alot of damage and has a high crit chance";
        AbilityType         = AbilityTypes.PHYSICAL;
        AbilityID           = 2;
        AbilityBaseDamage   = 230;
        AbilityDamageStatModifier = 1.2f;
        AbilityCost         = 30;
        AbilityCritChance   = 50; //50% Chance to crit
        AbilityCritModifier = 1.2f;
        AbilityHitChance    = 25;//25% chance to hit
        AbilityDamageToSelf = 0;
    }
}
