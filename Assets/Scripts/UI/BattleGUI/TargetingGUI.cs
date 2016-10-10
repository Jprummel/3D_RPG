using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TargetingGUI : MonoBehaviour {

    private TurnBasedCombatStateMachine _tbs;
    public BaseEnemy heroesTarget;
    [SerializeField]private GameObject _targetPanel;
    [SerializeField]private Button _enemyTargetButtonPrefab;
	// Use this for initialization
	void Start () {
        _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
        GetTargets();
	}

    public void GetTargets()
    {
        foreach (BaseEnemy enemy in _tbs.enemiesInBattle)
        {
            BaseEnemy targetEnemy = enemy;
            Text targetName;
            Button targetButton = Instantiate(_enemyTargetButtonPrefab);
            targetName = targetButton.GetComponentInChildren<Text>();
            targetName.text = targetEnemy.Name;
            targetButton.transform.SetParent(_targetPanel.transform);
            ChooseTarget(targetEnemy, targetButton);
        }
    }

    void ChooseTarget(BaseEnemy target, Button targetButton)
    {
        targetButton.onClick.AddListener(() =>
        {
            heroesTarget = target;
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
            _targetPanel.SetActive(false);
        });
    }
}
