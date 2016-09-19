using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseGolemRace : BaseCharacterRace {

	public BaseGolemRace()
    {
        new BaseCharacterRace();
        RaceName            = "Golem";
        RaceDescription     = "Golems come in many forms and shapes";
        HasStrengthBonus    = true;
        HasIntellectBonus   = true;
        HasCharismaBonus    = true;
    }
}
