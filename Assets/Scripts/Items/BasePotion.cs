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

    public PotionTypes PotionType
    {
        get { return _potionType; }
        set { _potionType = value; }
    }

    public int SpellEffectID
    {
        get { return _spellEffectID; }
        set { _spellEffectID = value; }
    }
}
