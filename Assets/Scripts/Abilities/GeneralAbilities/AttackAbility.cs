[System.Serializable]
public class AttackAbility : BaseAbility {

    public AttackAbility()
    {
        AbilityName         = "Attack";
        AbilityDescription  = "A basic attack";
        AbilityType         = AbilityTypes.PHYSICAL;
        AbilityID                   = 1;
        AbilityBaseDamage           = 40; //Abilities base damage unmodified
        AbilityDamageStatModifier   = 1.2f; //The stat that determines the damage * this var amount
        AbilityPower                = 10;
        AbilityCost                 = 0;
        AbilityCritChance           = 5;// 5% Crit chance
        AbilityCritModifier         = 2;//If crits damage * 2
        AbilityHitChance            = 99;
    }
}
