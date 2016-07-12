using UnityEngine;
using System.Collections;

public class BaseAlchemistClass : BaseCharacterClass {

	public BaseAlchemistClass()
    {
        CharacterClassName          = "Alchemist";
        CharacterClassDescription   = "A warrior that thrives in the thrill of battle, prefers offense above defense";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.INTELLECT;
        BonusStat       = BonusStatBonuses.LUCK;
    }
}
