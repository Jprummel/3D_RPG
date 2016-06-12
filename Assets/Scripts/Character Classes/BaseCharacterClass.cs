using UnityEngine;
using System.Collections;

public class BaseCharacterClass{

    private string _characterClassName;
    private string _characterClassDescription;
    //Stats
    private int _strength;
    private int _stamina;
    private int _endurance;
    private int _intellect;
    private int _agility;
    private int _resistance;

    public string CharacterClassName        { get; set; }
    public string CharacterClassDescription { get; set; }
    public int Strength                     { get; set; }
    public int Stamina                      { get; set; }
    public int Endurance                    { get; set; }
    public int Intellect                    { get; set; }
    public int Agility                      { get; set; }
    public int Resistance                   { get; set; }
}
