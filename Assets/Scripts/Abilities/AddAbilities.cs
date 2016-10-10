using UnityEngine;
using System.Collections;

public class AddAbilities{
    private Party _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
    private TurnBasedCombatStateMachine _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();

    public void AddAbilitiesOnLevelUp()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;

            switch (partyMember.Class.CharactersClass)
            {
                case BaseCharacterClass.CharactersClasses.WARRIOR:
                    switch (partyMember.Level)
                    {
                        case 3:
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.BERSERKER:
                    switch (partyMember.Level)
                    {
                        case 2:
                            partyMember.Skills.Add(new Cripple());
                            Debug.Log("Cripple added");
                            break;
                        case 5:
                            partyMember.Skills.Add(new Rampage());
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.ROGUE:
                    switch (partyMember.Level)
                    {
                        case 3:
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.MAGE:
                    switch (partyMember.Level)
                    {
                        case 2:
                            Debug.Log("Added fire to " + partyMember.Name);
                            partyMember.Skills.Add(new Fire());
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.CARDMASTER:
                    switch (partyMember.Level)
                    {
                        case 3:
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.MIME:
                    switch (partyMember.Level)
                    {
                        case 3:
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.PALADIN:
                    switch (partyMember.Level)
                    {
                        case 3:
                            break;
                    }
                    break;
                case BaseCharacterClass.CharactersClasses.SHAMAN:
                    switch (partyMember.Level)
                    {
                        case 3:
                            break;
                    }
                    break;
            }
        }
    }
}
