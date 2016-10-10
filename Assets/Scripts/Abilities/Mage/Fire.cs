using UnityEngine;
using System.Collections;

public class Fire : BaseAbility {

    public Fire()
    {
        AbilityName = "Fire";
        AbilityDescription = "Slightly burns the target";
        AbilityType = AbilityTypes.MAGICAL;
        AbilityID = 2;
        AbilityBaseDamage   = 250;
        AbilityDamageStatModifier = 0f;
        AbilityCost = 40;
        AbilityStatusEffect = null;
        AbilityCritChance = 20; // 0% Chance to crit
        AbilityCritModifier = 2f;
        AbilityHitChance = 99;//80%chance to hit
    }
}
