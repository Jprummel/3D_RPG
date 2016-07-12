using UnityEngine;
using System.Collections;

public class CreatePlayerGUI : MonoBehaviour {

    public enum CreateAPlayerStates
    {
        RACESELECTION,  //Display all the playable race's
        CLASSSELECTION, //Display all class types
        STATALLOCATION, //Allocate stats where the player wants too 
        FINALSETUP      //Add name and misc items & gender
    }

    public static CreateAPlayerStates currentState;
    private DisplayCreatePlayerFunctions _displayFunctions = new DisplayCreatePlayerFunctions();

	void Start () 
    {
        currentState = CreateAPlayerStates.RACESELECTION;
	}
	
	void Update () 
    {
        switch (currentState)
        {
            case(CreateAPlayerStates.RACESELECTION):
                break;
            case(CreateAPlayerStates.CLASSSELECTION):
                break;
            case (CreateAPlayerStates.STATALLOCATION):
                break;
            case (CreateAPlayerStates.FINALSETUP):
                break;
        }
	}

    void OnGUI()
    {
        _displayFunctions.DisplayMainItems();

        if (currentState == CreateAPlayerStates.RACESELECTION)
        {
            _displayFunctions.DisplayRaceSelections();
        }
        if (currentState == CreateAPlayerStates.CLASSSELECTION)
        {
            _displayFunctions.DisplayClassSelections();
        }
        if (currentState == CreateAPlayerStates.STATALLOCATION)
        {
            _displayFunctions.DisplayStatAllocation();
        }
        if (currentState == CreateAPlayerStates.FINALSETUP)
        {
            _displayFunctions.DisplayFinalSetup();
        }
    }
}
