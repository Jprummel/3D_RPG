using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassSelection : MonoBehaviour {

    [SerializeField]private List<Button>    _classSelectionButtons = new List<Button>();
    [SerializeField]private Text            _classDescription;
    [SerializeField]private Button          _nextButton;
    private List<BaseCharacterClass>        _playerClass = new List<BaseCharacterClass>();
    private string[]                        _classNames = new string[] { "Warrior", "Berserker", "Rogue", "Mage", "Card Master", "Mime", "Paladin", "Shaman" };
    private int                             _classSelection;

    private Text _className;

	void Start () 
    {
        _playerClass.Add(new BaseWarriorClass());
        _playerClass.Add(new BaseBerserkerClass());
        _playerClass.Add(new BaseRogueClass());
        _playerClass.Add(new BaseMageClass());
        _playerClass.Add(new BaseCardMasterClass());
	    _playerClass.Add(new BaseMimeClass());
        _playerClass.Add(new BasePaladinClass());
        _playerClass.Add(new BaseShamanClass());

        _classDescription = _classDescription.GetComponent<Text>();
        _nextButton.interactable = false;
        FindClassNames();
    }

    void FindClassNames()
    {
        BaseCharacterClass tempClass;
        for (int i = 0; i < _classSelectionButtons.Count; i++)
        {
            tempClass = _playerClass[i];
            _className = _classSelectionButtons[i].GetComponentInChildren<Text>();
            _className.text = tempClass.CharacterClassName;
        }
    }

    public void FindClassDescription(int classSelection)
    {
        BaseCharacterClass tempClass;
        _classSelection = classSelection;
        tempClass = _playerClass[_classSelection];
        _classDescription.text = tempClass.CharacterClassDescription;
        _nextButton.interactable = true;
    }

    public void ChooseClass()
    {
        BaseCharacterClass chosenClass;
        chosenClass = _playerClass[_classSelection];
        GameInformation.PlayerClass = chosenClass;
        Debug.Log(GameInformation.PlayerClass.CharacterClassName);
    }
}
