using UnityEngine;
using System.Collections;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    private BattleStateStart            _battleStateStartScript             = new BattleStateStart();
    private BattleCalculations          _battleCalcScript                   = new BattleCalculations();
    private BattleStateAddStatusEffects _battleStateAddStatusEffectScript   = new BattleStateAddStatusEffects();
    private BattleStateEnemyChoice      _battleStateEnemyChoiceScript       = new BattleStateEnemyChoice();
    private bool                        _hasAddedXP;   
    public static BaseAbility           playerUsedAbility;
    public static BaseAbility           enemyUsedAbility;
    public static int                   _statusEffectBaseDamage;
    public static int                   totalTurnCount;
    public static bool                  playerDidCompleteTurn;
    public static bool                  enemyDidCompleteTurn;
    public static BattleStates          currentUser; // enemy or player choice

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        CALCDAMAGE,
        ADDSTATUSEFFECTS,
        ENEMYCHOICE,
        ENDTURN,
        LOSE,
        WIN
    }

    public static BattleStates currentState;

	void Start () {
        _hasAddedXP = false;
        totalTurnCount = 1;
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
                currentUser = BattleStates.PLAYERCHOICE;
                break;
            
            case (BattleStates.ENEMYCHOICE):
                //Coded AI goes here
                //enemyDidCompleteTurn = true;
                //CheckWhoGoesNext();
                currentUser = BattleStates.ENEMYCHOICE;
                _battleStateEnemyChoiceScript.EnemyCompleteTurn();
                break;
            case (BattleStates.CALCDAMAGE):         //Calculate damage done by player look for existing status effects and add that damage
                if (currentUser == BattleStates.PLAYERCHOICE)
                {
                    _battleCalcScript.CalculateTotalPlayerDamage(playerUsedAbility);
                }
                else if (currentUser == BattleStates.ENEMYCHOICE)
                {
                    _battleCalcScript.CalculateTotalEnemyDamage(enemyUsedAbility);
                }
                //Debug.Log("Calculating Damage");
                 CheckWhoGoesNext();
                break;
            case (BattleStates.ADDSTATUSEFFECTS):   //try to add a status effect if it exists
                _battleStateAddStatusEffectScript.CheckAbilityForStatusEffects(playerUsedAbility);
                break;

            case (BattleStates.ENDTURN):
                totalTurnCount += 1;
                playerDidCompleteTurn = false;
                enemyDidCompleteTurn = false;
                Debug.Log(totalTurnCount + "turn count");
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

    private void CheckWhoGoesNext()
    {
        if (playerDidCompleteTurn && !enemyDidCompleteTurn)
        {
            currentState = BattleStates.ENEMYCHOICE;
        }
        if (!playerDidCompleteTurn && enemyDidCompleteTurn)
        {
            currentState = BattleStates.PLAYERCHOICE;
        }
        if (playerDidCompleteTurn && enemyDidCompleteTurn)
        {
            currentState = BattleStates.ENDTURN;
        }
    }
}
