using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseBerserkerClass : BaseCharacterClass {

	public BaseBerserkerClass()
    {
        CharacterClassName          = "Berserker";
        CharacterClassDescription   = "A warrior that thrives in the thrill of battle, prefers offense above defense";
        MainStat        = MainStatBonuses.STRENGTH;
        SecondMainStat  = SecondStatBonuses.SPIRIT;
        BonusStat       = BonusStatBonuses.MASTERY;
        CharacterClass  = CharacterClasses.BERSERKER;

        PlayersSkills.Add(new AttackAbility());
        PlayersSkills.Add(new SwordSlash());
        PlayersSkills.Add(new Cripple());
        PlayersSkills.Add(new Rampage());
    }
}
