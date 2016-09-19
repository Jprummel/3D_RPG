using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseDarkElfRace : BaseCharacterRace {

	public BaseDarkElfRace()
    {
        new BaseCharacterRace();
        RaceName            = "Dark Elf";
        RaceDescription     = "Centuries ago elf's who got corrupted by foul magic turned into dark elfs they went on a rampage killing all that stood in their path " +
                              "Dark elfs from this time however live a more peacefull live but they get discriminated against because of what their ancestors did.";
        HasStrengthBonus    = true;
        HasIntellectBonus   = true;
        HasMasteryBonus     = true;
    }
}
