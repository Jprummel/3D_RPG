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
        Debug.Log(_newEquipment.Spirit.ToString() + "Spirit");
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
        _newEquipment.Spirit    = Random.Range(1, 11);
        _newEquipment.Intellect = Random.Range(1, 11);
    }

    private void ChooseItemType()
    {
        System.Array equipment = System.Enum.GetValues(typeof(BaseEquipment.EquipmentTypes));
        _newEquipment.EquipmentType = (BaseEquipment.EquipmentTypes)equipment.GetValue(Random.Range(0,equipment.Length));
    }
}
