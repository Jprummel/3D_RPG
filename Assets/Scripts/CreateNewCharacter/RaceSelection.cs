using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class RaceSelection : MonoBehaviour {

    [SerializeField]private List<Button> _genderButtons = new List<Button>();
    [SerializeField]private List<Button> _raceSelectionButtons = new List<Button>();
    [SerializeField]private Text _raceDescription;
    private List<BaseCharacterRace> _CharactersRace = new List<BaseCharacterRace>();
    private int _raceSelection;
    private bool _isMale;
    
    
    private Text _raceName;
    
	void Start () {
        _CharactersRace.Add(new BaseBarbarianRace());
        _CharactersRace.Add(new BaseDwarfRace());
        _CharactersRace.Add(new BaseElfRace());
        _CharactersRace.Add(new BaseDarkElfRace());
        _CharactersRace.Add(new BaseHumanRace());
        _CharactersRace.Add(new BaseTrollRace());
        _CharactersRace.Add(new BaseSkeletonRace());
        _CharactersRace.Add(new BaseGolemRace());

        _raceDescription = _raceDescription.GetComponent<Text>();
        FindRaceNames();
	}

    void FindRaceNames()
    {
        BaseCharacterRace tempRace;
        for (int i = 0; i < _raceSelectionButtons.Count; i++)
        {
            tempRace = _CharactersRace[i];
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
        tempRace = _CharactersRace[_raceSelection];
        _raceDescription.text = tempRace.RaceDescription;
    }

    public void ChooseRace()
    {
        BaseCharacterRace chosenRace;
        chosenRace = _CharactersRace[_raceSelection];
        PlayerInformation.CharactersRace = chosenRace;

        if (_isMale)
        {
            PlayerInformation.IsMale = true;
        }
        else
        {
            PlayerInformation.IsMale = false;
        }
        Debug.Log(PlayerInformation.CharactersRace.RaceName);
    }
}
