using UnityEngine;
using System.Collections;

public class BaseDruidClass : BaseCharacterClass {

	public BaseDruidClass()
    {
        CharacterClassName          = "Druid";
        CharacterClassDescription   = "";
        MainStat        = MainStatBonuses.STAMINA;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.CHARISMA;
        CharacterClass  = CharacterClasses.DRUID;
    }
}
