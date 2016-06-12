using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStatItem :BaseItem {

    private int _strength;
    private int _stamina;
    private int _endurance;
    private int _intellect;

    public int Strength     { get; set; }
    public int Stamina      { get; set; }
    public int Endurance    { get; set; }
    public int Intellect    { get; set; }
}
