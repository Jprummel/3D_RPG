using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseSkeletonRace : BaseCharacterRace {
    
    public BaseSkeletonRace()
    {
        new BaseCharacterRace();
        RaceName            = "Skeleton";
        RaceDescription     = "";
        HasIntellectBonus   = true;
        HasLuckBonus        = true;
        HasCharismaBonus    = true;
    }
}
