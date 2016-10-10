using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroStateMachine : MonoBehaviour {

    private BattleStateMachine _bsm;
    private MoveToTarget _move;

    public enum HeroState
    {
        PROCESSING, //Bar Filling
        ADDTOLIST,
        WAITING,    //Idling
        SELECTING,  //Selecting action
        ACTION,     //Taking/performing a action
        DEAD        //Hero is dead
    }

    public HeroState currentState;

    //Progress Bar
    private float _currentCooldown;
    private float _maxCooldown =5f;
    [SerializeField]private Image _cooldownBar;

    //IENumerator
    public GameObject enemyToAttack;
    private bool _actionStarted;
    private Vector3 _startPos;
    private float _animSpeed = 5f;

	void Start () {
        _bsm = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<BattleStateMachine>();
        _move = GetComponent<MoveToTarget>();
        currentState = HeroState.PROCESSING;
	}
	
	void Update () {
        switch (currentState)
        {
            case(HeroState.PROCESSING):
                FillProgressBar();
                break;
            case(HeroState.ADDTOLIST):
                _bsm.heroesToManage.Add(this.gameObject);
                currentState = HeroState.WAITING;
                break;
            case(HeroState.WAITING):
                break;
            case(HeroState.ACTION):
                StartCoroutine(ActionCoroutine());
                break;
            case(HeroState.DEAD):
                break;
        }
	}

    void FillProgressBar()
    {
        //Shows the bar filling up while getting ready to choose an action
        _currentCooldown = _currentCooldown + Time.deltaTime;
        float calc_cooldown = _currentCooldown / _maxCooldown;
        _cooldownBar.fillAmount = calc_cooldown;
        if (_currentCooldown >= _maxCooldown)
        {
            currentState = HeroState.ADDTOLIST;
        }
    }

    IEnumerator ActionCoroutine()
    {
        if (_actionStarted)
        {
            yield break; //if action already started break out of numerator
        }

        _actionStarted = true;
        //Animate the enemy near the hero to attack
        Vector3 enemyPosition = new Vector3(enemyToAttack.transform.position.x + 1.5f, enemyToAttack.transform.position.y, enemyToAttack.transform.position.z);
        while (_move.MoveToTargetPos(enemyPosition,5)) { yield return null; } //waits until moving is done 
        //wait a bit
        yield return new WaitForSeconds(0.5f);
        //Do damage

        //Animate back to startPos
        Vector3 startPosition = _startPos;
        while (_move.MoveToTargetPos(startPosition,5)) { yield return null; }
        //Remove this performer from the list in the _bsm (BattleStateMachine)
        _bsm.performList.RemoveAt(0);
        //reset _bsm -> Wait
        BattleStateMachine.currentState = BattleStateMachine.BattleState.IDLE;
        _actionStarted = false;
        //reset the enemy state
        _currentCooldown = 0f;
        currentState = HeroState.PROCESSING;
    }
}
