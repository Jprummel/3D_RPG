using UnityEngine;
using System.Collections;

public class LevelUp {

    private Party _party = GameObject.Find("PartyManager").GetComponent<Party>();
    private int _maxCharactersLevel = 50;
    private LevelUpStatPointAllocation _statPoints;
    private AddAbilities _addAbilities = new AddAbilities();

    public void LevelUpCharacter()
    {
        
        //Check to see if current xp is greater then required
        if (_party.characters[0].CurrentXP > _party.characters[0].RequiredXP)
        {
            _party.characters[0].CurrentXP -= _party.characters[0].RequiredXP;
        }
        else
        {
            _party.characters[0].CurrentXP = 0;
        }

        if (_party.characters[0].Level < _maxCharactersLevel)
        {
            _party.characters[0].Level += 1;
        }
        else
        {
            _party.characters[0].Level = _maxCharactersLevel;
        }
        //Give player stat points
        _party.characters[0].StatPoints += 3;
        //randomly give items
        //give them a skill/move
        _addAbilities.AddAbilitiesOnLevelUp();
        //give money
       
        //determine next amount of required xp
        DetermineRequiredXP();
    }

    private void DetermineRequiredXP()
    {
        int temp = (_party.characters[0].Level * 1000) + 250;
        _party.characters[0].RequiredXP = temp;
    }

    private void DetermineMoneyToGive()
    {
        //give a certain amount of money
        if (_party.characters[0].Level <= 10)
        {
            PlayerInformation.Gold += 500;
        }
    }

}
