using UnityEngine;
using System.Collections;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    private bool _hasAddedXP;
    private BattleStateStart _battleStateStartScript = new BattleStateStart();
    private BattleCalculations _battleCalcScript = new BattleCalculations(); 
    public static BaseAbility playerUsedAbility;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        CALCDAMAGE,
        ADDSTATUSEFFECTS,
        //PlayerAnimate
        ENEMYCHOICE,
        LOSE,
        WIN
    }

    public static BattleStates currentState;

	void Start () {
        _hasAddedXP = false;
        currentState = BattleStates.START;        
	}

	// Update is called once per frame
	void Update () {

        Debug.Log(currentState);

        switch (currentState)
        {
            case (BattleStates.START):
                //Setup Battle Function
                //Create enemy
                _battleStateStartScript.PrepareBattle();
                break;
            case (BattleStates.PLAYERCHOICE):       //Player chooses his/her abillity
               
                break;
            
            case (BattleStates.ENEMYCHOICE):
                //Coded AI goes here
                break;
            case (BattleStates.CALCDAMAGE):         //Calculate damage done by player look for existing status effects and add that damage
                 _battleCalcScript.CalculateUsedPlayerAbilityDamage(playerUsedAbility);
                break;
            case (BattleStates.ADDSTATUSEFFECTS):   //try to add a status effect if it exists
                break;
            case (BattleStates.LOSE):
                
                break;
            case (BattleStates.WIN):
                if (!_hasAddedXP)
                {
                    IncreaseExperience.AddExperience();
                    _hasAddedXP = true;
                }
                break;
        }
	}

    void OnGUI()
    {
        if (GUILayout.Button("NEXT STATE"))
        {
            if (currentState == BattleStates.START)
            {
                currentState = BattleStates.PLAYERCHOICE;
            }else if (currentState == BattleStates.PLAYERCHOICE)
            {
                currentState = BattleStates.ENEMYCHOICE;
            }else if (currentState == BattleStates.ENEMYCHOICE)
            {
                currentState = BattleStates.LOSE;
            }else if (currentState == BattleStates.LOSE)
            {
                currentState = BattleStates.WIN;
            }else if (currentState == BattleStates.WIN)
            {
                currentState = BattleStates.START;
            }
        }
    }
}
