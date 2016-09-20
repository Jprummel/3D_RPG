using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CharacterFinalisation : MonoBehaviour {

    [SerializeField]private List<InputField>    _inputFields = new List<InputField>();
    [SerializeField]private List<Button>        _genderButtons = new List<Button>();
    [SerializeField]private Button              _createButton;
    private string  _firstName;
    private string  _lastName;
    private string  _characterBio;
    private bool    _isMale;

	void Start () {
        _createButton.interactable = false;
	}

    public void ChangeFirstName()
    {
        _firstName = _inputFields[0].text;
    }

    public void ChangeLastName()
    {
        _lastName = _inputFields[1].text;
    }

    public void ChangeCharacterBio()
    {
        _characterBio = _inputFields[2].text;
    }
    public void ChooseMale()
    {
        _isMale = true;
        Debug.Log(_isMale);
        if (_inputFields[0].text != "")
        {
            _createButton.interactable = true;
        }
    }

    public void ChooseFemale()
    {
        _isMale = false;
        Debug.Log(_isMale);
        if (_inputFields[0].text != "")
        {
            _createButton.interactable = true;
        }
    }

    public void Finalisation()
    {
        GameInformation.PlayerName = _firstName + " " + _lastName; // Players full name
        GameInformation.PlayerBio = _characterBio; //Sets the players backstory
        if (_isMale)
        {
            GameInformation.IsMale = true;
        }
        else
        {
            GameInformation.IsMale = false;
        }

        GameInformation.PlayerLevel = 1;
        GameInformation.Gold = 500;
        GameInformation.RequiredXP = 500;
        GameInformation.PlayerClass.PlayersSkills.Add(new AttackAbility());
    }
}
