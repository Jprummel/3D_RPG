using UnityEngine;
using System.Collections;

public class BaseDruidClass : BaseCharacterClass {

	public BaseDruidClass()
    {
        CharacterClassName          = "Druid";
        CharacterClassDescription   = "Druids are powerful magic users with a connection to nature";
        MainStat        = MainStatBonuses.STAMINA;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.CHARISMA;
        CharacterClass  = CharacterClasses.DRUID;
    }
}
