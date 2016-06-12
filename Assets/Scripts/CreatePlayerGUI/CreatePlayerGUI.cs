using UnityEngine;
using System.Collections;

public class CreatePlayerGUI : MonoBehaviour {

    public enum CreateAPlayerStates
    {
        CLASSSELECTION, //Display all class types
        STATALLOCATION, //Allocate stats where the player wants too 
        FINALSETUP      //Add name and misc items & gender
    }

    public static CreateAPlayerStates currentState;
    private DisplayCreatePlayerFunctions _displayFunctions = new DisplayCreatePlayerFunctions();

	void Start () 
    {
        currentState = CreateAPlayerStates.STATALLOCATION;
	}
	
	void Update () 
    {
        switch (currentState)
        {
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
        //_displayFunctions.DisplayMainItems();
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
