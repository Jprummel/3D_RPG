using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseGnomeRace : BaseCharacterRace {

	public BaseGnomeRace()
    {
        new BaseCharacterRace();
        RaceName            = "Gnome";
        RaceDescription     = "The Gnomes have been living together with the Dwarves for over a century now in the city of (insert name). " +
                              "Just like the Dwarves, Gnomes possess great intellect and love to invent new things, "+ 
                              "however where Dwarves prefer to create more technology based on combat Gnomes create technology for everything you can think of from combat use to everyday household items";
        HasIntellectBonus   = true;
        HasLuckBonus        = true;
        HasCharismaBonus    = true;
    }
}
