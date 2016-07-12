using UnityEngine;
using System.Collections;

public class BasePotion : BaseItem {

    public enum PotionTypes
    {
        HEALTH,
        ENERGY,
        STRENGTH,
        INTELLECT,
        SPIRIT,
        STAMINA,
        SPEED,
        OVERPOWER,
        MASTERY,
        LUCK,
        CHARISMA,
        EXTRAGOLD
    }

    private PotionTypes _potionType;
    private int _spellEffectID;

    public PotionTypes PotionType   { get; set; }
    public int SpellEffectID        { get; set; }
}
