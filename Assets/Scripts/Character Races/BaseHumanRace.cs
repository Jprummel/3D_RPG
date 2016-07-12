using UnityEngine;
using System.Collections;

public class BaseHumanRace : BaseCharacterRace {

    public BaseHumanRace()
    {
        new BaseCharacterRace();
        RaceName            = "Human";
        RaceDescription     = "You fucking normie, are you seriously going to pick a filthy hooman?";
        HasStrengthBonus    = true;
        HasIntellectBonus   = true;
        HasCharismaBonus    = true;
    }
}
