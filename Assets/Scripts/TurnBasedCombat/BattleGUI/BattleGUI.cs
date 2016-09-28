using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class BattleGUI : MonoBehaviour {

    private Party _party;
    /*//Player info
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
    private Image _enemyEnergyImage;*/
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
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
        GetPlayerSkills();
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
    }

    void GetPlayerSkills()
    {    
        for (int i = 0; i < _party.characters[0].Class.CharactersSkills.Count; i++)
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
            newSkillButton.name = _party.characters[0].Class.CharactersSkills[skill].AbilityName;
            Text skillName = newSkillButton.GetComponentInChildren<Text>();
            skillName.text = _party.characters[0].Class.CharactersSkills[skill].AbilityName;
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
            TurnBasedCombatStateMachine.playerUsedAbility = _party.characters[0].Class.CharactersSkills[value];
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS; 
        });
    }

    void GetPlayerMagic()
    {
        for (int i = 0; i < _party.characters[0].Class.CharactersMagic.Count; i++)
        {
            _magicIndex.Add(i); //Adds a int to the list for every skill the player has
        }

        foreach (int magic in _magicIndex)
        {
            Button newMagicButton = Instantiate(_skillButton);
            newMagicButton.name = _party.characters[0].Class.CharactersMagic[magic].AbilityName;
            Text skillName = newMagicButton.GetComponentInChildren<Text>();
            skillName.text = _party.characters[0].Class.CharactersMagic[magic].AbilityName;
            newMagicButton.transform.SetParent(_skillPanel.transform);
            int magicToUse = magic;
            UseMagic(newMagicButton, magicToUse);
        }
    }
    
    void UseMagic(Button button, int value)
    {
        button.onClick.AddListener(() =>
        {
            TurnBasedCombatStateMachine.playerUsedAbility = _party.characters[0].Class.CharactersMagic[value];
            Debug.Log("clicked");
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
        });
    }

    public void BasicAttack()
    {
        TurnBasedCombatStateMachine.playerUsedAbility = _party.characters[0].Class.CharactersSkills[0];
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
    }

    public void ShowSkillInfo(Button button, int value)
    {
        _skillTooltip.text = _party.characters[0].Class.CharactersSkills[value].AbilityDescription;
    }
}
