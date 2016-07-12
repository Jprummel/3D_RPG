using UnityEngine;
using System.Collections;

public class BaseShamanClass : BaseCharacterClass {

    public BaseShamanClass()
    {
        CharacterClassName          = "Shaman";
        CharacterClassDescription   = "Shaman are very spiritual people in touch with their ancestors and the elements they are a supportive pillar for their allies";
        MainStat        = MainStatBonuses.SPIRIT;
        SecondMainStat  = SecondStatBonuses.INTELLECT;
        BonusStat       = BonusStatBonuses.MASTERY;
        CharacterClass  = CharacterClasses.SHAMAN;
    }
}
