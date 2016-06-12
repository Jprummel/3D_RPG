using UnityEngine;
using System.Collections;

public class BaseWarriorClass : BaseCharacterClass {

    public BaseWarriorClass()
    {
        CharacterClassName          = "Warrior";
        CharacterClassDescription   = "A real powerhouse, feared by many and a great inspiration to his allies";
        Strength    = 15;
        Stamina     = 12;
        Endurance   = 14;
        Intellect   = 10;
        Agility     = 13;
        Resistance  = 15;
    }
}
