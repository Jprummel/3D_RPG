using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseRogueClass : BaseCharacterClass {

	public BaseRogueClass()
    {
        CharacterClassName          = "Rogue";
        CharacterClassDescription   = "A stealthy assassin skilled with daggers and shortswords";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.OVERPOWER;
        CharacterClass  = CharacterClasses.ROGUE;
    }
}
