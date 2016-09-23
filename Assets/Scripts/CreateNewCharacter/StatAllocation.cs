using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatAllocation : MonoBehaviour {

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
                PlayerInformation.CharactersClass.Strength += 1;
                break;
            case 1:
                PlayerInformation.CharactersClass.Stamina += 1;
                break;
            case 2:
                PlayerInformation.CharactersClass.Spirit += 1;
                break;
            case 3:
                PlayerInformation.CharactersClass.Intellect += 1;
                break;
            case 4:
                PlayerInformation.CharactersClass.Overpower += 1;
                break;
            case 5:
                PlayerInformation.CharactersClass.Luck += 1;
                break;
            case 6:
                PlayerInformation.CharactersClass.Mastery += 1;
                break;
            case 7:
                PlayerInformation.CharactersClass.Charisma += 1;
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
                PlayerInformation.CharactersClass.Strength -= 1;
                break;
            case 1:
                PlayerInformation.CharactersClass.Stamina -= 1;
                break;
            case 2:
                PlayerInformation.CharactersClass.Spirit -= 1;
                break;
            case 3:
                PlayerInformation.CharactersClass.Intellect -= 1;
                break;
            case 4:
                PlayerInformation.CharactersClass.Overpower -= 1;
                break;
            case 5:
                PlayerInformation.CharactersClass.Luck -= 1;
                break;
            case 6:
                PlayerInformation.CharactersClass.Mastery -= 1;
                break;
            case 7:
                PlayerInformation.CharactersClass.Charisma -= 1;
                break;
        }
        _usedPoints -= 1;
        _availablePoints++;
    }

    public void ConfirmStats()
    {
        PlayerInformation.Strength    = PlayerInformation.CharactersClass.Strength;
        PlayerInformation.Stamina     = PlayerInformation.CharactersClass.Stamina;
        PlayerInformation.Spirit      = PlayerInformation.CharactersClass.Spirit;
        PlayerInformation.Intellect   = PlayerInformation.CharactersClass.Intellect;
        PlayerInformation.Overpower   = PlayerInformation.CharactersClass.Overpower;
        PlayerInformation.Luck        = PlayerInformation.CharactersClass.Luck;
        PlayerInformation.Mastery     = PlayerInformation.CharactersClass.Mastery;
        PlayerInformation.Charisma    = PlayerInformation.CharactersClass.Charisma;
    }

    public void ResetToBaseStats()
    {
        PlayerInformation.CharactersClass.Strength    = _baseStatPoints[0];
        PlayerInformation.CharactersClass.Stamina     = _baseStatPoints[1];
        PlayerInformation.CharactersClass.Spirit      = _baseStatPoints[2];
        PlayerInformation.CharactersClass.Intellect   = _baseStatPoints[3];
        PlayerInformation.CharactersClass.Overpower   = _baseStatPoints[4];
        PlayerInformation.CharactersClass.Luck        = _baseStatPoints[5];
        PlayerInformation.CharactersClass.Mastery     = _baseStatPoints[6];
        PlayerInformation.CharactersClass.Charisma    = _baseStatPoints[7];
    }

    void RetrieveStatBaseStatPoints()
    {
        _baseStatPoints[0] = PlayerInformation.CharactersClass.Strength;
        _baseStatPoints[1] = PlayerInformation.CharactersClass.Stamina;
        _baseStatPoints[2] = PlayerInformation.CharactersClass.Spirit;
        _baseStatPoints[3] = PlayerInformation.CharactersClass.Intellect;
        _baseStatPoints[4] = PlayerInformation.CharactersClass.Overpower;
        _baseStatPoints[5] = PlayerInformation.CharactersClass.Luck;
        _baseStatPoints[6] = PlayerInformation.CharactersClass.Mastery;
        _baseStatPoints[7] = PlayerInformation.CharactersClass.Charisma;
    }

    void RetrievePointsToAllocate()
    {
        _pointsToAllocate[0] = PlayerInformation.CharactersClass.Strength;
        _pointsToAllocate[1] = PlayerInformation.CharactersClass.Stamina;
        _pointsToAllocate[2] = PlayerInformation.CharactersClass.Spirit;
        _pointsToAllocate[3] = PlayerInformation.CharactersClass.Intellect;
        _pointsToAllocate[4] = PlayerInformation.CharactersClass.Overpower;
        _pointsToAllocate[5] = PlayerInformation.CharactersClass.Luck;
        _pointsToAllocate[6] = PlayerInformation.CharactersClass.Mastery;
        _pointsToAllocate[7] = PlayerInformation.CharactersClass.Charisma;
    }

    public void ShowStatValues()
    {
        for (int i = 0; i < _statValueText.Count; i++)
        {
            switch (i)
            {
                case 0:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Strength.ToString();
                    break;
                case 1:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Stamina.ToString();
                    break;
                case 2:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Spirit.ToString();
                    break;
                case 3:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Intellect.ToString();
                    break;
                case 4:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Overpower.ToString();
                    break;
                case 5:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Luck.ToString();
                    break;
                case 6:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Mastery.ToString();
                    break;
                case 7:
                    _statValueText[i].text = PlayerInformation.CharactersClass.Charisma.ToString();
                    break;
            }
        }
    }
}
