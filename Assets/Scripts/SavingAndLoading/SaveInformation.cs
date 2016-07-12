using UnityEngine;
using System.Collections;

public class SaveInformation{

    public static void SaveAllInformation()
    {
        PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
        PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
        PlayerPrefs.SetInt("STRENGTH", GameInformation.Strength);
        PlayerPrefs.SetInt("STAMINA", GameInformation.Stamina);
        PlayerPrefs.SetInt("Spirit", GameInformation.Spirit);
        PlayerPrefs.SetInt("INTELLECT", GameInformation.Intellect);
        PlayerPrefs.SetInt("Overpower", GameInformation.Overpower);
        PlayerPrefs.SetInt("Luck", GameInformation.Luck);
        PlayerPrefs.SetInt("GOLD", GameInformation.Gold);


        if (GameInformation.EquipmentOne != null)
        {
            PPSerialization.Save("EQUIPMENTITEM1", GameInformation.EquipmentOne);
        }

        Debug.Log("Saved all information");
    }
}
