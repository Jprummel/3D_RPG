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

    public int CalculateCharactersHealth(int statValue)
    {
        return statValue * 100 + (PlayerInformation.CharactersLevel * 39) ; //Calculate health based on total Stamina stat times 100
    }

    public int CalculateEnemyHealth(int statValue)
    {
        return statValue * 100;
    }

    public int CalculateCharactersMana(int statValue)
    {
        return statValue * 20;  //Calculate energy based on total Spirit times 50
    }

    public int CalculateEnemyEnergy(int statValue)
    {
        return statValue * 20;
    }

    public float FindAndCalculatePlayerMainStatModifier()
    {
        switch (PlayerInformation.CharactersClass.CharactersClass)
        {
            case(BaseCharacterClass.CharactersClasses.WARRIOR):          //WARRIOR
                return (PlayerInformation.Stamina     * _mainStatModifier) + (PlayerInformation.Strength    * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.BERSERKER):       //BERSERKER
                return (PlayerInformation.Strength    * _mainStatModifier) + (PlayerInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.ROGUE):           //ROGUE
                return (PlayerInformation.Strength    * _mainStatModifier) + (PlayerInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.MAGE):            //MAGE
                return (PlayerInformation.Intellect   * _mainStatModifier) + (PlayerInformation.Spirit      * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.CARDMASTER):      //CARD MASTER
                return (PlayerInformation.Intellect   * _mainStatModifier) + (PlayerInformation.Strength    * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.MIME):            //MIME
                return (PlayerInformation.Spirit      * _mainStatModifier) + (PlayerInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.PALADIN):         //PALADIN
                return (PlayerInformation.Stamina     * _mainStatModifier) + (PlayerInformation.Intellect   * _secondaryStatModifier);
            case (BaseCharacterClass.CharactersClasses.SHAMAN):          //SHAMAN
                return (PlayerInformation.Spirit      * _mainStatModifier) + (PlayerInformation.Intellect   * _secondaryStatModifier);
        }

       return 1.0f;
    }
}

