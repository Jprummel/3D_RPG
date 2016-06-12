using UnityEngine;
using System.Collections;

public static class IncreaseExperience {

    private static int      _xpToGive;
    private static LevelUp  _levelUp = new LevelUp();

    public static void AddExperience()
    {
        _xpToGive = GameInformation.PlayerLevel * 100;
        GameInformation.CurrentXP += _xpToGive;
        CheckForLevelUp();
        Debug.Log(_xpToGive);
    }

    private static void CheckForLevelUp()
    {
        if (GameInformation.CurrentXP >= GameInformation.RequiredXP)
        {
            //Levels up character
            _levelUp.LevelUpCharacter();
            // Debug.Log(GameInformation.PlayerLevel);
        }
    }
}
