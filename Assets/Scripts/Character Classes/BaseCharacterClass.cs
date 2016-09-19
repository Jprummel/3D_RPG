using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class BaseCharacterClass{

    private string _characterClassName;
    private string _characterClassDescription;
    //Stats
    private int _strength   = 10;   //Physical damage modifier
    private int _stamina    = 12;   //Health modifier
    private int _spirit     = 12;   //Resource (Mana,Rage etc) Modifier
    private int _intellect  = 9;    //Spell damage modifier
    private int _armor;             //Damage reduction
    private int _overpower  = 10;   //Critical strike chance
    private int _luck       = 10;   //Extra/better loot chance
    private int _mastery    = 9;    //Chance for bonus damage
    private int _charisma   = 10;   //Lower buy prices , increase sell prices, bonus rep , influence on how people see you

    public enum CharacterClasses
    {
        WARRIOR,
        BERSERKER,
        ROGUE,
        MAGE,
        CARDMASTER,
        MIME,
        PALADIN,
        SHAMAN,
    }

    public enum MainStatBonuses
    {
        STRENGTH,
        STAMINA,
        SPIRIT,
        INTELLECT
    }

    public enum SecondStatBonuses
    {
        STRENGTH,
        STAMINA,
        SPIRIT,
        INTELLECT
    }

    public enum BonusStatBonuses
    {
        OVERPOWER,
        LUCK,
        MASTERY,
        CHARISMA
    }

    public CharacterClasses     CharacterClass  { get; set; }
    public MainStatBonuses      MainStat        { get; set; }
    public SecondStatBonuses    SecondMainStat  { get; set; }
    public BonusStatBonuses     BonusStat       { get; set; }
    public List<BaseAbility>    PlayersSkills   = new List<BaseAbility>();
    public List<BaseAbility>    PlayerMagic     = new List<BaseAbility>();

    public string CharacterClassName
    {
        get { return _characterClassName;}
        set { _characterClassName = value;}
    }
    public string CharacterClassDescription
    {
        get { return _characterClassDescription;}
        set { _characterClassDescription = value;}
    }
    public int Strength
    {
        get { return _strength; }
        set { _strength = value; }
    }
    public int Stamina
    {
        get { return _stamina; }
        set { _stamina = value; }
    }
    public int Spirit
    {
        get { return _spirit; }
        set { _spirit = value; }
    }
    public int Intellect
    {
        get {return _intellect;}
        set { _intellect = value; }
    }
    public int Armor
    {
        get { return _armor; }
        set {_armor = value ;}
    }
    public int Overpower
    {
        get { return _overpower; }
        set { _overpower = value; }
    }
    public int Luck
    {
        get { return _luck;}
        set { _luck = value; }
    }
    public int Mastery
    {
        get { return _mastery; }
        set { _mastery = value; }
    }
    public int Charisma
    {
        get { return _charisma; }
        set { _charisma = value; }
    }
}
