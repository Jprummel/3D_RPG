using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpStatPointAllocation : MonoBehaviour {

    private int[] _pointsToAllocate = new int[8];       //Points to put in stats chosen by the player 
    private int[] _baseStatPoints = new int[8];       //Starting stat values for the chosen class
    private bool _didRunOnce;
    private int _usedPoints;
    private int _availablePoints;
    [SerializeField]private List<GameObject> _addStatButtons = new List<GameObject>();
    [SerializeField]private List<GameObject> _removeStatButtons = new List<GameObject>();
    [SerializeField]private GameObject _confirmButton;
    [SerializeField]private Text _availablePointsText;

    void Start()
    {
        if (!_didRunOnce)
        {
            RetrieveStatBaseStatPoints();
            _didRunOnce = true;
        }
        _availablePointsText = _availablePointsText.GetComponent<Text>();
    }

    void Update()
    {
        _availablePoints = GameInformation.StatPoints;

        if (_availablePoints > 0)
        {
            _availablePointsText.text = "Available stat points : " + _availablePoints;
        }
        else
        {
            _availablePointsText.text = "";
        }
        
        ShowButtons();
        RetrievePointsToAllocate();
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

            if (_usedPoints >= 1)
            {
                _confirmButton.SetActive(true);
            }
            else
            {
                _confirmButton.SetActive(false);
            }
        }
    }

    public void AddStatPoint(int statIndex)
    {
        switch (statIndex)
        {
            case 0:
                GameInformation.Strength += 1;
                break;
            case 1:
                GameInformation.Stamina += 1;
                break;
            case 2:
                GameInformation.Spirit += 1;
                break;
            case 3:
                GameInformation.Intellect += 1;
                break;
            case 4:
                GameInformation.Overpower += 1;
                break;
            case 5:
                GameInformation.Luck += 1;
                break;
            case 6:
                GameInformation.Mastery += 1;
                break;
            case 7:
                GameInformation.Charisma += 1;
                break;
        }
        _usedPoints += 1;
            GameInformation.StatPoints--;        
    }

    public void RemoveStatPoint(int statIndex)
    {
        switch (statIndex)
        {
            case 0:
                GameInformation.Strength -= 1;
                break;
            case 1:
                GameInformation.Stamina -= 1;
                break;
            case 2:
                GameInformation.Spirit -= 1;
                break;
            case 3:
                GameInformation.Intellect -= 1;
                break;
            case 4:
                GameInformation.Overpower -= 1;
                break;
            case 5:
                GameInformation.Luck -= 1;
                break;
            case 6:
                GameInformation.Mastery -= 1;
                break;
            case 7:
                GameInformation.Charisma -= 1;
                break;
        }
        _usedPoints -= 1;
        GameInformation.StatPoints++;
    }

    public void ConfirmChanges()
    {
        _baseStatPoints[0] = GameInformation.Strength;
        _baseStatPoints[1] = GameInformation.Stamina;
        _baseStatPoints[2] = GameInformation.Spirit;
        _baseStatPoints[3] = GameInformation.Intellect;
        _baseStatPoints[4] = GameInformation.Overpower;
        _baseStatPoints[5] = GameInformation.Luck;
        _baseStatPoints[6] = GameInformation.Mastery;
        _baseStatPoints[7] = GameInformation.Charisma;
        _usedPoints = 0;
    }

    public void CancelChanges()
    {
        GameInformation.Strength = _baseStatPoints[0];
        GameInformation.Stamina = _baseStatPoints[1];
        GameInformation.Spirit = _baseStatPoints[2];
        GameInformation.Intellect = _baseStatPoints[3];
        GameInformation.Overpower = _baseStatPoints[4];
        GameInformation.Luck = _baseStatPoints[5];
        GameInformation.Mastery = _baseStatPoints[6];
        GameInformation.Charisma = _baseStatPoints[7];
        GameInformation.StatPoints += _usedPoints;
        _usedPoints = 0;
    }

    void RetrieveStatBaseStatPoints()
    {        
        _baseStatPoints[0] = GameInformation.Strength;        
        _baseStatPoints[1] = GameInformation.Stamina;        
        _baseStatPoints[2] = GameInformation.Spirit;        
        _baseStatPoints[3] = GameInformation.Intellect;
        _baseStatPoints[4] = GameInformation.Overpower;       
        _baseStatPoints[5] = GameInformation.Luck;        
        _baseStatPoints[6] = GameInformation.Mastery;
        _baseStatPoints[7] = GameInformation.Charisma;
    }

    void RetrievePointsToAllocate()
    {
        _pointsToAllocate[0] = GameInformation.Strength;
        _pointsToAllocate[1] = GameInformation.Stamina;
        _pointsToAllocate[2] = GameInformation.Spirit;
        _pointsToAllocate[3] = GameInformation.Intellect;
        _pointsToAllocate[4] = GameInformation.Overpower;
        _pointsToAllocate[5] = GameInformation.Luck;
        _pointsToAllocate[6] = GameInformation.Mastery;
        _pointsToAllocate[7] = GameInformation.Charisma;
    }
}
