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
                GameInformation.PlayerClass.Strength += 1;
                break;
            case 1:
                GameInformation.PlayerClass.Stamina += 1;
                break;
            case 2:
                GameInformation.PlayerClass.Spirit += 1;
                break;
            case 3:
                GameInformation.PlayerClass.Intellect += 1;
                break;
            case 4:
                GameInformation.PlayerClass.Overpower += 1;
                break;
            case 5:
                GameInformation.PlayerClass.Luck += 1;
                break;
            case 6:
                GameInformation.PlayerClass.Mastery += 1;
                break;
            case 7:
                GameInformation.PlayerClass.Charisma += 1;
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
                GameInformation.PlayerClass.Strength -= 1;
                break;
            case 1:
                GameInformation.PlayerClass.Stamina -= 1;
                break;
            case 2:
                GameInformation.PlayerClass.Spirit -= 1;
                break;
            case 3:
                GameInformation.PlayerClass.Intellect -= 1;
                break;
            case 4:
                GameInformation.PlayerClass.Overpower -= 1;
                break;
            case 5:
                GameInformation.PlayerClass.Luck -= 1;
                break;
            case 6:
                GameInformation.PlayerClass.Mastery -= 1;
                break;
            case 7:
                GameInformation.PlayerClass.Charisma -= 1;
                break;
        }
        _usedPoints -= 1;
        _availablePoints++;
    }

    public void ConfirmStats()
    {
        GameInformation.Strength    = GameInformation.PlayerClass.Strength;
        GameInformation.Stamina     = GameInformation.PlayerClass.Stamina;
        GameInformation.Spirit      = GameInformation.PlayerClass.Spirit;
        GameInformation.Intellect   = GameInformation.PlayerClass.Intellect;
        GameInformation.Overpower   = GameInformation.PlayerClass.Overpower;
        GameInformation.Luck        = GameInformation.PlayerClass.Luck;
        GameInformation.Mastery     = GameInformation.PlayerClass.Mastery;
        GameInformation.Charisma    = GameInformation.PlayerClass.Charisma;
    }

    public void ResetToBaseStats()
    {
        GameInformation.PlayerClass.Strength    = _baseStatPoints[0];
        GameInformation.PlayerClass.Stamina     = _baseStatPoints[1];
        GameInformation.PlayerClass.Spirit      = _baseStatPoints[2];
        GameInformation.PlayerClass.Intellect   = _baseStatPoints[3];
        GameInformation.PlayerClass.Overpower   = _baseStatPoints[4];
        GameInformation.PlayerClass.Luck        = _baseStatPoints[5];
        GameInformation.PlayerClass.Mastery     = _baseStatPoints[6];
        GameInformation.PlayerClass.Charisma    = _baseStatPoints[7];
    }

    void RetrieveStatBaseStatPoints()
    {
        _baseStatPoints[0] = GameInformation.PlayerClass.Strength;
        _baseStatPoints[1] = GameInformation.PlayerClass.Stamina;
        _baseStatPoints[2] = GameInformation.PlayerClass.Spirit;
        _baseStatPoints[3] = GameInformation.PlayerClass.Intellect;
        _baseStatPoints[4] = GameInformation.PlayerClass.Overpower;
        _baseStatPoints[5] = GameInformation.PlayerClass.Luck;
        _baseStatPoints[6] = GameInformation.PlayerClass.Mastery;
        _baseStatPoints[7] = GameInformation.PlayerClass.Charisma;
    }

    void RetrievePointsToAllocate()
    {
        _pointsToAllocate[0] = GameInformation.PlayerClass.Strength;
        _pointsToAllocate[1] = GameInformation.PlayerClass.Stamina;
        _pointsToAllocate[2] = GameInformation.PlayerClass.Spirit;
        _pointsToAllocate[3] = GameInformation.PlayerClass.Intellect;
        _pointsToAllocate[4] = GameInformation.PlayerClass.Overpower;
        _pointsToAllocate[5] = GameInformation.PlayerClass.Luck;
        _pointsToAllocate[6] = GameInformation.PlayerClass.Mastery;
        _pointsToAllocate[7] = GameInformation.PlayerClass.Charisma;
    }

    public void ShowStatValues()
    {
        for (int i = 0; i < _statValueText.Count; i++)
        {
            switch (i)
            {
                case 0:
                    _statValueText[i].text = GameInformation.PlayerClass.Strength.ToString();
                    break;
                case 1:
                    _statValueText[i].text = GameInformation.PlayerClass.Stamina.ToString();
                    break;
                case 2:
                    _statValueText[i].text = GameInformation.PlayerClass.Spirit.ToString();
                    break;
                case 3:
                    _statValueText[i].text = GameInformation.PlayerClass.Intellect.ToString();
                    break;
                case 4:
                    _statValueText[i].text = GameInformation.PlayerClass.Overpower.ToString();
                    break;
                case 5:
                    _statValueText[i].text = GameInformation.PlayerClass.Luck.ToString();
                    break;
                case 6:
                    _statValueText[i].text = GameInformation.PlayerClass.Mastery.ToString();
                    break;
                case 7:
                    _statValueText[i].text = GameInformation.PlayerClass.Charisma.ToString();
                    break;
            }
        }
    }
}
