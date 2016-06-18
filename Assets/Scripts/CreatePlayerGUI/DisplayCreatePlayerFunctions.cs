using UnityEngine;
using System.Collections;

public class DisplayCreatePlayerFunctions{

    private StatAllocationModule statAllocationModule = new StatAllocationModule();

    private int         _classSelection;
    private string[]    _classSelectionNames    = new string[] {"Warrior", "Berserker", "Rogue","Ranger","Mage","Necromancer"};
    private string      _playerFirstName        = "Enter first name";   //player first name
    private string      _playerLastName         = "Enter last name";    //player last name
    private string      _playerBio              = "Enter player bio";   //bio
    //Gender
    private int _genderSelection;
    private string[] _genderTypes = new string[2] { "Male", "Female" };

    public void DisplayClassSelections()
    {
        //A list of toggle buttons for classes each button is a different class
        //selection grid
        _classSelection = GUI.SelectionGrid(new Rect(50,50,250,300), _classSelection, _classSelectionNames,2);
        GUI.Label(new Rect(450, 50, 300, 300),FindClassDescription(_classSelection));
        GUI.Label(new Rect(450, 100, 300, 300), FindClassStatValues(_classSelection));
    }

    private string FindClassDescription(int classSelection)
    {
        BaseCharacterClass tempClass;

        if (classSelection == 0)
        {
             tempClass = new BaseWarriorClass();
            return tempClass.CharacterClassDescription;            
        }
        else if (classSelection == 1)
        {
            tempClass = new BaseBerserkerClass();
            return tempClass.CharacterClassDescription;
        }
        else if (classSelection == 2)
        {
            tempClass = new BaseRogueClass();
            return tempClass.CharacterClassDescription;
        }
        else if (classSelection == 3)
        {
            tempClass = new BaseRangerClass();
            return tempClass.CharacterClassDescription;
        }
        else if (classSelection == 4)
        {
            tempClass = new BaseMageClass();
            return tempClass.CharacterClassDescription;
        }
        else if (classSelection == 5)
        {
            tempClass = new BaseNecromancerClass();
            return tempClass.CharacterClassDescription;
        }

        return "No class selected";
    }

    private string FindClassStatValues(int classSelection)
    {
        BaseCharacterClass tempClass;
        

        if (classSelection == 0)
        {
            tempClass = new BaseWarriorClass();
            string tempStats = "Strength " + tempClass.Strength + "\n" +
                                "Stamina " + tempClass.Stamina + "\n" +
                                "Endurance " + tempClass.Endurance + "\n" +
                                "Intellect " + tempClass.Intellect + "\n" +
                                "Agility " + tempClass.Agility + "\n" +
                                "Resistance " + tempClass.Resistance;
            return tempStats;
        }
        else if (classSelection == 1)
        {
            tempClass = new BaseBerserkerClass();
            string tempStats = "Strength " + tempClass.Strength + "\n" +
                                "Stamina " + tempClass.Stamina + "\n" +
                                "Endurance " + tempClass.Endurance + "\n" +
                                "Intellect " + tempClass.Intellect + "\n" +
                                "Agility " + tempClass.Agility + "\n" +
                                "Resistance " + tempClass.Resistance;
            return tempStats;
        }
        else if (classSelection == 2)
        {
            tempClass = new BaseRogueClass();
            string tempStats = "Strength " + tempClass.Strength + "\n" +
                                "Stamina " + tempClass.Stamina + "\n" +
                                "Endurance " + tempClass.Endurance + "\n" +
                                "Intellect " + tempClass.Intellect + "\n" +
                                "Agility " + tempClass.Agility + "\n" +
                                "Resistance " + tempClass.Resistance;
            return tempStats;
        }
        else if (classSelection == 3)
        {
            tempClass = new BaseRangerClass();
            string tempStats = "Strength " + tempClass.Strength + "\n" +
                                "Stamina " + tempClass.Stamina + "\n" +
                                "Endurance " + tempClass.Endurance + "\n" +
                                "Intellect " + tempClass.Intellect + "\n" +
                                "Agility " + tempClass.Agility + "\n" +
                                "Resistance " + tempClass.Resistance;
            return tempStats;
        }
        else if (classSelection == 4)
        {
            tempClass = new BaseMageClass();
            string tempStats = "Strength " + tempClass.Strength + "\n" +
                                "Stamina " + tempClass.Stamina + "\n" +
                                "Endurance " + tempClass.Endurance + "\n" +
                                "Intellect " + tempClass.Intellect + "\n" +
                                "Agility " + tempClass.Agility + "\n" +
                                "Resistance " + tempClass.Resistance;
            return tempStats;
        }
        else if (classSelection == 5)
        {
            tempClass = new BaseNecromancerClass();
            string tempStats = "Strength " + tempClass.Strength + "\n" +
                                "Stamina " + tempClass.Stamina + "\n" +
                                "Endurance " + tempClass.Endurance + "\n" +
                                "Intellect " + tempClass.Intellect + "\n" +
                                "Agility " + tempClass.Agility + "\n" +
                                "Resistance " + tempClass.Resistance;
            return tempStats;
        }


        return "No stats to show";
    }

    public void DisplayStatAllocation()
    {
        //a list of stats with plus and minus buttons to add stats
        //logic to make sure the player cannot add more than stats given
        statAllocationModule.DisplayStatAllocationModule();
        GUI.Label(new Rect(20, Screen.height/2 + 10, 150, 100),"Stat points available " + statAllocationModule._availablePoints.ToString());
    }

    public void DisplayFinalSetup()
    {
        //name
        _playerFirstName = GUI.TextArea(new Rect(20,10,150,25), _playerFirstName,25);
        _playerLastName = GUI.TextArea(new Rect(20, 55, 150, 25), _playerLastName, 25);
       
        //gender
        _genderSelection = GUI.SelectionGrid(new Rect(200,10,100,70), _genderSelection,_genderTypes,1);
        //add a description to your character (short bio)
        _playerBio = GUI.TextArea(new Rect(20, 90, 250, 200), _playerBio, 250);
    }

    void ChooseClass(int classSelection)
    {
        if (classSelection == 0)
        {
            GameInformation.PlayerClass = new BaseWarriorClass();
        }
        else if (classSelection == 1)
        {
            GameInformation.PlayerClass = new BaseBerserkerClass();
        }
        else if (classSelection == 2)
        {
            GameInformation.PlayerClass = new BaseRogueClass();
        }
        else if (classSelection == 3)
        {
            GameInformation.PlayerClass = new BaseRangerClass();
        }
        else if (classSelection == 4)
        {
            GameInformation.PlayerClass = new BaseMageClass();
        }
        else if (classSelection == 5)
        {
            GameInformation.PlayerClass = new BaseNecromancerClass();
        }
    }

    public void DisplayMainItems()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GUI.Label(new Rect(Screen.width /2 , 20,250,250), "CREATE NEW PLAYER");

        if (GUI.Button(new Rect(900, 650, 50, 50), "<<<"))
        {
            //turn transform tagged as player to the left
            player.Rotate(Vector3.up * 10);
        }
        if (GUI.Button(new Rect(1050, 650, 50, 50), ">>>"))
        {
            //turn transform tagged as player to the right
            player.Rotate(Vector3.down * 10);
        }
        //NEXT BUTTON
        if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreateAPlayerStates.FINALSETUP) {
            if (GUI.Button(new Rect(1110, 650, 50, 50), "Next"))
            {
                if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION)
                {
                    ChooseClass(_classSelection);
                    CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
                else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    GameInformation.Strength    = statAllocationModule.pointsToAllocate[0];
                    GameInformation.Stamina     = statAllocationModule.pointsToAllocate[1];
                    GameInformation.Endurance   = statAllocationModule.pointsToAllocate[2];
                    GameInformation.Intellect   = statAllocationModule.pointsToAllocate[3];
                    GameInformation.Agility     = statAllocationModule.pointsToAllocate[4];
                    GameInformation.Resistance  = statAllocationModule.pointsToAllocate[5];
                    if (statAllocationModule._availablePoints == 0)
                    {
                        CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.FINALSETUP;
                    }
                }
            }
        }
        else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.FINALSETUP)
        {
            if (GUI.Button(new Rect(1110, 650, 50, 50), "Finish"))
            {
                //Final Save
                GameInformation.PlayerName = _playerFirstName + " " + _playerLastName;
                GameInformation.PlayerBio = _playerBio;
                if (_genderSelection == 0)
                {
                    GameInformation.IsMale = true;
                }
                else if (_genderSelection == 1)
                {
                    GameInformation.IsMale = false;
                }
                GameInformation.Gold = 100;
                SaveInformation.SaveAllInformation();
                Debug.Log("Make final save");
            }
        }

        //BACK BUTTON
        if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION)
        {
            if (GUI.Button(new Rect(840, 650, 50, 50), "Back"))
            {
                if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    statAllocationModule._didRunOnce = false;
                    GameInformation.PlayerClass = null;
                    statAllocationModule._availablePoints = 5;
                    CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION;
                }
                else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.FINALSETUP)
                {
                    CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
            }
        }
    }
}
