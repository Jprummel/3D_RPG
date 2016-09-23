using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CharacterFinalisation : MonoBehaviour {

    [SerializeField]private List<InputField>    _inputFields = new List<InputField>();
    [SerializeField]private Button              _createButton;
    private string  _firstName;
    private string  _lastName;
    private string  _characterBio;

	void Start () {
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
        PlayerInformation.CharactersName = _firstName + " " + _lastName; // Players full name

        PlayerInformation.CharactersLevel = 1;
        PlayerInformation.Gold = 500;
        PlayerInformation.RequiredXP = 500;
        PlayerInformation.CharactersClass.CharactersSkills.Add(new AttackAbility());
    }
}
