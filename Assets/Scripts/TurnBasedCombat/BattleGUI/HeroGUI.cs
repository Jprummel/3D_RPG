using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroGUI : MonoBehaviour 
{
    //This class shows the name, vital stats(HP/MP) and the level of each hero in battle in the GUI

    private Party   _party;
    //Player info
    private Text    _CharactersName;
    private Text    _CharactersHealth;
    private Text    _CharactersMana;
    private Text    _CharactersLevel;

	void Start () 
    {
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();

        //Gets player info components
        //Name
        _CharactersName         = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Name").GetComponent<Text>();
        _CharactersName.text    = _party.characters[0].Name;
        //Vitals
        _CharactersHealth       = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Health").GetComponent<Text>();
        _CharactersMana         = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Mana").GetComponent<Text>();
        //Level
        _CharactersLevel        = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Level").GetComponent<Text>();
        _CharactersLevel.text   = "Lv: " + _party.characters[0].Level.ToString();
	}
	
	void Update () 
    {
        PlayerInfo();
	}

    void PlayerInfo()
    {
        //maxhealth / 100 = 1 % 
        _CharactersHealth.text  = "HP : " + _party.characters[0].Health.ToString() + "/" + _party.characters[0].MaxHealth.ToString();
        _CharactersMana.text    = "MP : " + _party.characters[0].Mana.ToString() + "/" + _party.characters[0].MaxMana.ToString();
    }
}
