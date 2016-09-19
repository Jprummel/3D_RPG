using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseTrollRace : BaseCharacterRace {

	public BaseTrollRace()
    {
        new BaseCharacterRace();
        RaceName            = "Troll";
        RaceDescription     = "Trolls have been living with their own kind seperated from other races for a long time. "+
                              "They are discriminated against by most of the other races because of the great war 300 years ago when the Trolls lived like savage beasts. " +
                              "a lot has changed since then but they don't get the chance to show that they are not the same kind of trolls that their ancestors were.";
        HasStrengthBonus    = true;
        HasStaminaBonus     = true;
        HasOverpowerBonus   = true;
    }
}
