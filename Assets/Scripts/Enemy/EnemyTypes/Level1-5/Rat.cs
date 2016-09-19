using UnityEngine;
using System.Collections;

public class Rat : BaseEnemy{

    public Rat()
    {
        EnemyName           = "Rat";
        EnemyDescription    = "An overgrown gutter rat ";
        EnemyLevel          = 1;
        Strength            = 6;
        Stamina             = 9;
        Spirit              = 8;
        Intellect           = 1;
        Armor               = 0;
        Overpower           = 3;
        Luck                = 5;
        Mastery             = 5;
        Charisma            = 2;
    }
}
