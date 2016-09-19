using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseCharacterRace {

    private string  _raceName           = "Needs a name";
    private string  _raceDescription    = "Needs a Description";

    public string RaceName
    {
        get { return _raceName; }
        set { _raceName = value; }
    }

    public string RaceDescription
    {
        get;
        set;
    }

    public bool HasStrengthBonus    { get; set; }
    public bool HasStaminaBonus     { get; set; }
    public bool HasSpiritBonus      { get; set; }
    public bool HasIntellectBonus   { get; set; }
    public bool HasOverpowerBonus   { get; set; }
    public bool HasLuckBonus        { get; set; }
    public bool HasMasteryBonus     { get; set; }
    public bool HasCharismaBonus    { get; set; }

}
