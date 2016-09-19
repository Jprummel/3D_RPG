using UnityEngine;
using System.Collections;

public class Goblin : BaseEnemy {

    public Goblin()
    {
        EnemyName           = "Goblin";
        EnemyDescription    = "A small and weak goblin";
        EnemyLevel          = 2;
        Strength            = 8;
        Stamina             = 10;
        Spirit              = 8;
        Intellect           = 4;
        Armor               = 2;
        Overpower           = 6;
        Luck                = 7;
        Mastery             = 5;
        Charisma            = 1;
    }
}
