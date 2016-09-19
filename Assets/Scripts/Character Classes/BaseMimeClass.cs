using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseMimeClass : BaseCharacterClass {

	public BaseMimeClass()
    {
        CharacterClassName          = "Mime";
        CharacterClassDescription   = "A french retard";
        MainStat        = MainStatBonuses.SPIRIT;
        SecondMainStat  = SecondStatBonuses.INTELLECT;
        BonusStat       = BonusStatBonuses.CHARISMA;
        CharacterClass  = CharacterClasses.MIME;
    }
}
