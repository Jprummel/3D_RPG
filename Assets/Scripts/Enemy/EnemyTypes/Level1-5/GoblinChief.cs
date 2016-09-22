using UnityEngine;
using System.Collections;

public class GoblinChief : BaseEnemy {

	public GoblinChief()
    {
        EnemyName           = "Goblin Chief";
        EnemyDescription    = "A goblin chieftain of a small tribe";
        EnemyLevel          = 4;
        Strength            = 12;
        Stamina             = 12;
        Spirit              = 9;
        Intellect           = 6;
        Armor               = 2;
        Overpower           = 8;
        Luck                = 12;
        Mastery             = 9;
        Charisma            = 3;
    }
}
