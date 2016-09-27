using UnityEngine;
using System.Collections;

public class EnemyAbilityChoice {

    private Party _party = GameObject.Find("PartyManager").GetComponent<Party>();
    private float     _totalCharactersHealth;
    private float   _CharactersHealthPercentage;
    private BaseAbility _chosenAbility;


    public BaseAbility ChooseEnemyAbility()
    {
        _totalCharactersHealth = _party.characters[0].Health;
        _CharactersHealthPercentage = (_totalCharactersHealth /100) * 100;

        if (_CharactersHealthPercentage >= 75)
        {
            return _chosenAbility = ChooseAbilityAtSeventyFivePercent();
        }
        else if (_CharactersHealthPercentage < 75 && _CharactersHealthPercentage >= 30)
        {
            return _chosenAbility = new AttackAbility();
        }
        else if (_CharactersHealthPercentage < 30 && _CharactersHealthPercentage >= 1)
        {
            return _chosenAbility = new AttackAbility();
        }
        return _chosenAbility = new AttackAbility();

    }

    private BaseAbility ChooseAbilityAtSeventyFivePercent()
    {
        //Can also check for stats or other things to decide on abilities
        return _chosenAbility = new AttackAbility();
    }
}
