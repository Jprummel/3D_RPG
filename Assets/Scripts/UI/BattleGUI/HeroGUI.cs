using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroGUI : MonoBehaviour 
{
    //This class shows the name, vital stats(HP/MP) and the level of each hero in battle in the GUI

    private TurnBasedCombatStateMachine _tbs;
    //Action Menu
    [SerializeField]private List<Button> _actionButtons = new List<Button>();
    [SerializeField]private GameObject _playerActionMenu;
    private Text _actionName;    
    private int _abilityUsed;

    //Skill panels and button
    [SerializeField]private GameObject  _skillPanel;
    [SerializeField]private GameObject  _magicPanel;

    //Target panel
    [SerializeField]private GameObject _targetPanel;

	void Start () 
    {
        _tbs    = GameObject.FindGameObjectWithTag(Tags.BATTLEMANAGER).GetComponent<TurnBasedCombatStateMachine>();

	}
	
	void Update () 
    {
        //PlayerInfo();
        CharacterVitals();
        ShowPlayerPanels();
	}

    void PlayerInfo()
    {
        //maxhealth / 100 = 1 % 
        //_CharactersHealth.text  = "HP : " + _party.characters[0].Health.ToString() + "/" + _party.characters[0].MaxHealth.ToString();
        //_CharactersMana.text    = "MP : " + _party.characters[0].Mana.ToString() + "/" + _party.characters[0].MaxMana.ToString();
        ShowPlayerPanels();
    }

    void CharacterVitals()
    {
        foreach (BaseCharacter character in _tbs.heroesInBattle)
        {
            BaseCharacter partyMember = character;
            //_CharactersHealth.text = "HP : " + partyMember.Health.ToString()+"/"+ partyMember.MaxHealth.ToString();
            //_CharactersMana.text = "MP : " + partyMember.Mana.ToString() + "/" + partyMember.MaxMana.ToString();
        }
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
}
