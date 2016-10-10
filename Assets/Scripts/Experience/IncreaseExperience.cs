using UnityEngine;
using System.Collections;

public class IncreaseExperience {

    private TurnBasedCombatStateMachine _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
    private Party _party = GameObject.Find(Tags.PARTYMANAGER).GetComponent<Party>();
    private static int      _xpToGive;
    private static LevelUp  _levelUp = new LevelUp();

    public void AddExperience()
    {
        foreach (BaseEnemy enemy in _tbs.enemiesKilled)
        {
            BaseEnemy killedEnemy = enemy;
            _xpToGive = killedEnemy.Level * 100;
            foreach (BaseCharacter character in _tbs.heroesInBattle)
            {
                BaseCharacter partyMember = character;
                partyMember.CurrentXP += _xpToGive;
                CheckForLevelUp();
                Debug.Log(partyMember.Name + " received " + _xpToGive + " XP");
            }
        }
        CheckForLevelUp();
        //Debug.Log(_xpToGive);
    }

    private void CheckForLevelUp()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            if (partyMember.CurrentXP >= partyMember.RequiredXP)
            {
                //Levels up character
                _levelUp.LevelUpCharacter();
                Debug.Log("Level Up! " + partyMember.Name + " is now level " + partyMember.Level);
            }
        }        
    }
}
