using UnityEngine;
using System.Collections;

public class BaseWeapon : BaseItem {

    public enum WeaponTypes
    {
        SWORD,
        STAFF,
        DAGGER,
        BOW,
        AXE,
        SPEAR,
        OFFHAND
    }

    private WeaponTypes _weaponType;
    private int _spellEffectID;

    public WeaponTypes WeaponType   { get; set; }
    public int SpellEffectID        { get; set; }

}
