using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BattleStateMachine : MonoBehaviour 
{
    //Gets the party information
    private Party _party;
    //Gets the battle scripts
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

    public static BattleState currentState;

    //Lists of everyone in battle and who is taking turn
    public List<GameObject> heroesToManage = new List<GameObject>();
    public List<GameObject> heroesInBattle = new List<GameObject>(); //all playable characters in battle
    public List<GameObject> enemiesInBattle = new List<GameObject>(); //All the enemies in battle
    public List<TurnInformation> performList = new List<TurnInformation>();

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

        enemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag(Tags.ENEMY)); //Adds all enemies with the Enemy tag to the _enemiesInBattle list
        heroesInBattle.AddRange(GameObject.FindGameObjectsWithTag(Tags.HERO)); //Adds all heroes with the Hero tag to the _heroesInBattle list
	}
	
	// Update is called once per frame
	void Update () 
    {
        switch (currentState)
        {
            case(BattleState.START):
                //Setup the battle and create enemies
                _battleStateStartScript.PrepareBattle();
                currentState = BattleState.IDLE;
                break;
            case(BattleState.IDLE):
                break;
            case(BattleState.CHOOSEACTION):
                GameObject performer = GameObject.Find(performList[0].attacker);
                if (performList[0].type == "Enemy")
                {
                    EnemyStateMachine esm = performer.GetComponent<EnemyStateMachine>();
                    //esm
                }
                if (performList[0].type == "Hero")
                {
                    HeroStateMachine hsm = performer.GetComponent<HeroStateMachine>();
                    hsm.enemyToAttack = performList[0].target;
                    hsm.currentState = HeroStateMachine.HeroState.ACTION;
                }
                break;
            case(BattleState.PERFORMACTION):
                if (heroesInBattle.Count == 0)
                {
                    currentState = BattleState.LOSE;
                }

                if(enemiesInBattle.Count == 0)
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
