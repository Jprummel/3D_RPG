using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleStateStart{

    private EnemyDataBase _enemies;
    private BaseEnemy _newEnemy;
    private StatCalculations        _statCalculationsScript     = new StatCalculations();
   
    private int _playerStamina;
    private int _playerSpirit;
    private int _playerHealth;
    private int _playerEnergy;

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

        Debug.Log(EnemyInformation.EnemyClass.CharacterClassName);
        Debug.Log(EnemyInformation.EnemyLevel);
        Debug.Log(EnemyInformation.EnemyName);        
    }

    public void ChooseWhoGoesFirst()
    {
        if (GameInformation.Luck >= EnemyInformation.Luck)
        {
            //Player goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
        }
        if (GameInformation.Luck < EnemyInformation.Luck)
        {
            //Enemy goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;            
        }
        if (GameInformation.Luck == EnemyInformation.Luck)
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
        _playerStamina                      = _statCalculationsScript.CalculateStat(GameInformation.Stamina , StatCalculations.StatType.STAMINA , GameInformation.PlayerLevel);
        _playerSpirit                       = _statCalculationsScript.CalculateStat(GameInformation.Spirit  , StatCalculations.StatType.SPIRIT  , GameInformation.PlayerLevel);
        _playerHealth                       = _statCalculationsScript.CalculatePlayerHealth(_playerStamina);
        _playerEnergy                       = _statCalculationsScript.CalculatePlayerEnergy(_playerSpirit);
        GameInformation.PlayerMaxHealth     = _playerHealth;
        GameInformation.PlayerHealth        = GameInformation.PlayerMaxHealth;
        GameInformation.PlayerMaxEnergy     = _playerEnergy;
        GameInformation.PlayerEnergy        = GameInformation.PlayerMaxEnergy;
    }
}
