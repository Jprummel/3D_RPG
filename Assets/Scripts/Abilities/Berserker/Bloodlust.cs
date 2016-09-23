using UnityEngine;
using System.Collections;

public class Bloodlust : BaseAbility
{
    public Bloodlust()
    {
        AbilityName         = "Bloodlust";
        AbilityDescription  = "Deals more damage when you are lower on hp";
        AbilityType         = AbilityTypes.PHYSICAL;
        AbilityID           = 2;
        AbilityBaseDamage   = (int)PlayerInformation.CharactersMaxHealth - (int)PlayerInformation.CharactersHealth;
        AbilityDamageStatModifier = 0f;
        AbilityCost         = 35;
        AbilityStatusEffect = null;
        AbilityCritChance   = 5; // 0% Chance to crit
        AbilityCritModifier = 2f;
        AbilityHitChance    = 99;//99%chance to hit
    }
}
