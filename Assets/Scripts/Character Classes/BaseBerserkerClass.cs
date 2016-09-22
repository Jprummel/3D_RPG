using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseBerserkerClass : BaseCharacterClass {

	public BaseBerserkerClass()
    {
        CharacterClassName          = "Berserker";
        CharacterClassDescription   = "Berserkers don't stop fighting until they are the last man standing or until they die. The more damage has been done to them or their enemy the more damage they will further inflict";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.MASTERY;
        CharacterClass = CharacterClasses.BERSERKER;
    }
}
