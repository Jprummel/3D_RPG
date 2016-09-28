using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassSelection : MonoBehaviour {

    private Party _party;
    [SerializeField]private List<Button>    _classSelectionButtons = new List<Button>();
    [SerializeField]private Text            _classDescription;
    [SerializeField]private Button          _nextButton;
    private List<BaseCharacterClass>        _CharactersClass = new List<BaseCharacterClass>();
    private int                             _classSelection;

    private Text _className;

	void Start () 
    {
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
        _CharactersClass.Add(new BaseWarriorClass());
        _CharactersClass.Add(new BaseBerserkerClass());
        _CharactersClass.Add(new BaseRogueClass());
        _CharactersClass.Add(new BaseMageClass());
        _CharactersClass.Add(new BaseCardMasterClass());
	    _CharactersClass.Add(new BaseMimeClass());
        _CharactersClass.Add(new BasePaladinClass());
        _CharactersClass.Add(new BaseShamanClass());

        _classDescription = _classDescription.GetComponent<Text>();
        _nextButton.interactable = false;
        FindClassNames();
    }

    void FindClassNames()
    {
        BaseCharacterClass tempClass;
        for (int i = 0; i < _classSelectionButtons.Count; i++)
        {
            tempClass = _CharactersClass[i];
            _className = _classSelectionButtons[i].GetComponentInChildren<Text>();
            _className.text = tempClass.CharactersClassName;
        }
    }

    public void FindClassDescription(int classSelection)
    {
        BaseCharacterClass tempClass;
        _classSelection = classSelection;
        tempClass = _CharactersClass[_classSelection];
        _classDescription.text = tempClass.CharactersClassDescription;
        _nextButton.interactable = true;
    }

    public void ChooseClass()
    {
        BaseCharacterClass chosenClass;
        chosenClass = _CharactersClass[_classSelection];
        _party.characters[0].Class = chosenClass;
        Debug.Log(_party.characters[0].Class.CharactersClassName);
    }
}
