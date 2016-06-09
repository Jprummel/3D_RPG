using UnityEngine;
using System.Collections;

public class BaseEquipment : BaseStatItem {

	public enum EquipmentTypes{
		HEAD,
		CHEST,
		SHOULDERS,
		LEGS,
		FEET,
		NECK,
		EARRING,
		RING,	
	}

	private EquipmentTypes _equipmentType;
    private int _spellEffectID;

	public EquipmentTypes EquipmentType
    {
        get { return _equipmentType; }
        set { _equipmentType = value; }
	}

    public int SpellEffectID
    {
        get { return _spellEffectID; }
        set { _spellEffectID = value; }
    }
}
