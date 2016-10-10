using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleStateStart{
    //This class is responsible for setting up the battle in the first state

    private Party               _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
    private TurnBasedCombatStateMachine _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
    private EnemyDataBase       _enemies;
    private BaseEnemy           _newEnemy;
    private StatCalculations    _statCalculationsScript = new StatCalculations();

    public List<BaseEnemy> _createdEnemies;
   
    private int _playerStamina;
    private int _playerSpirit;
    private int _CharactersHealth;
    private int _CharactersMana;

    private int _Health;
    private int _Energy;
    
    public void PrepareBattle()
    {
        _enemies = new EnemyDataBase();
        //Create enemy
        //CreateNewEnemy();
        AddEnemies();
        //find out players vitals (stat calcs)
        DeterminePlayerVitals();
        //figure out who goes first based on luck stat
        ChooseWhoGoesFirst();
        //Does scene have status effect? if it does apply that effect throughout the fight
    }

    private void AddEnemies()
    {
        int enemiesToCreate = Random.Range(1, 4);
        Debug.Log(enemiesToCreate);
        switch (enemiesToCreate)
        {
            case 1:
                _tbs.enemiesInBattle.Add(CreateNewEnemy());
                //_createdEnemies.Add(CreateNewEnemy());
                break;
            case 2:
                _tbs.enemiesInBattle.Add(CreateNewEnemy());
                _tbs.enemiesInBattle.Add(CreateNewEnemy());
                Debug.Log(_tbs.enemiesInBattle[0].Name + _tbs.enemiesInBattle[1].Name);
                break;
            case 3:
                _tbs.enemiesInBattle.Add(CreateNewEnemy());
                _tbs.enemiesInBattle.Add(CreateNewEnemy());
                _tbs.enemiesInBattle.Add(CreateNewEnemy());
                Debug.Log(_tbs.enemiesInBattle[0].Name + _tbs.enemiesInBattle[1].Name + _tbs.enemiesInBattle[2].Name);
                break;
            case 4:
                _createdEnemies.Add(CreateNewEnemy());
                _createdEnemies.Add(CreateNewEnemy());
                _createdEnemies.Add(CreateNewEnemy());
                _createdEnemies.Add(CreateNewEnemy());
                Debug.Log(_createdEnemies[0].Name + _createdEnemies[1].Name + _createdEnemies[2].Name + _createdEnemies[3].Name);
                break;
        }
    }

    private BaseEnemy CreateNewEnemy()
    {
        

        _newEnemy = _enemies.SpawnRandomEnemy(); //Gets random enemy from the enemy database appropriate for the players level
        
        _newEnemy.MaxHealth = _statCalculationsScript.CalculateHealth(_newEnemy.Stamina);
        _newEnemy.Health    = _newEnemy.MaxHealth;
        _newEnemy.MaxMana   = _statCalculationsScript.CalculateEnergy(_newEnemy.Spirit);
        _newEnemy.Mana      = _newEnemy.MaxMana;

        return _newEnemy;
    }

    public void ChooseWhoGoesFirst()
    {
        if (_party.characters[0].Luck >= EnemyInformation.Luck)
        {
            //Player goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
        }
        if (_party.characters[0].Luck < EnemyInformation.Luck)
        {
            //Enemy goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
        }
        if (_party.characters[0].Luck == EnemyInformation.Luck)
        {
            float randomTurnChecker = Random.Range(0, 1);
            if (randomTurnChecker >= 0.5f)
            {
                //Player goes first
                TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
            }
            else if (randomTurnChecker < 0.5f)
            {
                //Enemy goes first
                TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
            }
        }
    }

    private void DeterminePlayerVitals()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            _playerStamina = _statCalculationsScript.CalculateStat(partyMember.Stamina, StatCalculations.StatType.STAMINA, partyMember.Level);
            _playerSpirit = _statCalculationsScript.CalculateStat(partyMember.Spirit, StatCalculations.StatType.SPIRIT, partyMember.Level);
            _CharactersHealth = _statCalculationsScript.CalculateCharactersHealth(_playerStamina);
            _CharactersMana = _statCalculationsScript.CalculateCharactersMana(_playerSpirit);
            partyMember.MaxHealth = _CharactersHealth;
            partyMember.Health = partyMember.MaxHealth;
            partyMember.MaxMana = _CharactersMana;
            partyMember.Mana = partyMember.MaxMana;
        }
    }
}
