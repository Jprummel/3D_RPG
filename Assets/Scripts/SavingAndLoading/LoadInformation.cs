using UnityEngine;
using System.Collections;

public class LoadInformation{

    public static void LoadAllInformation()
    {
        GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
        GameInformation.Strength = PlayerPrefs.GetInt("STRENGTH");
        GameInformation.Stamina = PlayerPrefs.GetInt("STAMINA");
        GameInformation.Spirit = PlayerPrefs.GetInt("Spirit");
        GameInformation.Intellect = PlayerPrefs.GetInt("INTELLECT");
        GameInformation.Overpower = PlayerPrefs.GetInt("Overpower");
        GameInformation.Luck = PlayerPrefs.GetInt("Luck");
        GameInformation.Gold = PlayerPrefs.GetInt("GOLD");

        if (PlayerPrefs.GetString("EQUIPMENTITEM1") != null)
        {
            GameInformation.EquipmentOne = (BaseEquipment)PPSerialization.Load("EQUIPMENTITEM1");
        }
    }
}
