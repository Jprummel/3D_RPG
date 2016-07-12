using UnityEngine;
using System.Collections;

public class BattleCalculations {

    private StatCalculations    _statCalcScript = new StatCalculations();
    private int                 _abilityPower;
    private float               _totalAbilityPowerDamage;
    private int                 _totalUsedAbilityDamage;

    public void CalculateUsedPlayerAbilityDamage(BaseAbility usedAbility)
    {
        Debug.Log("Used Ability " + usedAbility.AbilityName);
        //ability dmg + crit dmg - armor + stat modifier + weapon dmg + status effect
        _totalUsedAbilityDamage = (int)CalculateAbilityDamage(usedAbility);
        Debug.Log(_totalUsedAbilityDamage);
        //use an ability
        //calculate damage
        //check status effect
            //if move has status effect
                //try to add effect
                //if effect is added, then apply damage from effect
        //calculate total damage with status effect in mind
    }

    private float CalculateAbilityDamage(BaseAbility usedAbility)
    {
        _abilityPower = usedAbility.AbilityPower;   //Retrieves power of ability
        _totalAbilityPowerDamage = _abilityPower * _statCalcScript.FindAndCalculatePlayerMainStatModifier();   //Find main stat and use as modifier for damage
        return _totalAbilityPowerDamage;
    }
}
