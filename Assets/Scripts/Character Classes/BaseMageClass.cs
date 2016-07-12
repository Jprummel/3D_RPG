using UnityEngine;
using System.Collections;

public class BaseMageClass : BaseCharacterClass {

    public BaseMageClass()
    {
        CharacterClassName          = "Mage";
        CharacterClassDescription   = "A powerful mage who can control arcane and elemental powers";
        MainStat        = MainStatBonuses.INTELLECT;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.OVERPOWER;
        CharacterClass  = CharacterClasses.MAGE;
    }
}
