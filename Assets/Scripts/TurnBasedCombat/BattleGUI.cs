using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BattleGUI : MonoBehaviour {

    private Party _party;
    //Player info
    private Text    _CharactersName;
    private Text    _CharactersHealth;
    private Text    _CharactersMana;
    private Text    _abilityOneName;
    private Image   _CharactersHealthImage;
    private Image   _CharactersManaImage;
    private int     _CharactersLevel;

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
        _CharactersName         = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Name").GetComponent<Text>();
        _CharactersName.text    = PlayerInformation.CharactersName;
        _CharactersHealth       = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Health").GetComponent<Text>();
        _CharactersMana         = transform.FindChild("BattlePanel/PartyPanel/PartyMember1/PartyMember1Mana").GetComponent<Text>();
        //_CharactersHealthImage  = transform.FindChild("PlayerInfoContainer/CharactersHealthBar").GetComponent<Image>();
        //_CharactersManaImage  = transform.FindChild("PlayerInfoContainer/CharactersManaBar").GetComponent<Image>();
        _CharactersLevel        = PlayerInformation.CharactersLevel;

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
        //_CharactersName.text = _party.PartyMembers(0).charactersName;
        _CharactersName.text                = PlayerInformation.CharactersName;
        _CharactersHealth.text              = PlayerInformation.CharactersHealth.ToString() + "/" + PlayerInformation.CharactersMaxHealth.ToString();
        //_CharactersHealthImage.fillAmount   = PlayerInformation.CharactersHealth / PlayerInformation.CharactersMaxHealth;
        _CharactersMana.text              = PlayerInformation.CharactersMana.ToString() + "/" + PlayerInformation.CharactersMaxMana.ToString();
        //_CharactersManaImage.fillAmount   = PlayerInformation.CharactersMana / PlayerInformation.CharactersMaxMana;
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
        for (int i = 0; i < PlayerInformation.CharactersClass.CharactersSkills.Count; i++)
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
            newSkillButton.name = PlayerInformation.CharactersClass.CharactersSkills[skill].AbilityName;
            Text skillName = newSkillButton.GetComponentInChildren<Text>();
            skillName.text = PlayerInformation.CharactersClass.CharactersSkills[skill].AbilityName;
            newSkillButton.transform.SetParent(_skillPanel.transform);
            int skillToUse = skill;
            ShowSkillInfo(newSkillButton, skillToUse);
            UseSkill(newSkillButton, skillToUse);
        }
    }

    void UseSkill(Button button,int value)
    {
        button.onClick.AddListener(() => 
        { 
            TurnBasedCombatStateMachine.playerUsedAbility = PlayerInformation.CharactersClass.CharactersSkills[value];
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS; 
        });
    }

    void GetPlayerMagic()
    {
        for (int i = 0; i < PlayerInformation.CharactersClass.CharactersMagic.Count; i++)
        {
            _magicIndex.Add(i); //Adds a int to the list for every skill the player has
        }

        foreach (int magic in _magicIndex)
        {
            Button newMagicButton = Instantiate(_skillButton);
            newMagicButton.name = PlayerInformation.CharactersClass.CharactersMagic[magic].AbilityName;
            Text skillName = newMagicButton.GetComponentInChildren<Text>();
            skillName.text = PlayerInformation.CharactersClass.CharactersMagic[magic].AbilityName;
            newMagicButton.transform.SetParent(_skillPanel.transform);
            int magicToUse = magic;
            UseMagic(newMagicButton, magicToUse);
        }
    }
    
    void UseMagic(Button button, int value)
    {
        button.onClick.AddListener(() =>
        {
            TurnBasedCombatStateMachine.playerUsedAbility = PlayerInformation.CharactersClass.CharactersMagic[value];
            Debug.Log("clicked");
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        });
    }

    public void BasicAttack()
    {
        TurnBasedCombatStateMachine.playerUsedAbility = PlayerInformation.CharactersClass.CharactersSkills[0];
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
    }

    public void ShowSkillInfo(Button button, int value)
    {
        _skillTooltip.text = PlayerInformation.CharactersClass.CharactersSkills[value].AbilityDescription;
    }
}
