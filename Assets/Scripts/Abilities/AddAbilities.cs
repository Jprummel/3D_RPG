using UnityEngine;
using System.Collections;

public class AddAbilities : MonoBehaviour {

    public void AddAbilitiesOnLevelUp()
    {
        switch (PlayerInformation.CharactersClass.CharactersClass) 
        {
            case BaseCharacterClass.CharactersClasses.WARRIOR:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.BERSERKER:
                switch(PlayerInformation.CharactersLevel)
                {
                    case 2:
                        PlayerInformation.CharactersClass.CharactersSkills.Add(new Cripple());
                        break;
                    case 5:
                        PlayerInformation.CharactersClass.CharactersSkills.Add(new Rampage());
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.ROGUE:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.MAGE:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.CARDMASTER:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.MIME:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.PALADIN:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharactersClasses.SHAMAN:
                switch (PlayerInformation.CharactersLevel)
                {
                    case 3:
                        break;
                }
                break;
        }
    }
}
