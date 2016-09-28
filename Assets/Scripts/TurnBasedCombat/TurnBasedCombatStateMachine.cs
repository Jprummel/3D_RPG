using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    private Party                       _party;
    private IncreaseExperience          _incrXP;
    private BattleStateStart            _battleStateStartScript;
    private BattleCalculations          _battleCalcScript;
    private BattleStateAddStatusEffects _battleStateAddStatusEffectScript;
    private BattleStateEnemyChoice      _battleStateEnemyChoiceScript;
    private bool                        _hasAddedXP;   
    public static BaseAbility           playerUsedAbility;
    public static BaseAbility           enemyUsedAbility;
    public static int                   statusEffectBaseDamage;
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

    void Awake ()
    {
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
        _incrXP = new IncreaseExperience();
        _battleStateStartScript = new BattleStateStart();
        _battleCalcScript = new BattleCalculations();
        _battleStateAddStatusEffectScript = new BattleStateAddStatusEffects();
        _battleStateEnemyChoiceScript = new BattleStateEnemyChoice();
    }

	void Start () {
        _hasAddedXP = false;
        totalTurnCount = 1;
        currentState = BattleStates.START;        
	}

	// Update is called once per frame
	void Update () {
        //Debug.Log(currentState);

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
                 CheckWhoGoesNext();
                break;
            case (BattleStates.ADDSTATUSEFFECTS):   //try to add a status effect if it exists
                _battleStateAddStatusEffectScript.CheckAbilityForStatusEffects(playerUsedAbility);
                break;

            case (BattleStates.ENDTURN):
                totalTurnCount += 1;
                playerDidCompleteTurn = false;
                enemyDidCompleteTurn = false;
                if (_party.characters[0].Health <= 0)
                {
                    _party.characters[0].Health = 0;
                    currentState = BattleStates.LOSE;
                }else if(EnemyInformation.EnemyHealth <=0 )
                {
                    EnemyInformation.EnemyHealth = 0;
                    currentState = BattleStates.WIN;
                }
                else
                {
                    _battleStateStartScript.ChooseWhoGoesFirst();
                }
                break;
            case (BattleStates.LOSE):
                Debug.Log("You Lost");
                break;
            case (BattleStates.WIN):
                if (!_hasAddedXP)
                {
                    _incrXP.AddExperience();
                    _hasAddedXP = true;
                    SceneManager.LoadScene(PlayerInformation.PlayerMapScene);

                }
                break;
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
