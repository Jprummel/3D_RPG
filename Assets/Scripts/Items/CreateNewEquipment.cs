using UnityEngine;
using System.Collections;

public class CreateNewEquipment : MonoBehaviour
{

    private BaseEquipment _newEquipment;
    private string[] _itemNames = new string[5] { "Common", "Great", "Amazing", "Insane", "Epic" };
    private string[] _itemDescription = new string[2] { "A new cool item", "A new Awesome Item" };

    void Start()
    {
        CreateEquipment();
        Debug.Log(_newEquipment.ItemName);
        Debug.Log(_newEquipment.ItemDescription);
        Debug.Log(_newEquipment.ItemID.ToString());
        Debug.Log(_newEquipment.EquipmentType.ToString());
        Debug.Log(_newEquipment.Stamina.ToString() + "Stamina");
        Debug.Log(_newEquipment.Strength.ToString() + "Strength");
        Debug.Log(_newEquipment.Endurance.ToString() + "Endurance");
        Debug.Log(_newEquipment.Intellect.ToString() + "Intellect");
    }

    private void CreateEquipment()
    {
        _newEquipment = new BaseEquipment();
        _newEquipment.ItemName  = _itemNames[Random.Range(0, _itemNames.Length)] + "Item";
        _newEquipment.ItemID    = Random.Range(1, 101);
        ChooseItemType();
        _newEquipment.ItemDescription = _itemDescription[Random.Range(0, _itemDescription.Length)];
        _newEquipment.Strength  = Random.Range(1, 11);
        _newEquipment.Stamina   = Random.Range(1, 11);
        _newEquipment.Endurance = Random.Range(1, 11);
        _newEquipment.Intellect = Random.Range(1, 11);
    }

    private void ChooseItemType()
    {
        int randomTemp = Random.Range(1, 9);
        switch (randomTemp)
        {
            case 1:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
                break;
            case 2:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.SHOULDERS;
                break;
            case 3:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
                break;
            case 4:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
                break;
            case 5:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
                break;
            case 6:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.NECK;
                break;
            case 7:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.EARRING;
                break;
            case 8:
                _newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.RING;
                break;
        }
    }
}
