using UnityEngine;
using System.Collections;

public class AddAbilities : MonoBehaviour {

    public void AddAbilitiesOnLevelUp()
    {
        switch (GameInformation.PlayerClass.CharacterClass) 
        {
            case BaseCharacterClass.CharacterClasses.WARRIOR:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.BERSERKER:
                switch(GameInformation.PlayerLevel)
                {
                    case 2:
                        GameInformation.PlayerClass.PlayersSkills.Add(new Cripple());
                        break;
                    case 5:
                        GameInformation.PlayerClass.PlayersSkills.Add(new Rampage());
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.ROGUE:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.MAGE:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.CARDMASTER:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.MIME:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.PALADIN:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
            case BaseCharacterClass.CharacterClasses.SHAMAN:
                switch (GameInformation.PlayerLevel)
                {
                    case 3:
                        break;
                }
                break;
        }
    }
}
