using UnityEngine;
using System.Collections;

public class BasePlayer{

    //Player data/info
    private string              _playerName;
    private int                 _playerLevel;
    private BaseCharacterClass  _playerClass;
    //Stats
    private int _strength;      //Physical damage modifier
    private int _stamina;       //Health modifier
    private int _spirit;        //Resource (Mana,Rage etc) Modifier
    private int _intellect;     //Spell damage modifier
    private int _armor;         //Damage reduction
    private int _overpower;     //Critical strike chance
    private int _luck;          //Extra/better loot chance
    private int _mastery;       //Chance for bonus damage
    private int _charisma;      //Lower buy prices , increase sell prices, bonus rep , influence on how people see you
    //Experience & currency
    private int _currentXP;
    private int _requiredXP;
    private int _statPointsToAllocate;
    private int _gold;

    public string   PlayerName              { get; set; }
    public int      PlayerLevel             { get; set; }
    public BaseCharacterClass PlayerClass   { get; set; }
    public int Strength                     { get; set; }
    public int Stamina                      { get; set; }
    public int Spirit                       { get; set; }
    public int Intellect                    { get; set; }
    public int Armor                        { get; set; }
    public int Overpower                    { get; set; }
    public int Luck                         { get; set; }
    public int Mastery                      { get; set; }
    public int Charisma                     { get; set; }
    public int CurrentXP                    { get; set; }
    public int RequiredXP                   { get; set; }
    public int StatPointsToAllocate         { get; set; }
    public int Gold                         { get; set; }
}
