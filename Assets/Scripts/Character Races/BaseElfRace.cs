using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseElfRace : BaseCharacterRace {

	public BaseElfRace()
    {
        new BaseCharacterRace();
        RaceName            = "Elf";
        RaceDescription     = "Long ago the Elfs used to be forest dwellers but nowadays you can see them everywhere. "+
                              "They have adapted to the diffent livestyles found across the world while maintaining their own elvish lifestyle too.";
        HasStrengthBonus    = true;
        HasMasteryBonus     = true;
        HasCharismaBonus    = true;
    }
}
