using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour {

    private string  _playerName;
    private int     _playerLevel;
    private int     _playerHealth;
    private int     _playerEnergy;

    void Start()
    {
        _playerName = GameInformation.PlayerName;
        _playerLevel = GameInformation.PlayerLevel;
        Debug.Log(GameInformation.playerMoveTwo.AbilityStatusEffect.StatusEffectName);
    }

    void OnGUI()
    {

        if (TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            DisplayPlayersChoice();
        }
        //we need to show enemy health and other enemy info
        //we need to show player info
    }

    private void DisplayPlayersChoice()
    {
        if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 100, 30), GameInformation.playerMoveOne.AbilityName))
        {
            //calculate players damage to enemy
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveOne;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        }
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 30), GameInformation.playerMoveTwo.AbilityName))
        {
            //calculate players damage to enemy
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        }
    }
}
