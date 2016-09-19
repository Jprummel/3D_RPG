using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseWarriorClass : BaseCharacterClass {

    public BaseWarriorClass()
    {
        CharacterClassName          = "Warrior";
        CharacterClassDescription   = "A warrior can always be found on the frontlines defending their allies and inspiring them while destroying the enemy forces";
        MainStat        = MainStatBonuses.STAMINA;
        SecondMainStat  = SecondStatBonuses.STRENGTH;
        BonusStat       = BonusStatBonuses.LUCK;
        CharacterClass  = CharacterClasses.WARRIOR;
        //PlayersAbilities.Add(new AttackAbility());
        //PlayersAbilities.Add(new SwordSlash());
    }
}
