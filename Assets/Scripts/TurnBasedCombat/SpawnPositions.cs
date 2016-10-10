using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPositions : MonoBehaviour {

    private TurnBasedCombatStateMachine _tbs;
    [SerializeField]private Transform _heroSpawnPoints;
    [SerializeField]private Transform _enemySpawnPoints;
	// Use this for initialization
	void Start () {
        _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetPositions()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            //GameObject heroModel = Instantiate();
        }
    }
}
