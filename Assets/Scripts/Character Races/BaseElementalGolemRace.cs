using UnityEngine;
using System.Collections;

public class BaseElementalGolemRace : BaseCharacterRace {

	public BaseElementalGolemRace()
    {
        new BaseCharacterRace();
        RaceName            = "Elemental Golem";
        RaceDescription     = "These just kick ass man";
        HasStrengthBonus    = true;
        HasIntellectBonus   = true;
        HasCharismaBonus    = true;
    }
}
