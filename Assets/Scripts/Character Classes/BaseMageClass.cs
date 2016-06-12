using UnityEngine;
using System.Collections;

public class BaseMageClass : BaseCharacterClass {

    public BaseMageClass()
    {
        CharacterClassName          = "Mage";
        CharacterClassDescription   = "A powerful mage who can control arcane and elemental powers";
        Strength    = 10;
        Stamina     = 14;
        Endurance   = 10;
        Intellect   = 15;
        Agility     = 8;
        Resistance  = 12;
    }
}
