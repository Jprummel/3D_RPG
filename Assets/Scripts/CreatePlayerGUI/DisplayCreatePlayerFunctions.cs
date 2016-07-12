using UnityEngine;
using System.Collections;

public class DisplayCreatePlayerFunctions{

    private StatAllocationModule statAllocationModule = new StatAllocationModule();
    private int         _raceSelection;
    private string[]    _raceSelectionNames     = new string[] {"Barbarian","Dwarf","Gnome","Elf","Dark Elf","Human","Troll","Skeleton","Ogre","Elemental Golem","Material Golem" };
    private int         _classSelection;
    private string[]    _classSelectionNames    = new string[] {"Warrior", "Berserker","Rogue","Ranger","Mage","Necromancer","Card Master","Druid","Mime","Shadowknight","Alchemist","Paladin","Shaman","Monk"};
    private string      _playerFirstName        = "Enter first name";   //player first name
    private string      _playerLastName         = "Enter last name";    //player last name
    private string      _playerBio              = "Enter player bio";   //bio
    //Gender
    private int _genderSelection;
    private string[] _genderTypes               = new string[2] { "Male", "Female" };

    public void DisplayRaceSelections()
    {
        _raceSelection = GUI.SelectionGrid(new Rect(50, 50, 350, 300), _raceSelection, _raceSelectionNames, 3);
        GUI.Label(new Rect(450, 50, 300, 300), FindRaceDescription(_raceSelection));
    }

    public string FindRaceDescription(int raceSelection)
    {
        BaseCharacterRace tempRace;

        switch (raceSelection)
        {
            case 0:
                tempRace = new BaseBarbarianRace();
                break;
            case 1:
                tempRace = new BaseDwarfRace();
                break;
            case 2:
                tempRace = new BaseGnomeRace();
                break;
            case 3:
                tempRace = new BaseElfRace();
                break;
            case 4:
                tempRace = new BaseDarkElfRace();
                break;
            case 5:
                tempRace = new BaseHumanRace();
                break;
            case 6:
                tempRace = new BaseTrollRace();
                break;
            case 7:
                tempRace = new BaseSkeletonRace();
                break;
            case 8:
                tempRace = new BaseOgreRace();
                break;
            case 9:
                tempRace = new BaseElementalGolemRace();
                break;
            case 10:
                tempRace = new BaseMaterialGolemRace();
                break;
            default:
               return "No race selected";
        }
        return tempRace.RaceDescription;;
    }

    public void DisplayClassSelections()
    {
        //A list of toggle buttons for classes each button is a different class
        //selection grid
        _classSelection = GUI.SelectionGrid(new Rect(50,50,250,300), _classSelection, _classSelectionNames,2);
        GUI.Label(new Rect(450, 50, 300, 300),FindClassDescription(_classSelection));
        GUI.Label(new Rect(450, 150, 300, 300), FindClassStatValues(_classSelection));
    }

    private string FindClassDescription(int classSelection)
    {
        BaseCharacterClass tempClass;

        switch (classSelection)
        {
            case 0:
            tempClass = new BaseWarriorClass();
            return tempClass.CharacterClassDescription;
            case 1:
            tempClass = new BaseBerserkerClass();
            return tempClass.CharacterClassDescription;
            case 2:
            tempClass = new BaseRogueClass();
            return tempClass.CharacterClassDescription;
            case 3:
            tempClass = new BaseRangerClass();
            return tempClass.CharacterClassDescription;
            case 4:
            tempClass = new BaseMageClass();
            return tempClass.CharacterClassDescription;
            case 5:
            tempClass = new BaseNecromancerClass();
            return tempClass.CharacterClassDescription;
            case 6:
            tempClass = new BaseCardMasterClass();
            return tempClass.CharacterClassDescription;
            case 7:
            tempClass = new BaseDruidClass();
            return tempClass.CharacterClassDescription;
            case 8:
            tempClass = new BaseMimeClass();
            return tempClass.CharacterClassDescription;
            case 9:
            tempClass = new BaseShadowknightClass();
            return tempClass.CharacterClassDescription;
            case 10:
            tempClass = new BaseAlchemistClass();
            return tempClass.CharacterClassDescription;
            case 11:
            tempClass = new BasePaladinClass();
            return tempClass.CharacterClassDescription;
            case 12:
            tempClass = new BaseShamanClass();
            return tempClass.CharacterClassDescription;
            case 13:
            tempClass = new BaseMonkClass();
            return tempClass.CharacterClassDescription;
        }
       
        return "No class selected";
    }

    private string FindClassStatValues(int classSelection)
    {
        BaseCharacterClass tempClass;

        switch (classSelection)
        {
            case 0:
                tempClass = new BaseWarriorClass();
                break;
            case 1:
                tempClass = new BaseBerserkerClass();
                break;
            case 2:
                tempClass = new BaseRogueClass();
                break;
            case 3:
                tempClass = new BaseRangerClass();
                break; 
            case 4:
                tempClass = new BaseMageClass();
                break;
            case 5:
                tempClass = new BaseNecromancerClass();
                break;
            case 6:
                tempClass = new BaseCardMasterClass();
                break;
            case 7:
                tempClass = new BaseDruidClass();
                break;
            case 8:
                tempClass = new BaseMimeClass();
                break;
            case 9:
                tempClass = new BaseShadowknightClass();
                break;
            case 10:
                tempClass = new BaseAlchemistClass();
                break;
            case 11:
                tempClass = new BasePaladinClass();
                break;
            case 12:
                tempClass = new BaseShamanClass();
                break;
            case 13:
                tempClass = new BaseMonkClass();
                break;
            default:
                return "No stats to show";
        }

        string tempStats = "Strength " + tempClass.Strength + "\n" +
                            "Stamina " + tempClass.Stamina + "\n" +
                            "Spirit " + tempClass.Spirit + "\n" +
                            "Intellect " + tempClass.Intellect + "\n" +
                            "Armor " + tempClass.Armor + "\n" +
                            "Overpower " + tempClass.Overpower + "\n" +
                            "Luck " + tempClass.Luck + "\n" +
                            "Mastery " + tempClass.Mastery + "\n" +
                            "Charisma " + tempClass.Charisma;
        return tempStats;
    }

    public void DisplayStatAllocation()
    {
        //a list of stats with plus and minus buttons to add stats
        //logic to make sure the player cannot add more than stat points given
        statAllocationModule.DisplayStatAllocationModule();
        GUI.Label(new Rect(20, Screen.height/2 +150, 150, 100),"Stat points available " + statAllocationModule._availablePoints.ToString());
    }

    public void DisplayFinalSetup()
    {
        //name
        _playerFirstName    = GUI.TextArea(new Rect(20,10,150,25), _playerFirstName,25);
        _playerLastName     = GUI.TextArea(new Rect(20, 55, 150, 25), _playerLastName, 25);
       
        //gender
        _genderSelection    = GUI.SelectionGrid(new Rect(200,10,100,70), _genderSelection,_genderTypes,1);
        //add a description to your character (short bio)
        _playerBio          = GUI.TextArea(new Rect(20, 90, 250, 200), _playerBio, 250);
    }

    void ChooseRace(int raceSelection)
    {
        //Choose the players race
        switch (raceSelection)
        {
            case 0:
                GameInformation.PlayerRace = new BaseBarbarianRace();
                break;
            case 1:
                GameInformation.PlayerRace = new BaseDwarfRace();
                break;
            case 2:
                GameInformation.PlayerRace = new BaseGnomeRace();
                break;
            case 3:
                GameInformation.PlayerRace = new BaseElfRace();
                break;
            case 4:
                GameInformation.PlayerRace = new BaseDarkElfRace();
                break;
            case 5:
                GameInformation.PlayerRace = new BaseHumanRace();
                break;
            case 6:
                GameInformation.PlayerRace = new BaseTrollRace();
                break;
            case 7:
                GameInformation.PlayerRace = new BaseSkeletonRace();
                break;
            case 8:
                GameInformation.PlayerRace = new BaseOgreRace();
                break;
            case 9:
                GameInformation.PlayerRace = new BaseElementalGolemRace();
                break;
            case 10:
                GameInformation.PlayerRace = new BaseMaterialGolemRace();
                break;
        }
    }

    void ChooseClass(int classSelection)
    {
        //Choose the players
        switch (classSelection)
        {
            case 0:
                GameInformation.PlayerClass = new BaseWarriorClass();
                break;
            case 1:
                GameInformation.PlayerClass = new BaseBerserkerClass();
                break;
            case 2:
                GameInformation.PlayerClass = new BaseRogueClass();
                break;
            case 3:
                GameInformation.PlayerClass = new BaseRangerClass();
                break;
            case 4:
                GameInformation.PlayerClass = new BaseMageClass();
                break;
            case 5:
                GameInformation.PlayerClass = new BaseNecromancerClass();
                break;
            case 6:
                GameInformation.PlayerClass = new BaseCardMasterClass();
                break;
            case 7:
                GameInformation.PlayerClass = new BaseDruidClass();
                break;
            case 8:
                GameInformation.PlayerClass = new BaseMimeClass();
                break;
            case 9:
                GameInformation.PlayerClass = new BaseShadowknightClass();
                break;
            case 10:
                GameInformation.PlayerClass = new BaseAlchemistClass();
                break;
            case 11:
                GameInformation.PlayerClass = new BasePaladinClass();
                break;
            case 12:
                GameInformation.PlayerClass = new BaseShamanClass();
                break;
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
                if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.RACESELECTION)
                {
                    ChooseRace(_raceSelection);
                    CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION;
                }
                else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION)
                {
                    ChooseClass(_classSelection);
                    CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
                else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    GameInformation.Strength    = statAllocationModule.pointsToAllocate[0];
                    GameInformation.Stamina     = statAllocationModule.pointsToAllocate[1];
                    GameInformation.Spirit      = statAllocationModule.pointsToAllocate[2];
                    GameInformation.Intellect   = statAllocationModule.pointsToAllocate[3];
                    GameInformation.Overpower   = statAllocationModule.pointsToAllocate[4];
                    GameInformation.Luck        = statAllocationModule.pointsToAllocate[5];
                    GameInformation.Mastery     = statAllocationModule.pointsToAllocate[6];
                    GameInformation.Charisma    = statAllocationModule.pointsToAllocate[7];
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
                GameInformation.PlayerName  = _playerFirstName + " " + _playerLastName;
                GameInformation.PlayerBio   = _playerBio;
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
        if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreateAPlayerStates.RACESELECTION)
        {
            if (GUI.Button(new Rect(840, 650, 50, 50), "Back"))
            {
                if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION)
                {
                    GameInformation.PlayerRace      = null;
                    CreatePlayerGUI.currentState    = CreatePlayerGUI.CreateAPlayerStates.RACESELECTION;
                }
                else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    statAllocationModule._didRunOnce        = false;
                    GameInformation.PlayerClass             = null;
                    statAllocationModule._availablePoints   = 5;
                    CreatePlayerGUI.currentState            = CreatePlayerGUI.CreateAPlayerStates.CLASSSELECTION;
                }
                else if (CreatePlayerGUI.currentState == CreatePlayerGUI.CreateAPlayerStates.FINALSETUP)
                {
                    CreatePlayerGUI.currentState = CreatePlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
            }
        }
    }
}
