using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseMageClass : BaseCharacterClass {

    public BaseMageClass()
    {
        CharactersClassName          = "Mage";
        CharactersClassDescription   = "A powerful mage who can control arcane and elemental powers";
        MainStat        = MainStatBonuses.INTELLECT;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.OVERPOWER;
        CharactersClass  = CharactersClasses.MAGE;
    }
}
