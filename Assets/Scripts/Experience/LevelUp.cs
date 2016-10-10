using UnityEngine;
using System.Collections;

public class LevelUp {

    private Party _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
    private TurnBasedCombatStateMachine _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
    private int _maxCharactersLevel = 50;
    private LevelUpStatPointAllocation _statPoints;
    private AddAbilities _addAbilities = new AddAbilities();

    public void LevelUpCharacter()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            //Check to see if current xp is greater then required
            if (partyMember.CurrentXP > partyMember.RequiredXP)
            {
                partyMember.CurrentXP -= partyMember.RequiredXP;
            }
            else
            {
                partyMember.CurrentXP = 0;
            }

            if (partyMember.Level < _maxCharactersLevel)
            {
                partyMember.Level += 1;
            }
            else
            {
                partyMember.Level = _maxCharactersLevel;
            }
            //Give player stat points
            partyMember.StatPoints += 3;
            //give them a skill/move
            _addAbilities.AddAbilitiesOnLevelUp();
            //determine next amount of required xp
            DetermineRequiredXP();
        }
    }

    private void DetermineRequiredXP()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            int temp = (partyMember.Level * 1000) + 250;
            partyMember.RequiredXP = temp;
        }
    }
}
