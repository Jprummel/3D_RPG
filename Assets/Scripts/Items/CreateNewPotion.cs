using UnityEngine;
using System.Collections;

public class CreateNewPotion : MonoBehaviour {

    private BasePotion _newPotion;

	// Use this for initialization
	void Start () {
        CreatePotion();
        Debug.Log(_newPotion.ItemName);
        Debug.Log(_newPotion.ItemDescription);
        Debug.Log(_newPotion.ItemID.ToString());
        Debug.Log(_newPotion.PotionType.ToString());
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
        int randomTemp = Random.Range(0, 7);
        switch (randomTemp)
        {
            case 1:
                _newPotion.PotionType = BasePotion.PotionTypes.HEALTH;
                break;
            case 2:
                _newPotion.PotionType = BasePotion.PotionTypes.ENERGY;
                break;
            case 3:
                _newPotion.PotionType = BasePotion.PotionTypes.ENDURANCE;
                break;
            case 4:
                _newPotion.PotionType = BasePotion.PotionTypes.STRENGTH;
                break;
            case 5:
                _newPotion.PotionType = BasePotion.PotionTypes.SPEED;
                break;
            case 6:
                _newPotion.PotionType = BasePotion.PotionTypes.INTELLECT;
                break;
            case 7:
                _newPotion.PotionType = BasePotion.PotionTypes.STAMINA;
                break;
        }       
    }

}
