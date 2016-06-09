using UnityEngine;
using System.Collections;

public class BaseRogueClass : BaseCharacterClass {

	public BaseRogueClass()
    {
        CharacterClassName = "Rogue";
        CharacterClassDescription = "A stealthy assassin skilled with daggers and shortswords";
        Strength = 15;
        Stamina = 15;
        Endurance = 8;
        Intellect = 12;
    }
}
