using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    private Party _party;
    private IncreaseExperience _incrXP = new IncreaseExperience();
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

    void Awake ()
    {
        
    }

	void Start () {
        _party = GameObject.Find("PartyManager").GetComponent<Party>();
        _hasAddedXP = false;
        totalTurnCount = 1;
        currentState = BattleStates.START;        
	}

	// Update is called once per frame
	void Update () {
        //_party = GameObject.Find("PartyManager").GetComponent<Party>();
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
