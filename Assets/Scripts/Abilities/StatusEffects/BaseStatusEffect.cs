using UnityEngine;
using System.Collections;
[System.Serializable]
public class BaseStatusEffect{

    private string  _statusEffectName;
    private string  _statusEffectDescription;
    private int     _statusEffectID;
    private int     _statusEffectPower;
    private int     _statusEffectApplyPercentage;
    private int     _statusEffectStayAppliedPercentage;
    private int     _statusEffectMinTurnApplied;
    private int     _statusEffectMaxTurnApplied;

    public string StatusEffectName
    {
        get { return _statusEffectName;     }
        set { _statusEffectName = value;    }
    }

    public string StatusEffectDescription
    {
        get { return _statusEffectDescription;  }
        set { _statusEffectDescription = value; }
    }

    public int StatusEffectID
    {
        get { return _statusEffectID;   }
        set { _statusEffectID = value;  }
    }

    public int StatusEffectPower
    {
        get { return _statusEffectPower;    }
        set { _statusEffectPower = value;   }
    }

    public int StatusEffectApplyPercentage
    {
        get { return _statusEffectApplyPercentage;  }
        set { _statusEffectApplyPercentage = value; }
    }

    public int StatusEffectStayAppliedPercentage
    {
        get { return _statusEffectStayAppliedPercentage;    }
        set { _statusEffectStayAppliedPercentage = value;   }
    }

    public int StatusEffectMinTurnApplied
    {
        get { return _statusEffectApplyPercentage; }
        set { _statusEffectMinTurnApplied = value; }
    }

    public int StatusEffectMaxTurnApplied
    {
        get { return _statusEffectMaxTurnApplied;   }
        set { _statusEffectMaxTurnApplied = value;  }
    }    
}
