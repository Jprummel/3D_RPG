using System.Collections.Generic;
[System.Serializable]

public class BaseAbility {

    private string                  _abilityName;
    private string                  _abilityDescription;
    private int                     _abilityID;
    private int                     _abilityPower;                                          //Damage done by ability
    private int                     _abilityCost;                                           //Cost to use ability
    private BaseStatusEffect        _abilityStatusEffect;                                   // Allows each ability to have 1 status effect
    private List<BaseStatusEffect>  _abilityStatusEffects = new List<BaseStatusEffect>();   //Allows each ability to have multiple status effects
    private int _abilityCritChance;
    private float _abilityCritModifier;
    private int _abilityHitChance;
    private int _abilityDamageToSelf;

    public enum AbilityTypes
    {
        PHYSICAL,
        MAGICAL,
        HYBRID
    }

    public AbilityTypes AbilityType { get; set; }

    public string AbilityName
    {
        get { return _abilityName; }
        set { _abilityName = value; }
    }

    public string AbilityDescription
    {
        get { return _abilityDescription; }
        set { _abilityDescription = value; }
    }

    public int AbilityID
    {
        get { return _abilityID; }
        set { _abilityID = value; }
    }

    public int AbilityBaseDamage { get; set; }
    public float AbilityDamageStatModifier { get; set; }

    public int AbilityPower
    {
        get { return _abilityPower; }
        set { _abilityPower = value; }
    }

    public int AbilityCost
    {
        get { return _abilityCost; }
        set { _abilityCost = value; }
    }

    public BaseStatusEffect AbilityStatusEffect
    {
        get { return _abilityStatusEffect; }
        set { _abilityStatusEffect = value;}
    }

    public List<BaseStatusEffect> AbilityStatusEffects
    {
        get { return _abilityStatusEffects; }
        set { _abilityStatusEffects = value;}
    }

    public int AbilityCritChance
    {
        get { return _abilityCritChance;    }
        set { _abilityCritChance = value;   }
    }

    public float AbilityCritModifier
    {
        get { return _abilityCritModifier;  }
        set { _abilityCritModifier = value; }
    }

    public int AbilityHitChance
    {
        get { return _abilityHitChance;    }
        set { _abilityHitChance = value;   }
    }

    public int AbilityDamageToSelf
    {
        get { return _abilityDamageToSelf;  }
        set { _abilityDamageToSelf = value; }
    }
}
