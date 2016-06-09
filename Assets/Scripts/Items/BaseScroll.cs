using UnityEngine;
using System.Collections;

public class BaseScroll : BaseItem {

    private int _spellEffectID;

    public int SpellEffectID
    {
        get { return _spellEffectID; }
        set { _spellEffectID = value; }
    }
}
