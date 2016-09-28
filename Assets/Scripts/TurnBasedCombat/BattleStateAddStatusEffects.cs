using UnityEngine;
using System.Collections;

public class BattleStateAddStatusEffects{

    public void CheckAbilityForStatusEffects(BaseAbility usedAbility) // checks the status effects on the ability passed along
    {
        if (usedAbility.AbilityStatusEffect != null)
        {
            switch (usedAbility.AbilityStatusEffect.StatusEffectName)
            {
                case ("Burn"):
                    if (TryToApplyStatusEffect(usedAbility))
                    {
                        Debug.Log("RETURNED TRUE, APPLIED EFFECT");
                        TurnBasedCombatStateMachine.statusEffectBaseDamage = usedAbility.AbilityStatusEffect.StatusEffectPower;
                        Debug.Log(TurnBasedCombatStateMachine.statusEffectBaseDamage);
                    }
                    else
                    {
                        TurnBasedCombatStateMachine.statusEffectBaseDamage = 0;
                    }

                    TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
                    break;

                default:
                    Debug.LogError("Error in status effects");
                    break;
            }
        }
        else
        {
            Debug.Log("No status effect on this ability");
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        }
    }

    private bool TryToApplyStatusEffect(BaseAbility usedAbility)
    {
        //Look at percent chance of status effect applying
        int randomTemp = Random.Range(1, 101); // Random number between 1 and 100
        Debug.Log(randomTemp);
        if (randomTemp <= usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage) // Apply the status effect
        {
            return true;
        }
        return false;

    }
}
