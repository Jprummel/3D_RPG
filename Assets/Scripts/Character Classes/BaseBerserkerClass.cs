using UnityEngine;
using System.Collections;

public class BaseBerserkerClass : BaseCharacterClass {

	public BaseBerserkerClass()
    {
        CharacterClassName = "Berserker";
        CharacterClassDescription = "A warrior that thrives in the thrill of battle, prefers offense above defense";
        Strength = 18;
        Stamina = 11;
        Endurance = 11;
        Intellect = 10;
    }
}
