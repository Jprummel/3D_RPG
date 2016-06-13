using UnityEngine;
using System.Collections;

public class StatAllocationModule{

    private string[] _statNames         = new string[6]{"Strength","Stamina","Endurance","Intellect","Agility","Resistance"};
    private string[] _statDescriptions  = new string[6] { "Physical damage modifier", "Energy modifier", "Health modifier", "Magical damage modifier", "Haste and critical hit modifier", "All damage reduction" };
    private bool[] _statSelections      = new bool[6];
    public int[] pointsToAllocate     = new int[6];   //Starting stat values for the chosen class, 
    private int[] _baseStatPoints       = new int[6];     //Starting stat values for the chosen class

    public int _availablePoints = 5;
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
        pointsToAllocate[0]    = cClass.Strength;
        _baseStatPoints[0]      = cClass.Strength;
        pointsToAllocate[1]    = cClass.Stamina;
        _baseStatPoints[1]      = cClass.Stamina;
        pointsToAllocate[2]    = cClass.Endurance;
        _baseStatPoints[2]      = cClass.Endurance;
        pointsToAllocate[3]    = cClass.Intellect;
        _baseStatPoints[3]      = cClass.Intellect;
        pointsToAllocate[4]    = cClass.Agility;
        _baseStatPoints[4]      = cClass.Agility;
        pointsToAllocate[5]    = cClass.Resistance;
        _baseStatPoints[5]      = cClass.Resistance;
    }
}
