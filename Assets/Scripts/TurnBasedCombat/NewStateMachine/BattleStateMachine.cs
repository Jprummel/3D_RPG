using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BattleStateMachine : MonoBehaviour 
{
    private Party _party;
    private IncreaseExperience _incrXP;
    private BattleStateStart _battleStateStartScript;
    private BattleCalculations _battleCalcScript;
    private BattleStateAddStatusEffects _battleStateAddStatusEffectScript;
    private BattleStateEnemyChoice _battleStateEnemyChoiceScript;
    private bool _hasAddedXP;
    public static BaseAbility playerUsedAbility;
    public static BaseAbility enemyUsedAbility;

    public enum BattleState
    {
        START,
        IDLE,
        CHOOSEACTION,
        PERFORMACTION,
        WIN,
        LOSE
    }

    public BattleState currentState;

    public List<GameObject> _heroesToManage = new List<GameObject>();
    public List<GameObject> _heroesInBattle = new List<GameObject>(); //all playable characters in battle
    public List<GameObject> _enemiesInBattle = new List<GameObject>(); //All the enemies in battle
    //public List<TurnHandler> _performerList = new List<TurnHandler>(); //List of characters performing an action during a turn

    void Awake()
    {
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
        _incrXP = new IncreaseExperience();
        _battleStateStartScript = new BattleStateStart();
        _battleCalcScript = new BattleCalculations();
        _battleStateAddStatusEffectScript = new BattleStateAddStatusEffects();
        _battleStateEnemyChoiceScript = new BattleStateEnemyChoice();
    }

	// Use this for initialization
	void Start () {
        _hasAddedXP = false;
        currentState = BattleState.START;

        _enemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag(Tags.ENEMY)); //Adds all enemies with the Enemy tag to the _enemiesInBattle list
        _heroesInBattle.AddRange(GameObject.FindGameObjectsWithTag(Tags.HERO)); //Adds all heroes with the Hero tag to the _heroesInBattle list
	}
	
	// Update is called once per frame
	void Update () 
    {
        switch (currentState)
        {
            case(BattleState.START):
                //Setup the battle and create enemies
                _battleStateStartScript.PrepareBattle();
                break;
            case(BattleState.IDLE):
                break;
            case(BattleState.CHOOSEACTION):
                break;
            case(BattleState.PERFORMACTION):
                if (_heroesInBattle.Count == 0)
                {
                    currentState = BattleState.LOSE;
                }

                if(_enemiesInBattle.Count == 0)
                {
                    currentState = BattleState.WIN;
                }
                break;    
            case(BattleState.WIN):
                if (!_hasAddedXP)
                {
                    _incrXP.AddExperience();
                    _hasAddedXP = true;
                    SceneManager.LoadScene(PlayerInformation.PlayerMapScene);

                }
                break;
            case(BattleState.LOSE):
                Debug.Log("You lost git gud");
                break;
        }    
	}
}
