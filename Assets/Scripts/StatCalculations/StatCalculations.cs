using UnityEngine;
using System.Collections;

public class StatCalculations
{

    //Enemy stat modifiers
    private float _enemyStrengthModifier = 0.25f;    //25%
    private float _enemyStaminaModifier = 0.25f;    //25%
    private float _enemySpiritModifier = 0.2f;     //20%
    private float _enemyIntellectModifier = 0.2f;     //20%
    private float _enemyOverpowerModifier = 0.1f;     //10%
    private float _enemyLuckModifier = 0.1f;     //10%
    private float _enemyMasteryModifier = 0.1f;     //10%
    private float _enemyCharismaModifier = 0.1f;     //10%
    //Player stat modifiers
    private float _playerStrengthModifier = 0.2f;     //20%
    private float _playerStaminaModifier = 0.3f;     //30%
    private float _playerSpiritModifier = 0.3f;     //30%
    private float _playerIntellectModifier = 0.2f;     //20%
    private float _playerOverpowerModifier = 0.2f;     //20%
    private float _playerLuckModifier = 0.1f;     //10%
    private float _playerMasteryModifier = 0.1f;     //10%
    private float _playerCharismaModifier = 0.1f;     //10%

    private float _statModifier;

    private float _mainStatModifier = 0.5f;
    private float _secondaryStatModifier = 0.2f;

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

    public int CalculateStat(int statVal, StatType statType, int level, bool isEnemy)
    {
        if (isEnemy)
        {
            SetEnemyModifier(statType);
            return (statVal + (int)((statVal * _statModifier) * level));
        }
        else if (!isEnemy)
        {
            SetEnemyModifier(statType);
            return (statVal + (int)((statVal * _statModifier) * level));
        }
        return 0;
    }

    private void SetEnemyModifier(StatType statType)
    {
        if (statType == StatType.STRENGTH)
        {
            _statModifier = _enemyStrengthModifier;
            _statModifier = _playerStrengthModifier;
        }
        if (statType == StatType.STAMINA)
        {
            _statModifier = _enemyStaminaModifier;
            _statModifier = _playerStaminaModifier;
        }
        if (statType == StatType.SPIRIT)
        {
            _statModifier = _enemySpiritModifier;
            _statModifier = _playerSpiritModifier;
        }
        if (statType == StatType.INTELLECT)
        {
            _statModifier = _enemyIntellectModifier;
            _statModifier = _playerIntellectModifier;
        }
        if (statType == StatType.OVERPOWER)
        {
            _statModifier = _enemyOverpowerModifier;
            _statModifier = _playerOverpowerModifier;
        }
        if (statType == StatType.LUCK)
        {
            _statModifier = _enemyLuckModifier;
            _statModifier = _playerLuckModifier;
        }
        if (statType == StatType.MASTERY)
        {
            _statModifier = _enemyMasteryModifier;
            _statModifier = _playerMasteryModifier;
        }
        if (statType == StatType.CHARISMA)
        {
            _statModifier = _enemyCharismaModifier;
            _statModifier = _playerCharismaModifier;
        }
    }

    public int CalculateHealth(int statValue)
    {
        return statValue * 100; //Calculate health based on total Stamina stat times 100
    }

    public int CalculateEnergy(int statValue)
    {
        return statValue * 50;  //Calculate energy based on total Spirit times 50
    }

    public float FindAndCalculatePlayerMainStatModifier()
    {
        switch (GameInformation.PlayerClass.CharacterClass)
        {
            case(BaseCharacterClass.CharacterClasses.WARRIOR):          //WARRIOR
                return (GameInformation.Stamina     * _mainStatModifier) + (GameInformation.Strength    * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.BERSERKER):       //BERSERKER
                return (GameInformation.Strength    * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.ROGUE):           //ROGUE
                return (GameInformation.Strength    * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.RANGER):          //RANGER
                return (GameInformation.Strength    * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.MAGE):            //MAGE
                return (GameInformation.Intellect   * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.NECROMANCER):     //NECROMANCER
                return (GameInformation.Intellect   * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.CARDMASTER):      //CARD MASTER
                return (GameInformation.Intellect   * _mainStatModifier) + (GameInformation.Strength    * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.DRUID):           //DRUID
                return (GameInformation.Stamina     * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.MIME):            //MIME
                return (GameInformation.Spirit      * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.SHADOWKNIGHT):    //SHADOWKNIGHT
                return (GameInformation.Strength    * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.ALCHEMIST):       //ALCHEMIST
                return (GameInformation.Strength    * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.PALADIN):         //PALADIN
                return (GameInformation.Stamina     * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.SHAMAN):          //SHAMAN
                return (GameInformation.Spirit      * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.MONK):            //MONK
                return (GameInformation.Strength    * _mainStatModifier) + (GameInformation.Stamina     * _secondaryStatModifier);
       }

       return 1.0f;
    }
}

