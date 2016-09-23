using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseMimeClass : BaseCharacterClass {

	public BaseMimeClass()
    {
        CharactersClassName          = "Mime";
        CharactersClassDescription   = "A french retard";
        MainStat        = MainStatBonuses.SPIRIT;
        SecondMainStat  = SecondStatBonuses.INTELLECT;
        BonusStat       = BonusStatBonuses.CHARISMA;
        CharactersClass  = CharactersClasses.MIME;
    }
}
