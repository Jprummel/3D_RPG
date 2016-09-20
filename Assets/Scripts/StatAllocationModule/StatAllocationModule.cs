using UnityEngine;
using System.Collections;

public class StatAllocationModule{

    private string  [] _statNames           = new string[8]{"Strength","Stamina","Spirit","Intellect","Overpower","Luck","Mastery","Charisma"};
    private string  [] _statDescriptions    = new string[8] { "Physical damage modifier", "Health modifier", "Energy Source modifier", "Magical damage modifier", "Critical strike chance", "Extra/better loot chance", "Chance for bonus damage","How people see you, increases sell prices and decreases buy prices" };
    private bool    [] _statSelections      = new bool[8];
    public int      [] pointsToAllocate     = new int[8];       //Points to put in stats chosen by the player 
    private int     [] _baseStatPoints      = new int[8];       //Starting stat values for the chosen class

    public int  _availablePoints = 5;
    public bool _didRunOnce = false;


    public void DisplayStatAllocationModule()
    {
        if (!_didRunOnce)
        {
            RetrieveStatBaseStatPoints();
            _didRunOnce = true;
        }
        DisplayStatToggleSwitches();
        DisplayStatIncreaseDecreaseButtons();
    }

    void DisplayStatToggleSwitches()
    {
        for (int i = 0; i < _statNames.Length; i++)
        {
            _statSelections[i] = GUI.Toggle(new Rect(10, 60 * i + 10, 100, 50), _statSelections[i], _statNames[i]);
            GUI.Label(new Rect(100, 60 * i + 10, 50, 50), pointsToAllocate[i].ToString());
            if (_statSelections[i])
            {
                GUI.Label(new Rect(20, 60*i + 30, 150, 100), _statDescriptions[i]);
            }
        }
    }

    void DisplayStatIncreaseDecreaseButtons()
    {
        for (int i = 0; i < pointsToAllocate.Length; i++)
        {
            if (pointsToAllocate[i] >= _baseStatPoints[i] && _availablePoints > 0)
            {
                if (GUI.Button(new Rect(200, 60 * i + 10, 50, 50), "+"))
                {
                    pointsToAllocate[i] += 1;
                    --_availablePoints;
                }
            }
            if (pointsToAllocate[i] > _baseStatPoints[i])
            {
                if (GUI.Button(new Rect(260, 60 * i + 10, 50, 50), "-"))
                {
                    pointsToAllocate[i] -= 1;
                    ++_availablePoints;
                }
            }
        }
    }

    void RetrieveStatBaseStatPoints()
    {
        BaseCharacterClass cClass = GameInformation.PlayerClass;
        pointsToAllocate[0]     = cClass.Strength;
        _baseStatPoints[0]      = cClass.Strength;
        pointsToAllocate[1]     = cClass.Stamina;
        _baseStatPoints[1]      = cClass.Stamina;
        pointsToAllocate[2]     = cClass.Spirit;
        _baseStatPoints[2]      = cClass.Spirit;
        pointsToAllocate[3]     = cClass.Intellect;
        _baseStatPoints[3]      = cClass.Intellect;
        pointsToAllocate[4]     = cClass.Overpower;
        _baseStatPoints[4]      = cClass.Overpower;
        pointsToAllocate[5]     = cClass.Luck;
        _baseStatPoints[5]      = cClass.Luck;
        pointsToAllocate[6]     = cClass.Mastery;
        _baseStatPoints[6]      = cClass.Mastery;
        pointsToAllocate[7]     = cClass.Charisma;
        _baseStatPoints[7]      = cClass.Charisma;
    }
}
