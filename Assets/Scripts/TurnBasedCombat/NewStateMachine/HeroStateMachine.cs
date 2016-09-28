using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroStateMachine : MonoBehaviour {

    private BattleStateMachine _bsm;

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

	// Use this for initialization
	void Start () {
        _bsm = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleStateMachine>();
        currentState = HeroState.PROCESSING;
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case(HeroState.PROCESSING):
                FillProgressBar();
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
}
