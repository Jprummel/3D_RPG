using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatAllocation : MonoBehaviour {

    private Party _party;
    [SerializeField]private List<GameObject> _addStatButtons = new List<GameObject>();
    [SerializeField]private List<GameObject> _removeStatButtons = new List<GameObject>();
    [SerializeField]private Text _availablePointsText;
    [SerializeField]private List<Text> _statValueText = new List<Text>();
    [SerializeField]private Button _nextButton;
    private int     _statNumber;
    private int[]   _pointsToAllocate = new int[8];       //Points to put in stats chosen by the player 
    private int[]   _baseStatPoints = new int[8];       //Starting stat values for the chosen class
    private int     _usedPoints;
    private int     _availablePoints;

    void Awake()
    {
        _party = GameObject.Find("PartyManager").GetComponent<Party>();
    }

    void Start()
    {
        _availablePointsText = _availablePointsText.GetComponent<Text>();
        _statValueText[_statNumber].GetComponent<Text>();
    }

    public void AllocationStart()
    {
        RetrieveStatBaseStatPoints();
        _availablePoints = 5;
    }

    void Update()
    {
        if (_availablePoints > 0)
        {
            _availablePointsText.text = "Available stat points : " + _availablePoints;
            _nextButton.interactable = false;
        }
        else
        {
            _availablePointsText.text = "";
            _nextButton.interactable = true;
        }

        ShowButtons();
        RetrievePointsToAllocate();
        ShowStatValues();
    }

    public void ShowButtons()
    {
        for (int i = 0; i < _pointsToAllocate.Length; i++)
        {

            if (_pointsToAllocate[i] >= _baseStatPoints[i] && _availablePoints > 0)
            {
                foreach (GameObject button in _addStatButtons)
                {
                    button.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject button in _addStatButtons)
                {
                    button.SetActive(false);
                }
            }

            if (_pointsToAllocate[i] > _baseStatPoints[i])
            {
                _removeStatButtons[i].SetActive(true);
            }
            else
            {
                _removeStatButtons[i].SetActive(false);
            }
        }
    }

    public void AddStatPoint(int statIndex)
    {
        switch (statIndex)
        {
            case 0:
                _party.characters[0].Class.Strength += 1;
                break;
            case 1:
                _party.characters[0].Class.Stamina += 1;
                break;
            case 2:
                _party.characters[0].Class.Spirit += 1;
                break;
            case 3:
                _party.characters[0].Class.Intellect += 1;
                break;
            case 4:
                _party.characters[0].Class.Overpower += 1;
                break;
            case 5:
                _party.characters[0].Class.Luck += 1;
                break;
            case 6:
                _party.characters[0].Class.Mastery += 1;
                break;
            case 7:
                _party.characters[0].Class.Charisma += 1;
                break;
        }
        _usedPoints += 1;
        _availablePoints--;
    }

    public void RemoveStatPoint(int statIndex)
    {
        switch (statIndex)
        {
            case 0:
                _party.characters[0].Class.Strength -= 1;
                break;
            case 1:
                _party.characters[0].Class.Stamina -= 1;
                break;
            case 2:
                _party.characters[0].Class.Spirit -= 1;
                break;
            case 3:
                _party.characters[0].Class.Intellect -= 1;
                break;
            case 4:
                _party.characters[0].Class.Overpower -= 1;
                break;
            case 5:
                _party.characters[0].Class.Luck -= 1;
                break;
            case 6:
                _party.characters[0].Class.Mastery -= 1;
                break;
            case 7:
                _party.characters[0].Class.Charisma -= 1;
                break;
        }
        _usedPoints -= 1;
        _availablePoints++;
    }

    public void ConfirmStats()
    {
        _party.characters[0].Strength    = _party.characters[0].Class.Strength;
        _party.characters[0].Stamina     = _party.characters[0].Class.Stamina;
        _party.characters[0].Spirit      = _party.characters[0].Class.Spirit;
        _party.characters[0].Intellect   = _party.characters[0].Class.Intellect;
        _party.characters[0].Overpower   = _party.characters[0].Class.Overpower;
        _party.characters[0].Luck        = _party.characters[0].Class.Luck;
        _party.characters[0].Mastery     = _party.characters[0].Class.Mastery;
        _party.characters[0].Charisma    = _party.characters[0].Class.Charisma;
    }

    public void ResetToBaseStats()
    {
        _party.characters[0].Class.Strength    = _baseStatPoints[0];
        _party.characters[0].Class.Stamina     = _baseStatPoints[1];
        _party.characters[0].Class.Spirit      = _baseStatPoints[2];
        _party.characters[0].Class.Intellect   = _baseStatPoints[3];
        _party.characters[0].Class.Overpower   = _baseStatPoints[4];
        _party.characters[0].Class.Luck        = _baseStatPoints[5];
        _party.characters[0].Class.Mastery     = _baseStatPoints[6];
        _party.characters[0].Class.Charisma    = _baseStatPoints[7];
    }

    void RetrieveStatBaseStatPoints()
    {
        _baseStatPoints[0] = _party.characters[0].Class.Strength;
        _baseStatPoints[1] = _party.characters[0].Class.Stamina;
        _baseStatPoints[2] = _party.characters[0].Class.Spirit;
        _baseStatPoints[3] = _party.characters[0].Class.Intellect;
        _baseStatPoints[4] = _party.characters[0].Class.Overpower;
        _baseStatPoints[5] = _party.characters[0].Class.Luck;
        _baseStatPoints[6] = _party.characters[0].Class.Mastery;
        _baseStatPoints[7] = _party.characters[0].Class.Charisma;
    }

    void RetrievePointsToAllocate()
    {
        _pointsToAllocate[0] = _party.characters[0].Class.Strength;
        _pointsToAllocate[1] = _party.characters[0].Class.Stamina;
        _pointsToAllocate[2] = _party.characters[0].Class.Spirit;
        _pointsToAllocate[3] = _party.characters[0].Class.Intellect;
        _pointsToAllocate[4] = _party.characters[0].Class.Overpower;
        _pointsToAllocate[5] = _party.characters[0].Class.Luck;
        _pointsToAllocate[6] = _party.characters[0].Class.Mastery;
        _pointsToAllocate[7] = _party.characters[0].Class.Charisma;
    }

    public void ShowStatValues()
    {
        for (int i = 0; i < _statValueText.Count; i++)
        {
            switch (i)
            {
                case 0:
                    _statValueText[i].text = _party.characters[0].Class.Strength.ToString();
                    break;
                case 1:
                    _statValueText[i].text = _party.characters[0].Class.Stamina.ToString();
                    break;
                case 2:
                    _statValueText[i].text = _party.characters[0].Class.Spirit.ToString();
                    break;
                case 3:
                    _statValueText[i].text = _party.characters[0].Class.Intellect.ToString();
                    break;
                case 4:
                    _statValueText[i].text = _party.characters[0].Class.Overpower.ToString();
                    break;
                case 5:
                    _statValueText[i].text = _party.characters[0].Class.Luck.ToString();
                    break;
                case 6:
                    _statValueText[i].text = _party.characters[0].Class.Mastery.ToString();
                    break;
                case 7:
                    _statValueText[i].text = _party.characters[0].Class.Charisma.ToString();
                    break;
            }
        }
    }
}
