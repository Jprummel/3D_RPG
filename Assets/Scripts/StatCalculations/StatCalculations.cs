using UnityEngine;
using System.Collections;

public class StatCalculations
{
    private Party _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
    private TurnBasedCombatStateMachine _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
    //Player stat modifiers
    private float _playerStrengthModifier   = 0.2f;     //20%
    private float _playerStaminaModifier    = 0.0f;     //0%
    private float _playerSpiritModifier     = 0.3f;     //30%
    private float _playerIntellectModifier  = 0.2f;     //20%
    private float _playerOverpowerModifier  = 0.2f;     //20%
    private float _playerLuckModifier       = 0.1f;     //10%
    private float _playerMasteryModifier    = 0.1f;     //10%
    private float _playerCharismaModifier   = 0.1f;     //10%

    private float _statModifier;

    private float _mainStatModifier         = 0.5f;
    private float _secondaryStatModifier    = 0.2f;

    public enum StatType
    {
        STRENGTH,
        STAMINA,
        SPIRIT,
        INTELLECT,
        OVERPOWER,
        LUCK,
        MASTERY,
        CHARISMA
    }

    public int CalculateStat(int statVal, StatType statType, int level)
    {        
            SetPlayerModifier(statType);
            return (statVal + (int)((statVal * _statModifier) * level)); //Statval from the respective information script * statmodifier from vars above * level
    }

    public void SetPlayerModifier(StatType statType)
    {
        if (statType == StatType.STRENGTH)
        {
            _statModifier = _playerStrengthModifier;
        }
        if (statType == StatType.STAMINA)
        {
            _statModifier = _playerStaminaModifier;
        }
        if (statType == StatType.SPIRIT)
        {
            _statModifier = _playerSpiritModifier;
        }
        if (statType == StatType.INTELLECT)
        {
            _statModifier = _playerIntellectModifier;
        }
        if (statType == StatType.OVERPOWER)
        {
            _statModifier = _playerOverpowerModifier;
        }
        if (statType == StatType.LUCK)
        {
            _statModifier = _playerLuckModifier;
        }
        if (statType == StatType.MASTERY)
        {
            _statModifier = _playerMasteryModifier;
        }
        if (statType == StatType.CHARISMA)
        {
            _statModifier = _playerCharismaModifier;
        }
    }

    public int CalculateCharactersHealth(int statValue)
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            return statValue * 100 + (partyMember.Level * 39);
        }
        return 0 ; //Calculate health based on total Stamina stat times 100
    }

    public int CalculateHealth(int statValue)
    {
        return statValue * 100;
    }

    public int CalculateCharactersMana(int statValue)
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            return statValue * 20;
        }
        return 0;  //Calculate energy based on total Spirit times 50
    }

    public int CalculateEnergy(int statValue)
    {
        foreach (BaseEnemy enemy in _tbs.enemiesInBattle)
        {
            return statValue * 20;
        }
        return 0;
    }
}

