using UnityEngine;
using System.Collections;

public class BaseWeapon : BaseStatItem {

    public enum WeaponTypes
    {
        SWORD,
        STAFF,
        DAGGER,
        BOW,
        AXE,
        SPEAR,
        SHIELD
    }

    private WeaponTypes _weaponType;
    private int _spellEffectID;

    public WeaponTypes WeaponType
    {
        get { return _weaponType; }
        set { _weaponType = value; }
    }

    public int SpellEffectID
    {
        get { return _spellEffectID; }
        set { _spellEffectID = value; }
    }

}
