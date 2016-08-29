using UnityEngine;
using System.Collections;

public class BattleStateEnemyChoice : MonoBehaviour {

    private EnemyAbilityChoice _enemyAbilityChoiceScript = new EnemyAbilityChoice();
    
    public void EnemyCompleteTurn()
    {
        //Choose ability
        TurnBasedCombatStateMachine.enemyUsedAbility = _enemyAbilityChoiceScript.ChooseEnemyAbility();
        Debug.Log("Enemy used " + TurnBasedCombatStateMachine.enemyUsedAbility.AbilityName + "!");
        //Calculate Damage
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        //End Turn
    }
}
