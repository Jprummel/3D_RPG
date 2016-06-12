using UnityEngine;
using System.Collections;

public class BaseNecromancerClass : BaseCharacterClass {

	public BaseNecromancerClass()
    {
        CharacterClassName          = "Necromancer";
        CharacterClassDescription   = "A mage who turned to the dark arts, kills his enemies and then raises them to fight along side him";
        Strength    = 10;
        Stamina     = 14;
        Endurance   = 11;
        Intellect   = 15;
        Agility     = 9;
        Resistance  = 9;
    }
}
