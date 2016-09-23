using UnityEngine;
using System.Collections;

public class LevelUp {

    private int _maxCharactersLevel = 50;
    private LevelUpStatPointAllocation _statPoints;
    private AddAbilities _addAbilities = new AddAbilities();

    public void LevelUpCharacter()
    {
        
        //Check to see if current xp is greater then required
        if (PlayerInformation.CurrentXP > PlayerInformation.RequiredXP)
        {
            PlayerInformation.CurrentXP -= PlayerInformation.RequiredXP;
        }
        else
        {
            PlayerInformation.CurrentXP = 0;
        }

        if (PlayerInformation.CharactersLevel < _maxCharactersLevel)
        {
            PlayerInformation.CharactersLevel += 1;
        }
        else
        {
            PlayerInformation.CharactersLevel = _maxCharactersLevel;
        }
        //Give player stat points
        PlayerInformation.StatPoints += 3;
        //randomly give items
        //give them a skill/move
        _addAbilities.AddAbilitiesOnLevelUp();
        //give money
       
        //determine next amount of required xp
        DetermineRequiredXP();
    }

    private void DetermineRequiredXP()
    {
        int temp = (PlayerInformation.CharactersLevel * 1000) + 250;
        PlayerInformation.RequiredXP = temp;
    }

    private void DetermineMoneyToGive()
    {
        //give a certain amount of money
        if (PlayerInformation.CharactersLevel <= 10)
        {
            PlayerInformation.Gold += 500;
        }
    }

}
