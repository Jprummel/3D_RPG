using UnityEngine;
using System.Collections;

public class BattleCalculations {

    private StatCalculations    _statCalcScript = new StatCalculations();
    private BaseAbility         _playerUsedAbility;
    private bool                _abilityHits;
    private int                 _abilityPower;
    private float               _totalAbilityPowerDamage;
    private int                 _totalUsedAbilityDamage;
    private int                 _statusEffectDamage;
    private int                 _totalCritStrikeDamage;
    private int                 _abilityDamageToSelf;
    private int                 _totalPlayerDamage;
    private float               _damageVariatyModifier = .025f; // 2.5%   

    public void CalculateTotalPlayerDamage(BaseAbility usedAbility)
    {

        //Calculation for the players damage to the enemy
        _playerUsedAbility      = usedAbility;  //Gets the chosen ability of the player
        _totalUsedAbilityDamage = (int)CalculatePlayerAbilityDamage();
        _totalCritStrikeDamage  = CalculateCriticalHitDamage();
        _statusEffectDamage     = CalculateStatusEffectDamage();
        _totalPlayerDamage      = _totalUsedAbilityDamage + _totalCritStrikeDamage + _statusEffectDamage;
        _totalPlayerDamage     += (int)(Random.Range(-(_totalPlayerDamage * _damageVariatyModifier), _totalPlayerDamage * _damageVariatyModifier)); // Creates variety in damage by a max of -2.5% or a max of +2.5%
        Debug.Log(_totalPlayerDamage + "Damage done by player");
        GameInformation.PlayerEnergy -= _playerUsedAbility.AbilityCost;
        if (CheckIfAbilityHits())
        {
            EnemyInformation.EnemyHealth -= _totalPlayerDamage;
            GameInformation.PlayerHealth -= CalculateDamageToSelf();
        }
        TurnBasedCombatStateMachine.playerDidCompleteTurn = true;   //Tells the state machine that the player completed its turn
    }

    public void CalculateTotalEnemyDamage(BaseAbility usedAbility)
    {
        //Calculation for the enemy's damage to the player
        _playerUsedAbility      = usedAbility;  //Gets the chosen ability of the enemy
        _totalUsedAbilityDamage = (int)CalculateEnemyAbilityDamage();
        _totalCritStrikeDamage  = CalculateCriticalHitDamage();
        _statusEffectDamage     = CalculateStatusEffectDamage();
        _totalPlayerDamage      = _totalUsedAbilityDamage + _totalCritStrikeDamage + _statusEffectDamage;
        _totalPlayerDamage     += (int)(Random.Range(-(_totalPlayerDamage * _damageVariatyModifier), _totalPlayerDamage * _damageVariatyModifier)); // Creates variety in damage by a max of -2.5% or a max of +2.5%
        Debug.Log(_totalPlayerDamage + "Damage done by enemy");
        EnemyInformation.EnemyEnergy -= _playerUsedAbility.AbilityCost;
        GameInformation.PlayerHealth -= _totalPlayerDamage;
        EnemyInformation.EnemyHealth -= CalculateDamageToSelf();
        TurnBasedCombatStateMachine.enemyDidCompleteTurn = true;    //Tells the state machine that the enemy completed its turn
    }

    private int CalculateDamageToSelf()
    {
        //Debug.Log(_playerUsedAbility.AbilityDamageToSelf + "Self Damage");
        return _abilityDamageToSelf = _playerUsedAbility.AbilityDamageToSelf;
    }
    
    //Player Ability Damage
    private float CalculatePlayerAbilityDamage()
    {
        //_abilityPower = _playerUsedAbility.AbilityPower;   //Retrieves power of ability
        switch (_playerUsedAbility.AbilityType)
        {
            case BaseAbility.AbilityTypes.PHYSICAL:
               return _totalAbilityPowerDamage = (GameInformation.Strength * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;               
            case BaseAbility.AbilityTypes.MAGICAL:
                return _totalAbilityPowerDamage = (GameInformation.Intellect * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;                
            case BaseAbility.AbilityTypes.HYBRID:
               return _totalAbilityPowerDamage = (GameInformation.Strength + GameInformation.Intellect / 1.5f * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;
        }
        return _totalAbilityPowerDamage;
    }
    //Enemy Ability Damage
    private float CalculateEnemyAbilityDamage()
    {
        //_abilityPower = _playerUsedAbility.AbilityPower;   //Retrieves power of ability
        switch (_playerUsedAbility.AbilityType)
        {
            case BaseAbility.AbilityTypes.PHYSICAL:
                return _totalAbilityPowerDamage = (EnemyInformation.Strength * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;
            case BaseAbility.AbilityTypes.MAGICAL:
                return _totalAbilityPowerDamage = (EnemyInformation.Intellect * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;
            case BaseAbility.AbilityTypes.HYBRID:
                return _totalAbilityPowerDamage = (EnemyInformation.Strength + EnemyInformation.Intellect / 1.5f * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;
        }
        return _totalAbilityPowerDamage;
    }
    //STATUS EFFECTS
    private int CalculateStatusEffectDamage()
    {
        return _statusEffectDamage = TurnBasedCombatStateMachine._statusEffectBaseDamage * GameInformation.PlayerLevel;
    }
    //CRITICAL HITS
    private int CalculateCriticalHitDamage()
    {
        if (DecideIfAbilityCriticalHits())
        {
            //_totalCritStrikeDamage = 0;
            return _totalCritStrikeDamage = (int)(_playerUsedAbility.AbilityCritModifier * _totalAbilityPowerDamage);
        }
        else
        {
            return _totalCritStrikeDamage = 0;
        }
    }

    private bool DecideIfAbilityCriticalHits()
    {        
        int randomTemp = Random.Range(1, 101);
        if (randomTemp <= _playerUsedAbility.AbilityCritChance)
        {
            Debug.Log("Critical Hit!!");
            return true; // Ability did critically hit
        }
        else
        {
            //Debug.Log("Normal Hit.");
            return false; // Ability did not critically hit
        }
    }

    private bool CheckIfAbilityHits()
    {
        int abilityHitChance = Random.Range(1, 101);
        Debug.Log(abilityHitChance);
        Debug.Log(_playerUsedAbility.AbilityName + "Used by player");
        Debug.Log(_playerUsedAbility.AbilityHitChance + "Hit chance");
        if (abilityHitChance <= _playerUsedAbility.AbilityHitChance)
        {
            Debug.Log("Hit");
            return true; // Ability did hit
        }
        else
        {
            Debug.Log("Missed");
            return false; // Ability missed
        }
    }
}
