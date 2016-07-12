using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

    private BasePotion _newPotion;

	// Use this for initialization
	void Start () {
        CreatePotion();
        Debug.Log(_newPotion.ItemName);
        Debug.Log(_newPotion.ItemDescription);
        Debug.Log(_newPotion.ItemID);
        Debug.Log(_newPotion.PotionType);
	}

    private void CreatePotion()
    {
        _newPotion                  = new BasePotion();
        _newPotion.ItemName         = "Potion";
        _newPotion.ItemDescription  = "This is a potion";
        _newPotion.ItemID           = Random.Range(1, 101);
        ChoosePotionType();
    }

    private void ChoosePotionType()
    {
        System.Array potions = System.Enum.GetValues(typeof(BasePotion.PotionTypes));
        _newPotion.PotionType = (BasePotion.PotionTypes)potions.GetValue(Random.Range(0, potions.Length));
    }

}
