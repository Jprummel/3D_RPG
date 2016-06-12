using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {

    private BaseWeapon _newWeapon;

    void Start()
    {
        CreateWeapon();
        Debug.Log(_newWeapon.ItemName);
        Debug.Log(_newWeapon.ItemDescription);
        Debug.Log(_newWeapon.ItemID.ToString());
        Debug.Log(_newWeapon.WeaponType.ToString());
        Debug.Log(_newWeapon.Stamina.ToString() + "Stamina");
        Debug.Log(_newWeapon.Strength.ToString() + "Strength");
        Debug.Log(_newWeapon.Endurance.ToString() + "Endurance");
        Debug.Log(_newWeapon.Intellect.ToString() + "Intellect");
    }

    public void CreateWeapon()
    {
        _newWeapon = new BaseWeapon();
        
        //assign name
        _newWeapon.ItemName = "W" + Random.Range(1,101);
        //create description
        _newWeapon.ItemDescription = "This is a new weapon"; 
        //weapon id
        _newWeapon.ItemID = Random.Range(1, 101);
        //stats
        _newWeapon.Strength  = Random.Range(1, 11);
        _newWeapon.Stamina   = Random.Range(1, 11);
        _newWeapon.Endurance = Random.Range(1, 11);
        _newWeapon.Intellect = Random.Range(1, 11);
        //choose type
        ChooseWeaponType();
        //spell effect id
        _newWeapon.SpellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        int randomTemp = Random.Range(1, 8);
        switch (randomTemp)
        {
            case 1:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
                break;
            case 2:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.STAFF;
                break;
            case 3:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.SPEAR;
                break;
            case 4:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
                break;
            case 5:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
                break;
            case 6:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.AXE;
                break;
            case 7:
                _newWeapon.WeaponType = BaseWeapon.WeaponTypes.BOW;
                break;
        }        
    }
}
