using UnityEngine;
using System.Collections;

public class BaseShadowknightClass : BaseCharacterClass {

    public BaseShadowknightClass()
    {
        CharacterClassName          = "Shadowknight";
        CharacterClassDescription   = "A warrior that brings death and darkness to his enemies, a shadowknight uses black magic to enhance his combat potential";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.OVERPOWER;
        CharacterClass  = CharacterClasses.SHADOWKNIGHT;
    }
}
