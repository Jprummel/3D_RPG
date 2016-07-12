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
    }

    void OnGUI()
    {

        if (TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            DisplayPlayersChoice();
        }
        //for loop to display several abilities
        //Creates an action type bar
        /*for (int i = 0; i < GameInformation.PlayersAbilities.Count; i++)
        {
            if (GUI.Button(new Rect(0, 0, 0, 0), GameInformation.PlayersAbilities[i].AbilityName))
            {

            }
        }*/
        //TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
        //we need to show enemy info
        //we need to show player info
    }

    private void DisplayPlayersChoice()
    {
        if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 100, 30), GameInformation.playerMoveOne.AbilityName))
        {
            //calculate damage to enemy
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveOne;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        }
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 30), GameInformation.playerMoveTwo.AbilityName))
        {
            //calculate damage to enemy
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALCDAMAGE;
        }
    }
}
