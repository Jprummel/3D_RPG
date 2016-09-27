using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleStateStart{

    private Party _party = GameObject.Find("PartyManager").GetComponent<Party>();
    private EnemyDataBase _enemies;
    private BaseEnemy _newEnemy;
    private StatCalculations        _statCalculationsScript     = new StatCalculations();
   
    private int _playerStamina;
    private int _playerSpirit;
    private int _CharactersHealth;
    private int _CharactersMana;

    private int _enemyHealth;
    private int _enemyEnergy;
    
    public void PrepareBattle()
    {
        _enemies = new EnemyDataBase();
        //Create enemy
        CreateNewEnemy();
        //find out players vitals (stat calcs)
        DeterminePlayerVitals();
        //figure out who goes first based on luck stat
        ChooseWhoGoesFirst();
        //Does scene have status effect? if it does apply that effect throughout the fight
    }

    private void CreateNewEnemy()
    {
        _newEnemy = _enemies.SpawnRandomEnemy(); //Gets random enemy from the enemy database appropriate for the players level

        EnemyInformation.EnemyName    = _newEnemy.EnemyName;
        EnemyInformation.EnemyLevel = _newEnemy.EnemyLevel;
        EnemyInformation.EnemyClass = new BaseWarriorClass();
        //Get initial stats
        EnemyInformation.Strength   = _newEnemy.Strength;
        EnemyInformation.Stamina    = _newEnemy.Stamina;
        EnemyInformation.Spirit     = _newEnemy.Spirit;
        EnemyInformation.Intellect  = _newEnemy.Intellect;
        EnemyInformation.Overpower  = _newEnemy.Overpower;
        EnemyInformation.Luck       = _newEnemy.Luck;
        EnemyInformation.Mastery    = _newEnemy.Mastery;
        EnemyInformation.Charisma   = _newEnemy.Charisma;
        //Calculate final modified enemy stats
        /*EnemyInformation.Strength   = _statCalculationsScript.CalculateStat(EnemyInformation.Strength, StatCalculations.StatType.STRENGTH, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Stamina    = _statCalculationsScript.CalculateStat(EnemyInformation.Stamina, StatCalculations.StatType.STAMINA, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Spirit     = _statCalculationsScript.CalculateStat(EnemyInformation.Spirit, StatCalculations.StatType.SPIRIT, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Intellect  = _statCalculationsScript.CalculateStat(EnemyInformation.Intellect, StatCalculations.StatType.INTELLECT, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Overpower  = _statCalculationsScript.CalculateStat(EnemyInformation.Overpower, StatCalculations.StatType.OVERPOWER, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Luck       = _statCalculationsScript.CalculateStat(EnemyInformation.Luck, StatCalculations.StatType.LUCK, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Mastery    = _statCalculationsScript.CalculateStat(EnemyInformation.Mastery, StatCalculations.StatType.MASTERY, EnemyInformation.EnemyLevel, true);
        EnemyInformation.Charisma   = _statCalculationsScript.CalculateStat(EnemyInformation.Charisma, StatCalculations.StatType.CHARISMA, EnemyInformation.EnemyLevel, true);*/
        EnemyInformation.EnemyMaxHealth = _statCalculationsScript.CalculateEnemyHealth(EnemyInformation.Stamina);
        EnemyInformation.EnemyHealth    = EnemyInformation.EnemyMaxHealth;
        EnemyInformation.EnemyMaxEnergy = _statCalculationsScript.CalculateEnemyEnergy(EnemyInformation.Spirit);
        EnemyInformation.EnemyEnergy    = EnemyInformation.EnemyMaxEnergy;

        Debug.Log(EnemyInformation.EnemyClass.CharactersClassName);
        Debug.Log(EnemyInformation.EnemyLevel);
        Debug.Log(EnemyInformation.EnemyName);        
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
        _playerStamina                  = _statCalculationsScript.CalculateStat(_party.characters[0].Stamina , StatCalculations.StatType.STAMINA , _party.characters[0].Level);
        _playerSpirit                   = _statCalculationsScript.CalculateStat(_party.characters[0].Spirit  , StatCalculations.StatType.SPIRIT  , _party.characters[0].Level);
        _CharactersHealth               = _statCalculationsScript.CalculateCharactersHealth(_playerStamina);
        _CharactersMana                 = _statCalculationsScript.CalculateCharactersMana(_playerSpirit);
        _party.characters[0].MaxHealth  = _CharactersHealth;
        _party.characters[0].Health     = _party.characters[0].MaxHealth;
        _party.characters[0].MaxMana    = _CharactersMana;
        _party.characters[0].Mana       = _party.characters[0].MaxMana;
    }
}
