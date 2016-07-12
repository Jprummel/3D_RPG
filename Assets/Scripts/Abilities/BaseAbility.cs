[System.Serializable]
public class BaseAbility {

    private string  _abilityName;
    private string  _abilityDescription;
    private int     _abilityID;
    private int     _abilityPower;
    private int     _abilityCost;

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

}
