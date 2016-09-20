using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BattleGUI : MonoBehaviour {
    
    //Player info
    private Text    _playerName;
    private Text    _playerHealth;
    private Text    _playerEnergy;
    private Text    _abilityOneName;
    private Image   _playerHealthImage;
    private Image   _playerEnergyImage;
    private int     _playerLevel;

    //Enemy info
    private Text _enemyName;
    private Text _enemyHealth;
    private Text _enemyEnergy;
    private Image _enemyHealthImage;
    private Image _enemyEnergyImage;
    //Action Menu
    [SerializeField]private List<Button> _actionButtons = new List<Button>();
    private Text _actionName;
    [SerializeField]private GameObject _playerActionMenu;
    private int _abilityUsed;

    [SerializeField]private Text _skillTooltip;
    //Skill panels and buttons
    [SerializeField]private GameObject _skillPanel;
    [SerializeField]private GameObject _magicPanel;
    [SerializeField]private Button _skillButton;
    private List<int> _skillIndex = new List<int>();
    private List<int> _magicIndex = new List<int>();
    
   

    void Start()
    {
        GetPlayerSkills();
        
        
       
        //Gets player info components
        _playerName         = transform.FindChild("PlayerInfoContainer/PlayerPortrait/PlayerName").GetComponent<Text>();
        _playerName.text    = GameInformation.PlayerName;
        _playerHealth       = transform.FindChild("PlayerInfoContainer/PlayerHealthBar/PlayerHealthValue").GetComponent<Text>();
        _playerEnergy       = transform.FindChild("PlayerInfoContainer/PlayerEnergyBar/PlayerEnergyValue").GetComponent<Text>();
        _playerHealthImage  = transform.FindChild("PlayerInfoContainer/PlayerHealthBar").GetComponent<Image>();
        _playerEnergyImage  = transform.FindChild("PlayerInfoContainer/PlayerEnergyBar").GetComponent<Image>();
        _playerLevel        = GameInformation.PlayerLevel;

        //Gets enemy info components
        _enemyName          = transform.FindChild("EnemyInfoContainer/EnemyPortrait/EnemyName").GetComponent<Text>();
        _enemyName.text     = EnemyInformation.EnemyName;
        _enemyHealth        = transform.FindChild("EnemyInfoContainer/EnemyHealthBar/EnemyHealthValue").GetComponent<Text>();
        _enemyEnergy        = transform.FindChild("EnemyInfoContainer/EnemyEnergyBar/EnemyEnergyValue").GetComponent<Text>();
        _enemyHealthImage   = transform.FindChild("EnemyInfoContainer/EnemyHealthBar").GetComponent<Image>();
        _enemyEnergyImage   = transform.FindChild("EnemyInfoContainer/EnemyEnergyBar").GetComponent<Image>();
    }

    void Update()
    {
        if (TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            _playerActionMenu.SetActive(true);
        }
        else
        {
            _playerActionMenu.SetActive(false);
        }
        PlayerInfo();
        EnemyInfo();
        //UseSkill();
    }

    void PlayerInfo()
    {
        //maxhealth / 100 = 1 % 
        _playerName.text                = GameInformation.PlayerName;
        _playerHealth.text              = GameInformation.PlayerHealth.ToString() + "/" + GameInformation.PlayerMaxHealth.ToString();
        _playerHealthImage.fillAmount   = GameInformation.PlayerHealth / GameInformation.PlayerMaxHealth;
        _playerEnergy.text              = GameInformation.PlayerEnergy.ToString() + "/" + GameInformation.PlayerMaxEnergy.ToString();
        _playerEnergyImage.fillAmount   = GameInformation.PlayerEnergy / GameInformation.PlayerMaxEnergy;
    }

    void EnemyInfo()
    {
        _enemyName.text                 = EnemyInformation.EnemyName;
        _enemyHealth.text               = EnemyInformation.EnemyHealth.ToString() + "/" + EnemyInformation.EnemyMaxHealth.ToString();
        _enemyHealthImage.fillAmount    = EnemyInformation.EnemyHealth / EnemyInformation.EnemyMaxHealth;
        _enemyEnergy.text               = EnemyInformation.EnemyEnergy.ToString() + "/" + EnemyInformation.EnemyMaxEnergy.ToString();
        _enemyEnergyImage.fillAmount    = EnemyInformation.EnemyEnergy / 100;
    }

    void GetPlayerSkills()
    {    
        for (int i = 0; i < GameInformation.PlayerClass.PlayersSkills.Count; i++)
        {
            _skillIndex.Add(i); //Adds a int to the list for every skill the player has
        }

        foreach (int skill in _skillIndex)
        {
            if (skill == 0)
            {
                continue; //skips 0 in the list because that is always the basic attack and that has its own button
            }

            Button newSkillButton = Instantiate(_skillButton);
            newSkillButton.name = GameInformation.PlayerClass.PlayersSkills[skill].AbilityName;
            Text skillName = newSkillButton.GetComponentInChildren<Text>();
            skillName.text = GameInformation.PlayerClass.PlayersSkills[skill].AbilityName;
            newSkillButton.transform.SetParent(_skillPanel.transform);
            int skillToUse = skill;
            UseSkill(newSkillButton, skillToUse);
        }
    }

    void UseSkill(Button button,int value)
    {
        button.onClick.AddListener(() => 
        { 
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.PlayerClass.PlayersSkills[value]; 
            Debug.Log("clicked"); 
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS; 
        });
    }

    void GetPlayerMagic()
    {
        for (int i = 0; i < GameInformation.PlayerClass.PlayerMagic.Count; i++)
        {
            _magicIndex.Add(i); //Adds a int to the list for every skill the player has
        }

        foreach (int magic in _magicIndex)
        {
            if (magic == 0)
            {
                continue; //skips 0 in the list because that is always the basic attack and that has its own button
            }

            Button newMagicButton = Instantiate(_skillButton);
            newMagicButton.name = GameInformation.PlayerClass.PlayerMagic[magic].AbilityName;
            Text skillName = newMagicButton.GetComponentInChildren<Text>();
            skillName.text = GameInformation.PlayerClass.PlayerMagic[magic].AbilityName;
            newMagicButton.transform.SetParent(_skillPanel.transform);
            int magicToUse = magic;
            UseMagic(newMagicButton, magicToUse);
        }
    }
    
    void UseMagic(Button button, int value)
    {
        button.onClick.AddListener(() =>
        {
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.PlayerClass.PlayerMagic[value];
            Debug.Log("clicked");
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        });
    }

    public void BasicAttack()
    {
        TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.PlayerClass.PlayersSkills[0];
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
    }

    public void UseSkill(int index)
    {
        Debug.Log(index + "Used" );
            TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.PlayerClass.PlayersSkills[index];
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        
        //Debug.Log(TurnBasedCombatStateMachine.playerUsedAbility);
    }

    public void ShowSkillInfo()
    {
        //_skillTooltip.text = GameInformation.PlayerClass.PlayersSkills[].AbilityDescription;
    }
}
