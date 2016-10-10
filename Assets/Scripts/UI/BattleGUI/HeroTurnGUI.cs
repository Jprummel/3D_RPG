using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroTurnGUI : MonoBehaviour {

    private TurnBasedCombatStateMachine _tbs;

    [SerializeField]private GameObject  _playerActionMenu;
    [SerializeField]private GameObject  _skillPanel;
    [SerializeField]private GameObject  _magicPanel;
    [SerializeField]private GameObject  _targetPanel;
    [SerializeField]private Button      _abilityButton;
    private List<int> _skillIndex = new List<int>();
    private List<int> _magicIndex = new List<int>();

	// Use this for initialization
	void Start () {
        _tbs = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();
        GetCharacterSkills();
        GetCharacterMagic();
	}
	
	// Update is called once per frame
	void Update () {
        ShowPlayerPanels();
	}

    void ShowPlayerPanels()
    {
        if (TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            _playerActionMenu.SetActive(true);
        }
        else
        {
            _playerActionMenu.SetActive(false);
            _skillPanel.SetActive(false);
            _magicPanel.SetActive(false);
            _targetPanel.SetActive(false);
        }
    }

    void GetCharacterSkills()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            List<int> partyMemberSkills = new List<int>();
            for (int i = 0; i < partyMember.Skills.Count; i++)
            {
                _skillIndex.Add(i); //Adds a int to the list for every skill the player has
            }

            foreach (int skill in _skillIndex)
            {
                if (skill == 0)
                {
                    continue; //skips 0 in the list because that is always the basic attack and that has its own button
                }

                Button newSkillButton = Instantiate(_abilityButton);
                newSkillButton.name = partyMember.Skills[skill].AbilityName;
                Text skillName = newSkillButton.GetComponentInChildren<Text>();
                skillName.text = partyMember.Skills[skill].AbilityName;
                newSkillButton.transform.SetParent(_skillPanel.transform);
                int skillToUse = skill;
                UseSkill(newSkillButton, skillToUse);
            }
        }
    }

    void UseSkill(Button button, int value)
    {
        button.onClick.AddListener(() =>
        {
            foreach (BaseCharacter character in _tbs.heroesInBattle)
            {
                BaseCharacter partyMember = character;

                TurnBasedCombatStateMachine.playerUsedAbility = partyMember.Skills[value];
                _targetPanel.SetActive(true);
                //TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
            }
        });
    }

    void GetCharacterMagic()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            for (int i = 0; i < partyMember.Magic.Count; i++)
            {
                _magicIndex.Add(i); //Adds a int to the list for every skill the player has
            }

            foreach (int magic in _magicIndex)
            {
                Button newMagicButton = Instantiate(_abilityButton);
                newMagicButton.name = partyMember.Magic[magic].AbilityName;
                Text skillName = newMagicButton.GetComponentInChildren<Text>();
                skillName.text = partyMember.Magic[magic].AbilityName;
                newMagicButton.transform.SetParent(_skillPanel.transform);
                int magicToUse = magic;
                UseMagic(newMagicButton, magicToUse);
            }
        }
    }

    void UseMagic(Button button, int value)
    {
        button.onClick.AddListener(() =>
        {
            foreach (BaseCharacter character in _tbs.heroesInBattle)
            {
                BaseCharacter partyMember = character;

                TurnBasedCombatStateMachine.playerUsedAbility = partyMember.Magic[value];
                Debug.Log("clicked");
                _targetPanel.SetActive(true);
                //TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECTS;
            }
        });
    }

    public void BasicAttack()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;

            TurnBasedCombatStateMachine.playerUsedAbility = partyMember.Skills[0];
            _playerActionMenu.SetActive(false);
            _targetPanel.SetActive(true);
        }
    }
}
