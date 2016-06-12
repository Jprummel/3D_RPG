using UnityEngine;
using System.Collections;

public class BasePotion : BaseStatItem {

    public enum PotionTypes
    {
        HEALTH,
        ENERGY,
        STRENGTH,
        INTELLECT,
        ENDURANCE,
        STAMINA,
        SPEED
    }

    private PotionTypes _potionType;
    private int _spellEffectID;

    public PotionTypes PotionType   { get; set; }
    public int SpellEffectID        { get; set; }
}
