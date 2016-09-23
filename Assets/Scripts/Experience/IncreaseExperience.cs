using UnityEngine;
using System.Collections;

public static class IncreaseExperience {

    private static int      _xpToGive;
    private static LevelUp  _levelUp = new LevelUp();

    public static void AddExperience()
    {
        _xpToGive = EnemyInformation.EnemyLevel * 100;
        PlayerInformation.CurrentXP += _xpToGive;
        CheckForLevelUp();
        Debug.Log(_xpToGive);
    }

    private static void CheckForLevelUp()
    {
        if (PlayerInformation.CurrentXP >= PlayerInformation.RequiredXP)
        {
            //Levels up character
            _levelUp.LevelUpCharacter();
            Debug.Log("Level Up! " + PlayerInformation.CharactersName + " is now level " + PlayerInformation.CharactersLevel);
            // Debug.Log(PlayerInformation.CharactersLevel);
        }
    }
}
