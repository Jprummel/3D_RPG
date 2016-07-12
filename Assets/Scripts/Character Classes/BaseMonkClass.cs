using UnityEngine;
using System.Collections;

public class BaseMonkClass : BaseCharacterClass {

    public BaseMonkClass()
    {
        CharacterClassName          = "Monk";
        CharacterClassDescription   = "";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.STAMINA;
        BonusStat       = BonusStatBonuses.MASTERY;
        CharacterClass  = CharacterClasses.MONK;
    }
}
