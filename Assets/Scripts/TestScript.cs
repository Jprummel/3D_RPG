using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadInformation.LoadAllInformation();
        Debug.Log("Player Name : "  + GameInformation.PlayerName);
        Debug.Log("Player Level : " + GameInformation.PlayerLevel);
        Debug.Log("Strength "       + GameInformation.Strength);
        Debug.Log("Stamina "        + GameInformation.Stamina);
        Debug.Log("Spirit "      + GameInformation.Spirit);
        Debug.Log("Intellect "      + GameInformation.Intellect);
        Debug.Log("Overpower "        + GameInformation.Overpower);
        Debug.Log("Luck "     + GameInformation.Luck);
        Debug.Log("Gold "           + GameInformation.Gold);        
	}
}
