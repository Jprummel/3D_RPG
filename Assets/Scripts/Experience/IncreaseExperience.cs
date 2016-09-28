using UnityEngine;
using System.Collections;

public class IncreaseExperience {

    private Party _party = GameObject.Find(Tags.PARTYMANAGER).GetComponent<Party>();
    private static int      _xpToGive;
    private static LevelUp  _levelUp = new LevelUp();

    public void AddExperience()
    {
        _xpToGive = EnemyInformation.EnemyLevel * 100;
        _party.characters[0].CurrentXP += _xpToGive;
        CheckForLevelUp();
        Debug.Log(_xpToGive);
    }

    private void CheckForLevelUp()
    {
        if (_party.characters[0].CurrentXP >= _party.characters[0].RequiredXP)
        {
            //Levels up character
            _levelUp.LevelUpCharacter();
            Debug.Log("Level Up! " + _party.characters[0].Name + " is now level " + _party.characters[0].Level);
            // Debug.Log(PlayerInformation.CharactersLevel);
        }
    }
}
