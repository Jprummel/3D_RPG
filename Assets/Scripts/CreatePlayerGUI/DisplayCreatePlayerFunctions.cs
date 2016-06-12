using UnityEngine;
using System.Collections;

public class DisplayCreatePlayerFunctions{

    private StatAllocationModule statAllocationModule = new StatAllocationModule();
    private int _classSelection;
    private string[] _classSelectionNames = new string[] {"Warrior", "Berserker", "Rogue","Ranger","Mage","Necromancer"};
    
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
    }

    public void DisplayFinalSetup()
    {
        //name
        //gender
        //add a description to your character (short bio)
    }

    public void DisplayMainItems()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GUI.Label(new Rect(Screen.width /2 , 20,250,250), "CREATE NEW PLAYER");

        if (GUI.Button(new Rect(700, 500, 50, 50), "<<<"))
        {
            //turn transform tagged as player to the left
            player.Rotate(Vector3.up * 100 * Time.deltaTime);
        }
        if (GUI.Button(new Rect(800, 500, 50, 50), ">>>"))
        {
            //turn transform tagged as player to the right
            player.Rotate(Vector3.down * 100 * Time.deltaTime);
        }
    }
}
