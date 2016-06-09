using UnityEngine;
using System.Collections;

public class BaseStatItem :BaseItem {

    private int _strength;
    private int _stamina;
    private int _endurance;
    private int _intellect;

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
