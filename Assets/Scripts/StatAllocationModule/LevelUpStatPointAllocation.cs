using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpStatPointAllocation : MonoBehaviour {

    private Party _party;
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
        _party = GameObject.Find("PartyManager").GetComponent<Party>();
        if (!_didRunOnce)
        {
            RetrieveStatBaseStatPoints();
            _didRunOnce = true;
        }
        _availablePointsText = _availablePointsText.GetComponent<Text>();
    }

    void Update()
    {
        _availablePoints = _party.characters[0].StatPoints;

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
                _party.characters[0].Strength += 1;
                break;
            case 1:
                _party.characters[0].Stamina += 1;
                break;
            case 2:
                _party.characters[0].Spirit += 1;
                break;
            case 3:
                _party.characters[0].Intellect += 1;
                break;
            case 4:
                _party.characters[0].Overpower += 1;
                break;
            case 5:
                _party.characters[0].Luck += 1;
                break;
            case 6:
                _party.characters[0].Mastery += 1;
                break;
            case 7:
                _party.characters[0].Charisma += 1;
                break;
        }
        _usedPoints += 1;
            _party.characters[0].StatPoints--;        
    }

    public void RemoveStatPoint(int statIndex)
    {
        switch (statIndex)
        {
            case 0:
                _party.characters[0].Strength -= 1;
                break;
            case 1:
                _party.characters[0].Stamina -= 1;
                break;
            case 2:
                _party.characters[0].Spirit -= 1;
                break;
            case 3:
                _party.characters[0].Intellect -= 1;
                break;
            case 4:
                _party.characters[0].Overpower -= 1;
                break;
            case 5:
                _party.characters[0].Luck -= 1;
                break;
            case 6:
                _party.characters[0].Mastery -= 1;
                break;
            case 7:
                _party.characters[0].Charisma -= 1;
                break;
        }
        _usedPoints -= 1;
        _party.characters[0].StatPoints++;
    }

    public void ConfirmChanges()
    {
        _baseStatPoints[0] = _party.characters[0].Strength;
        _baseStatPoints[1] = _party.characters[0].Stamina;
        _baseStatPoints[2] = _party.characters[0].Spirit;
        _baseStatPoints[3] = _party.characters[0].Intellect;
        _baseStatPoints[4] = _party.characters[0].Overpower;
        _baseStatPoints[5] = _party.characters[0].Luck;
        _baseStatPoints[6] = _party.characters[0].Mastery;
        _baseStatPoints[7] = _party.characters[0].Charisma;
        _usedPoints = 0;
    }

    public void CancelChanges()
    {
        _party.characters[0].Strength = _baseStatPoints[0];
        _party.characters[0].Stamina = _baseStatPoints[1];
        _party.characters[0].Spirit = _baseStatPoints[2];
        _party.characters[0].Intellect = _baseStatPoints[3];
        _party.characters[0].Overpower = _baseStatPoints[4];
        _party.characters[0].Luck = _baseStatPoints[5];
        _party.characters[0].Mastery = _baseStatPoints[6];
        _party.characters[0].Charisma = _baseStatPoints[7];
        _party.characters[0].StatPoints += _usedPoints;
        _usedPoints = 0;
    }

    void RetrieveStatBaseStatPoints()
    {        
        _baseStatPoints[0] = _party.characters[0].Strength;        
        _baseStatPoints[1] = _party.characters[0].Stamina;        
        _baseStatPoints[2] = _party.characters[0].Spirit;        
        _baseStatPoints[3] = _party.characters[0].Intellect;
        _baseStatPoints[4] = _party.characters[0].Overpower;       
        _baseStatPoints[5] = _party.characters[0].Luck;        
        _baseStatPoints[6] = _party.characters[0].Mastery;
        _baseStatPoints[7] = _party.characters[0].Charisma;
    }

    void RetrievePointsToAllocate()
    {
        _pointsToAllocate[0] = _party.characters[0].Strength;
        _pointsToAllocate[1] = _party.characters[0].Stamina;
        _pointsToAllocate[2] = _party.characters[0].Spirit;
        _pointsToAllocate[3] = _party.characters[0].Intellect;
        _pointsToAllocate[4] = _party.characters[0].Overpower;
        _pointsToAllocate[5] = _party.characters[0].Luck;
        _pointsToAllocate[6] = _party.characters[0].Mastery;
        _pointsToAllocate[7] = _party.characters[0].Charisma;
    }
}
