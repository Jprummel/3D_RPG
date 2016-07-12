using UnityEngine;
using System.Collections;

public class BaseBerserkerClass : BaseCharacterClass {

	public BaseBerserkerClass()
    {
        CharacterClassName          = "Berserker";
        CharacterClassDescription   = "A warrior that thrives in the thrill of battle, prefers offense above defense";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.MASTERY;
    }
}
