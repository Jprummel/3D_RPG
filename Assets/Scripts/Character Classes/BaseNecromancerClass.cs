using UnityEngine;
using System.Collections;

public class BaseNecromancerClass : BaseCharacterClass {

	public BaseNecromancerClass()
    {
        CharacterClassName          = "Necromancer";
        CharacterClassDescription   = "Necromancers are mages who use the dark forbidden arts they kill their enemies and then raise them from the dead to fight alongside them.";
        MainStat        = MainStatBonuses.INTELLECT;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.LUCK;
        CharacterClass  = CharacterClasses.NECROMANCER;
    }
}
