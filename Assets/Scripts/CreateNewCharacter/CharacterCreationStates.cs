using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class CharacterCreationStates : MonoBehaviour {
    //Character creation panels
    [SerializeField]private GameObject _raceSelectionPanel;
    [SerializeField]private GameObject _classSelectionPanel;
    [SerializeField]private GameObject _statAllocationPanel;
    [SerializeField]private GameObject _characterFinalisationPanel;
    [SerializeField]private GameObject _saveCharacterPanel;
    //Buttons that switch states
    [SerializeField]private Button _backButton;
    [SerializeField]private Button _nextButton;
    //Text of the next button
    private Text _nextButtonText;

    //Scripts for final info
    private RaceSelection           _raceSelection;
    private ClassSelection          _classSelection;
    private StatAllocation          _statAllocation;
    private CharacterFinalisation   _characterFinalisation;
    private Party _party;

    private enum CreationStates
    {
        RACESELECTION,
        CLASSSELECTION,
        STATALLOCATION,
        FINALSETUP,
        SAVECHARACTER
    }

    private CreationStates currentState;

	void Start () {
        //Gets instance of the scripts
        _raceSelection          = _raceSelectionPanel.GetComponent<RaceSelection>();
        _classSelection         = _classSelectionPanel.GetComponent<ClassSelection>();
        _statAllocation         = _statAllocationPanel.GetComponent<StatAllocation>();
        _characterFinalisation  = _characterFinalisationPanel.GetComponent<CharacterFinalisation>();

        _nextButtonText = _nextButton.GetComponentInChildren<Text>();

        currentState = CreationStates.RACESELECTION; //Starts the character creation screen on the race selection
        _raceSelectionPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case(CreationStates.RACESELECTION):                
                break;
            case(CreationStates.CLASSSELECTION):
                break;
            case(CreationStates.STATALLOCATION):
                break;
            case(CreationStates.FINALSETUP):
                break;
            case(CreationStates.SAVECHARACTER):
                break;
        }
	}

    public void ChangeToNextState()
    {
        switch (currentState)
        {
            case (CreationStates.RACESELECTION):
                _raceSelection.ChooseRace();
                _raceSelectionPanel.SetActive(false);
                _classSelectionPanel.SetActive(true);
                _backButton.interactable = true;
                currentState = CreationStates.CLASSSELECTION;
                Debug.Log(currentState);
                break;
            case (CreationStates.CLASSSELECTION):
                _classSelection.ChooseClass();
                _classSelectionPanel.SetActive(false);
                _statAllocationPanel.SetActive(true);
                currentState = CreationStates.STATALLOCATION;
                _statAllocation.AllocationStart();
                Debug.Log(currentState);
                break;
            case (CreationStates.STATALLOCATION):
                _statAllocationPanel.SetActive(false);
                _characterFinalisationPanel.SetActive(true);
                _nextButtonText.text = "Create";
                _statAllocation.ConfirmStats();
                currentState = CreationStates.FINALSETUP;
                Debug.Log(currentState);
                break;
            case (CreationStates.FINALSETUP):
                _characterFinalisation.Finalisation();
                SaveLoadGame saveCharacter = new SaveLoadGame();
                //_party.partyMembers.Add(new PlayerInformation());
                //Party.partyMembers.Add(new PlayerInformation());
                saveCharacter.SaveGame();
                SceneManager.LoadScene("MovementTest");
                break;
            case(CreationStates.SAVECHARACTER):
                break;
        }
    }

    public void ChangeToPreviousState()
    {
        switch (currentState)
        {
            case (CreationStates.RACESELECTION):
                Debug.Log(currentState);
                break;
            case (CreationStates.CLASSSELECTION):
                PlayerInformation.CharactersRace = null;  //Player can re-select his race
                _classSelectionPanel.SetActive(false);
                _raceSelectionPanel.SetActive(true);
                _backButton.interactable = false;
                currentState = CreationStates.RACESELECTION;
                Debug.Log(currentState);
                break;
            case (CreationStates.STATALLOCATION):
                _statAllocation.ResetToBaseStats(); //Resets the stats back to the basestats to prevent cheating
                PlayerInformation.CharactersClass = null; //Player can re-select his class
                _statAllocationPanel.SetActive(false);
                _classSelectionPanel.SetActive(true);
                currentState = CreationStates.CLASSSELECTION;
                Debug.Log(currentState);
                break;
            case (CreationStates.FINALSETUP):
                _characterFinalisationPanel.SetActive(false);
                _statAllocationPanel.SetActive(true);
                _nextButtonText.text = "Next";
                currentState = CreationStates.STATALLOCATION;
                break;
            case(CreationStates.SAVECHARACTER):

                break;
        }
    }
}
