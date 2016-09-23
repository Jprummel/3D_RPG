using UnityEngine;
using System.Collections;

public class BattleCalculations {

    private StatCalculations    _statCalcScript = new StatCalculations();
    private BaseAbility         _playerUsedAbility;
    private BaseAbility         _enemyUsedAbility;
    private bool                _abilityHits;
    private int                 _abilityPower;
    private float               _totalAbilityPowerDamage;
    private int                 _totalUsedAbilityDamage;
    private int                 _statusEffectDamage;
    private int                 _totalCritStrikeDamage;
    private int                 _abilityDamageToSelf;
    private int                 _totalPlayerDamage;
    private int                 _totalEnemyDamage;
    private float               _damageVariatyModifier = .025f; // 2.5%   

    public void CalculateTotalPlayerDamage(BaseAbility usedAbility)
    {

        //Calculation for the players damage to the enemy
        _playerUsedAbility      = usedAbility;  //Gets the chosen ability of the player
        if (PlayerInformation.CharactersMana >= _playerUsedAbility.AbilityCost)
        {
            _totalUsedAbilityDamage = (int)CalculatePlayerAbilityDamage();
            _totalCritStrikeDamage = CalculateCriticalHitDamage();
            _statusEffectDamage = CalculateStatusEffectDamage();
            _totalPlayerDamage = _totalUsedAbilityDamage + _totalCritStrikeDamage + _statusEffectDamage;
            _totalPlayerDamage += (int)(Random.Range(-(_totalPlayerDamage * _damageVariatyModifier), _totalPlayerDamage * _damageVariatyModifier)); // Creates variety in damage by a max of -2.5% or a max of +2.5%
            Debug.Log(_totalPlayerDamage + "Damage done by player");
            PlayerInformation.CharactersMana -= _playerUsedAbility.AbilityCost;
            if (CheckIfAbilityHits())
            {
                EnemyInformation.EnemyHealth -= _totalPlayerDamage;
                PlayerInformation.CharactersHealth -= CalculateDamageToSelf();
            }
            TurnBasedCombatStateMachine.playerDidCompleteTurn = true;   //Tells the state machine that the player completed its turn
        }
    }

    public void CalculateTotalEnemyDamage(BaseAbility usedAbility)
    {
        //Calculation for the enemy's damage to the player
        _enemyUsedAbility       = usedAbility;  //Gets the chosen ability of the enemy
        if (EnemyInformation.EnemyEnergy >= _enemyUsedAbility.AbilityCost)
        {
            _totalUsedAbilityDamage = (int)CalculateEnemyAbilityDamage();
            _totalCritStrikeDamage = CalculateCriticalHitDamage();
            _statusEffectDamage = CalculateStatusEffectDamage();
            _totalEnemyDamage = _totalUsedAbilityDamage + _totalCritStrikeDamage + _statusEffectDamage;
            _totalEnemyDamage += (int)(Random.Range(-(_totalEnemyDamage * _damageVariatyModifier), _totalEnemyDamage * _damageVariatyModifier)); // Creates variety in damage by a max of -2.5% or a max of +2.5%
            Debug.Log(_totalEnemyDamage + "Damage done by enemy");
            Debug.Log(_enemyUsedAbility + "Enemyskill");
            EnemyInformation.EnemyEnergy -= _enemyUsedAbility.AbilityCost;
            PlayerInformation.CharactersHealth -= _totalEnemyDamage;
            EnemyInformation.EnemyHealth -= CalculateDamageToSelf();
            TurnBasedCombatStateMachine.enemyDidCompleteTurn = true;    //Tells the state machine that the enemy completed its turn
        }
    }

    private int CalculateDamageToSelf()
    {
        //Debug.Log(_playerUsedAbility.AbilityDamageToSelf + "Self Damage");
        return _abilityDamageToSelf = _playerUsedAbility.AbilityDamageToSelf;
    }
    
    //Player Ability Damage
    private float CalculatePlayerAbilityDamage()
    {
        switch (_playerUsedAbility.AbilityType)
        {
            case BaseAbility.AbilityTypes.PHYSICAL:
               return _totalAbilityPowerDamage = (PlayerInformation.Strength * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;               
            case BaseAbility.AbilityTypes.MAGICAL:
                return _totalAbilityPowerDamage = (PlayerInformation.Intellect * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;                
            case BaseAbility.AbilityTypes.HYBRID:
               return _totalAbilityPowerDamage = (PlayerInformation.Strength + PlayerInformation.Intellect / 1.5f * _playerUsedAbility.AbilityDamageStatModifier) + _playerUsedAbility.AbilityBaseDamage;
        }
        return _totalAbilityPowerDamage;
    }
    //Enemy Ability Damage
    private float CalculateEnemyAbilityDamage()
    {
        //_abilityPower = _playerUsedAbility.AbilityPower;   //Retrieves power of ability
        switch (_enemyUsedAbility.AbilityType)
        {
            case BaseAbility.AbilityTypes.PHYSICAL:
                return _totalAbilityPowerDamage = (EnemyInformation.Strength * _enemyUsedAbility.AbilityDamageStatModifier) + _enemyUsedAbility.AbilityBaseDamage;
            case BaseAbility.AbilityTypes.MAGICAL:
                return _totalAbilityPowerDamage = (EnemyInformation.Intellect * _enemyUsedAbility.AbilityDamageStatModifier) + _enemyUsedAbility.AbilityBaseDamage;
            case BaseAbility.AbilityTypes.HYBRID:
                return _totalAbilityPowerDamage = (EnemyInformation.Strength + EnemyInformation.Intellect / 1.5f * _enemyUsedAbility.AbilityDamageStatModifier) + _enemyUsedAbility.AbilityBaseDamage;
        }
        return _totalAbilityPowerDamage;
    }
    //STATUS EFFECTS
    private int CalculateStatusEffectDamage()
    {
        return _statusEffectDamage = TurnBasedCombatStateMachine._statusEffectBaseDamage * PlayerInformation.CharactersLevel;
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
            return false; // Ability did not critically hit
        }
    }

    private bool CheckIfAbilityHits()
    {
        int abilityHitChance = Random.Range(1, 101);
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
