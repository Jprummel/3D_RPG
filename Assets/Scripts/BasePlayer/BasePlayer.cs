using UnityEngine;
using System.Collections;

public class BasePlayer{

    private string              _playerName;
    private int                 _playerLevel;
    private BaseCharacterClass  _playerClass;
    private int _strength;
    private int _stamina;
    private int _endurance;
    private int _intellect;

    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }
    public int PlayerLevel
    {
        get { return _playerLevel; }
        set { _playerLevel = value; }
    }
    public BaseCharacterClass PlayerClass
    {
        get { return _playerClass; }
        set { _playerClass = value; }
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
    public int Endurance
    {
        get { return _endurance; }
        set { _endurance = value; }
    }
    public int Intellect
    {
        get { return _intellect; }
        set { _intellect = value; }
    }
}
