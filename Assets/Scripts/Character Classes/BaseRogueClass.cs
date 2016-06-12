using UnityEngine;
using System.Collections;

public class BaseRogueClass : BaseCharacterClass {

	public BaseRogueClass()
    {
        CharacterClassName          = "Rogue";
        CharacterClassDescription   = "A stealthy assassin skilled with daggers and shortswords";
        Strength    = 15;
        Stamina     = 10;
        Endurance   = 10;
        Intellect   = 12;
        Agility     = 15;
        Resistance  = 10;
    }
}
