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
        Debug.Log("Endurance "      + GameInformation.Endurance);
        Debug.Log("Intellect "      + GameInformation.Intellect);
        Debug.Log("Agility "        + GameInformation.Agility);
        Debug.Log("Resistance "     + GameInformation.Resistance);
        Debug.Log("Gold "           + GameInformation.Gold);        
	}
}
