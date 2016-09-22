using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class RaceSelection : MonoBehaviour {

    [SerializeField]private List<Button> _genderButtons = new List<Button>();
    [SerializeField]private List<Button> _raceSelectionButtons = new List<Button>();
    [SerializeField]private Text _raceDescription;
    private List<BaseCharacterRace> _playerRace = new List<BaseCharacterRace>();
    private int _raceSelection;
    private bool _isMale;
    
    
    private Text _raceName;
    
	void Start () {
        _playerRace.Add(new BaseBarbarianRace());
        _playerRace.Add(new BaseDwarfRace());
        _playerRace.Add(new BaseElfRace());
        _playerRace.Add(new BaseDarkElfRace());
        _playerRace.Add(new BaseHumanRace());
        _playerRace.Add(new BaseTrollRace());
        _playerRace.Add(new BaseSkeletonRace());
        _playerRace.Add(new BaseGolemRace());

        _raceDescription = _raceDescription.GetComponent<Text>();
        FindRaceNames();
	}

    void FindRaceNames()
    {
        BaseCharacterRace tempRace;
        for (int i = 0; i < _raceSelectionButtons.Count; i++)
        {
            tempRace = _playerRace[i];
            _raceName = _raceSelectionButtons[i].GetComponentInChildren<Text>();
            _raceName.text = tempRace.RaceName;
        }
    }

    public void ChooseMale()
    {
        _isMale = true;
        Debug.Log(_isMale);
    }

    public void ChooseFemale()
    {
        _isMale = false;
        Debug.Log(_isMale);
    }

    public void FindRaceDescription(int raceSelection)
    {
        BaseCharacterRace tempRace;
        _raceSelection = raceSelection;
        tempRace = _playerRace[_raceSelection];
        _raceDescription.text = tempRace.RaceDescription;
    }

    public void ChooseRace()
    {
        BaseCharacterRace chosenRace;
        chosenRace = _playerRace[_raceSelection];
        GameInformation.PlayerRace = chosenRace;

        if (_isMale)
        {
            GameInformation.IsMale = true;
        }
        else
        {
            GameInformation.IsMale = false;
        }
        Debug.Log(GameInformation.PlayerRace.RaceName);
    }
}
