using UnityEngine;
using System.Collections;

public class BaseDwarfRace : BaseCharacterRace {

    public BaseDwarfRace()
    {
        new BaseCharacterRace();
        RaceName            = "Dwarf";
        RaceDescription =   "The dwarven folk are skilled crafters and are a force to be reckoned with when they work together with others. " + 
                            "They have been living together with the Gnomes for over a century now in the city of (insert name)";
        HasStrengthBonus    = true;
        HasStaminaBonus     = true;
        HasMasteryBonus     = true;
    }
}
