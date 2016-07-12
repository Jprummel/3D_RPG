using UnityEngine;
using System.Collections;

public class BaseBarbarianRace : BaseCharacterRace {

	public BaseBarbarianRace()
    {
        new BaseCharacterRace();
        RaceName            = "Barbarian";
        RaceDescription     = "Strong, Tough and wild the Barbarians have been living in the north in solitude none but the most courageous of adventurers dare to enter their territory.";
        HasStrengthBonus    = true;
        HasStaminaBonus     = true;
        HasSpiritBonus   = true;
    }
}
