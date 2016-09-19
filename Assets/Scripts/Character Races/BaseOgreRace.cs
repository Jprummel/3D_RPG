using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseOgreRace : BaseCharacterRace {
 
    public BaseOgreRace()
    {
        new BaseCharacterRace();
        RaceName            = "Ogre";
        RaceDescription     = "";
        HasStrengthBonus    = true;
        HasSpiritBonus      = true;
        HasLuckBonus        = true;
    }
}
