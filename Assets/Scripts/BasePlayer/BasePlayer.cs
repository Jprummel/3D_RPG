using UnityEngine;
using System.Collections;

public class BasePlayer{

    //Player data/info
    private string              _playerName;
    private int                 _playerLevel;
    private BaseCharacterClass  _playerClass;
    //Stats
    private int _strength;  //physical dmg
    private int _stamina;   //Health modifier
    private int _endurance; //Energy modifier
    private int _intellect; //Magic dmg modifier
    private int _agility;   //haste & crit modifier
    private int _resistance;//all dmg reduction
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
    public int Endurance                    { get; set; }
    public int Intellect                    { get; set; }
    public int Agility                      { get; set; }
    public int Resistance                   { get; set; }
    public int CurrentXP                    { get; set; }
    public int RequiredXP                   { get; set; }
    public int StatPointsToAllocate         { get; set; }
    public int Gold                         { get; set; }
}
