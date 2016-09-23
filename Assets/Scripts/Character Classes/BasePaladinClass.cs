using UnityEngine;
using System.Collections;
[System.Serializable]
public class BasePaladinClass : BaseCharacterClass {

	public BasePaladinClass()
    {
        CharactersClassName          = "Paladin";
        CharactersClassDescription   = "Paladins are loyal friends and warriors of light. They shield and heal allies with white magic while fighting on the frontlines";
        MainStat        = MainStatBonuses.STAMINA;
        SecondMainStat  = SecondStatBonuses.INTELLECT;
        BonusStat       = BonusStatBonuses.CHARISMA;
        CharactersClass  = CharactersClasses.PALADIN;
    }
}
