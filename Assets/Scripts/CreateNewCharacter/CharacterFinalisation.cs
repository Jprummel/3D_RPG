using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CharacterFinalisation : MonoBehaviour {

    private Party _party;
    private SaveLoadGame _save;
    [SerializeField]private List<InputField>    _inputFields = new List<InputField>();
    [SerializeField]private Button              _createButton;
    private string  _firstName;
    private string  _lastName;
    private string  _characterBio;

	void Start () {
        _save = GetComponent<SaveLoadGame>();
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
        _createButton.interactable = false;
	}

    public void ChangeFirstName()
    {
        _firstName = _inputFields[0].text;
        _createButton.interactable = true;
    }

    public void ChangeLastName()
    {
        _lastName = _inputFields[1].text;
    }

    public void Finalisation()
    {
        _party.characters[0].Name = _firstName + " " + _lastName; // Players full name

        _party.characters[0].Level = 1;
        PlayerInformation.Gold = 500;
        _party.characters[0].RequiredXP = 500;
        _party.characters[0].Skills.Add(new AttackAbility());
        _save.SaveGame();
    }
}
