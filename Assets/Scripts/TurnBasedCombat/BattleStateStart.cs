using UnityEngine;
using System.Collections;

public class BattleStateStart{

	public  BasePlayer _newEnemy                = new BasePlayer();
    private StatCalculations _statCalculationsScript  = new StatCalculations();
    private BaseCharacterClass[] _classTypes    = new BaseCharacterClass[] { new BaseWarriorClass(), new BaseBerserkerClass(), new BaseRogueClass(), new BaseRangerClass(), new BaseMageClass(), new BaseNecromancerClass(), new BaseCardMasterClass(), new BaseDruidClass(), new BaseMimeClass(), new BaseShadowknightClass(), new BaseAlchemistClass(), new BasePaladinClass(), new BaseShamanClass(), new BaseMonkClass() };
    private string[] _enemyNames = new string[] {"An old man", "Soldier", "Knight", "Commander", "Game Creator" };

    private int _playerStamina;
    private int _playerSpirit;
    private int _playerHealth;
    private int _playerEnergy;

    public void PrepareBattle()
    {
        //Create enemy
        CreateNewEnemy();
        //find out players vitals (stat calcs)
        DeterminePlayerVitals();
        //choose who goes first based on luck
        ChooseWhoGoesFirst();
    }

    private void CreateNewEnemy()
    {
        _newEnemy.PlayerName    = _enemyNames   [Random.Range(0,_enemyNames.Length)];
        _newEnemy.PlayerLevel   = Random.Range  (GameInformation.PlayerLevel - 2, GameInformation.PlayerLevel + 2);
        _newEnemy.PlayerClass   = _classTypes   [Random.Range(0, _classTypes.Length)];
        _newEnemy.Strength      = _statCalculationsScript.CalculateStat(_newEnemy.Strength  , StatCalculations.StatType.STRENGTH    , _newEnemy.PlayerLevel, true);
        _newEnemy.Stamina       = _statCalculationsScript.CalculateStat(_newEnemy.Stamina   , StatCalculations.StatType.STAMINA     , _newEnemy.PlayerLevel, true);
        _newEnemy.Spirit        = _statCalculationsScript.CalculateStat(_newEnemy.Spirit    , StatCalculations.StatType.SPIRIT      , _newEnemy.PlayerLevel, true);
        _newEnemy.Intellect     = _statCalculationsScript.CalculateStat(_newEnemy.Intellect , StatCalculations.StatType.INTELLECT   , _newEnemy.PlayerLevel, true);
        _newEnemy.Overpower     = _statCalculationsScript.CalculateStat(_newEnemy.Overpower , StatCalculations.StatType.OVERPOWER   , _newEnemy.PlayerLevel, true);
        _newEnemy.Luck          = _statCalculationsScript.CalculateStat(_newEnemy.Luck      , StatCalculations.StatType.LUCK        , _newEnemy.PlayerLevel, true);
        _newEnemy.Mastery       = _statCalculationsScript.CalculateStat(_newEnemy.Mastery   , StatCalculations.StatType.MASTERY     , _newEnemy.PlayerLevel, true);
        _newEnemy.Charisma      = _statCalculationsScript.CalculateStat(_newEnemy.Charisma  , StatCalculations.StatType.CHARISMA    , _newEnemy.PlayerLevel, true);
    }

    private void ChooseWhoGoesFirst()
    {
        if (GameInformation.Luck > _newEnemy.Luck)
        {
            //Player goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
        }
        if (GameInformation.Luck < _newEnemy.Luck)
        {
            //Enemy goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
        }
        if (GameInformation.Luck == _newEnemy.Luck)
        {
            float randomTurnChecker = Random.Range(0, 1);
            if (randomTurnChecker >= 0.5f)
            {
                //Player goes first
                TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
            }
            /*else if (randomTurnChecker < 0.5f)
            {
                //Enemy goes first
                TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
            }*/
        }
    }

    private void DeterminePlayerVitals()
    {
        GameInformation.PlayerClass = new BaseWarriorClass();
        GameInformation.Strength = GameInformation.PlayerClass.Strength;
        GameInformation.Stamina = GameInformation.PlayerClass.Stamina;
        _playerStamina                  = _statCalculationsScript.CalculateStat(GameInformation.Stamina , StatCalculations.StatType.STAMINA , GameInformation.PlayerLevel, false);
        _playerSpirit                   = _statCalculationsScript.CalculateStat(GameInformation.Spirit  , StatCalculations.StatType.SPIRIT  , GameInformation.PlayerLevel, false);
        _playerHealth                   = _statCalculationsScript.CalculateHealth(_playerStamina);
        _playerEnergy                   = _statCalculationsScript.CalculateEnergy(_playerSpirit);
        GameInformation.PlayerHealth    = _playerHealth;
        GameInformation.PlayerEnergy    = _playerEnergy;
    }
}
