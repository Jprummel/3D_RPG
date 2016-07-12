using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseEquipment : BaseItem {

	public enum EquipmentTypes{
		HEAD,
		CHEST,
		SHOULDERS,
        HANDS,
		LEGS,
		FEET,
		NECK,
		EARRING,
		RING,	
	}

	private EquipmentTypes  _equipmentType;
    private int             _spellEffectID;

	public EquipmentTypes EquipmentType { get; set; }
    public int SpellEffectID            { get; set; }
}
