using UnityEngine;
using System.Collections;

public class AddAbilities{
    private Party _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();

    public void AddAbilitiesOnLevelUp()
    {
        switch (_party.characters[0].Class.CharactersClass) 
        {
            case BaseCharacterClass.CharactersClasses.WARRIOR:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.BERSERKER:
                switch(_party.characters[0].Level)
                {
                    case 2:
                        _party.characters[0].Class.CharactersSkills.Add(new Cripple());
                        break;
                    case 5:
                        _party.characters[0].Class.CharactersSkills.Add(new Rampage());
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.ROGUE:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.MAGE:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.CARDMASTER:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.MIME:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.PALADIN:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.SHAMAN:
                switch (_party.characters[0].Level)
                {
                    case 3:
                        break;
                }
                break;
        }
    }
}
