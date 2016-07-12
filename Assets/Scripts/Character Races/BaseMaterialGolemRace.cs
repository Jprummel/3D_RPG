using UnityEngine;
using System.Collections;

public class BaseMaterialGolemRace : BaseCharacterRace {

	public BaseMaterialGolemRace()
    {
        new BaseCharacterRace();
        RaceName            = "Material Golem";
        RaceDescription     = "Material Golems have a skin made out of various materials like dirt , sand , iron and anything else you can think of";
        HasStrengthBonus    = true;
        HasIntellectBonus   = true;
        HasCharismaBonus    = true;
    }
}
