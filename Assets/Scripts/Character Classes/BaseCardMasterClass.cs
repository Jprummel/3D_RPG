using UnityEngine;
using System.Collections;

public class BaseCardMasterClass : BaseCharacterClass {

	public BaseCardMasterClass()
    {
        CharacterClassName          = "Card Master";
        CharacterClassDescription   = "A trickster who uses a magical deck of cards to buff his allies and destroy his enemies";
        MainStat        = MainStatBonuses.INTELLECT;
        SecondMainStat  = SecondStatBonuses.STRENGTH;
        BonusStat       = BonusStatBonuses.MASTERY;
    }
}
