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

    public string CharacterClassName
    {
        get { return _characterClassName;  }
        set { _characterClassName = value; }
    }

    public string CharacterClassDescription
    {
        get { return _characterClassDescription; }
        set { _characterClassDescription = value; }
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
