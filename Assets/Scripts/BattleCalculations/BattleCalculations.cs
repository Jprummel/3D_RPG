using UnityEngine;
using System.Collections;

public class BattleCalculations {

    private StatCalculations    _statCalcScript = new StatCalculations();
    private BaseAbility         _playerUsedAbility;
    private int                 _abilityPower;
    private float               _totalAbilityPowerDamage;
    private int                 _totalUsedAbilityDamage;
    private int                 _statusEffectDamage;
    private int                 _totalCritStrikeDamage;
    private float               _totalPlayerDamage;
    private float               _damageVariatyModifier = .025f; // 2.5%   

    public void CalculateTotalPlayerDamage(BaseAbility usedAbility)
    {
        _playerUsedAbility      = usedAbility;
        _totalUsedAbilityDamage = (int)CalculateAbilityDamage();
        _totalCritStrikeDamage  = CalculateCriticalHitDamage();
        _statusEffectDamage     = CalculateStatusEffectDamage();
        _totalPlayerDamage      = _totalUsedAbilityDamage + _totalCritStrikeDamage + _statusEffectDamage;
        _totalPlayerDamage     += (int)(Random.Range(-(_totalPlayerDamage * _damageVariatyModifier), _totalPlayerDamage * _damageVariatyModifier)); // Creates variety in damage by a max of -2.5% or a max of +2.5%
        Debug.Log(_totalPlayerDamage);
        TurnBasedCombatStateMachine.playerDidCompleteTurn = true;
    }

    public void CalculateTotalEnemyDamage(BaseAbility usedAbility)
    {
        _playerUsedAbility      = usedAbility;
        _totalUsedAbilityDamage = (int)CalculateAbilityDamage();
        _totalCritStrikeDamage  = CalculateCriticalHitDamage();
        _statusEffectDamage     = CalculateStatusEffectDamage();
        _totalPlayerDamage      = _totalUsedAbilityDamage + _totalCritStrikeDamage + _statusEffectDamage;
        _totalPlayerDamage     += (int)(Random.Range(-(_totalPlayerDamage * _damageVariatyModifier), _totalPlayerDamage * _damageVariatyModifier)); // Creates variety in damage by a max of -2.5% or a max of +2.5%
        Debug.Log(_totalPlayerDamage);
        TurnBasedCombatStateMachine.enemyDidCompleteTurn = true;
    }

    //ABILITY DAMAGE
    private float CalculateAbilityDamage()
    {
        _abilityPower = _playerUsedAbility.AbilityPower;   //Retrieves power of ability
        _totalAbilityPowerDamage = _abilityPower * _statCalcScript.FindAndCalculatePlayerMainStatModifier();   //Find main stat and use as modifier for damage
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
            Debug.Log("Normal Hit.");
            return false; // Ability did not critically hit
        }
    }
}
