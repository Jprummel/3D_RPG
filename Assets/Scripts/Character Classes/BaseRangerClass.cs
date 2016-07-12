using UnityEngine;
using System.Collections;

public class BaseRangerClass : BaseCharacterClass {

    public BaseRangerClass()
    {
        CharacterClassName          = "Ranger";
        CharacterClassDescription   = "Rangers are versatile with weapons but most prefer to have both a bow and a shortsword. What they lack in the defensive compartment they make up for in the offensive one";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.INTELLECT;
        BonusStat       = BonusStatBonuses.MASTERY;
        CharacterClass  = CharacterClasses.RANGER;
    }
}
