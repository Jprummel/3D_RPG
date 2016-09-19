using UnityEngine;
using System.Collections;

public class StatCalculations
{

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

    public int CalculatePlayerHealth(int statValue)
    {
        return statValue * 100 + (GameInformation.PlayerLevel * 39) ; //Calculate health based on total Stamina stat times 100
    }

    public int CalculateEnemyHealth(int statValue)
    {
        return statValue * 100;
    }

    public int CalculatePlayerEnergy(int statValue)
    {
        return statValue * 20;  //Calculate energy based on total Spirit times 50
    }

    public int CalculateEnemyEnergy(int statValue)
    {
        return statValue * 20;
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
            case (BaseCharacterClass.CharacterClasses.MAGE):            //MAGE
                return (GameInformation.Intellect   * _mainStatModifier) + (GameInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.CARDMASTER):      //CARD MASTER
                return (GameInformation.Intellect   * _mainStatModifier) + (GameInformation.Strength    * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.MIME):            //MIME
                return (GameInformation.Spirit      * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.PALADIN):         //PALADIN
                return (GameInformation.Stamina     * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharacterClasses.SHAMAN):          //SHAMAN
                return (GameInformation.Spirit      * _mainStatModifier) + (GameInformation.Intellect   * _secondaryStatModifier);
        }

       return 1.0f;
    }
}

