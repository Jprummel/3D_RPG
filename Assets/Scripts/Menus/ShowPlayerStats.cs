using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerStats : MonoBehaviour {

    private Party _party;
    [SerializeField]private Text    _playerStatNames;
    [SerializeField]private Text    _playerStats;
    [SerializeField]private Image   _xpBar;
    [SerializeField]private Text    _xpText;
    [SerializeField]private Text    _goldAmount;
    private int _characterIndex;

    void Start()
    {
        _party = GameObject.FindGameObjectWithTag(Tags.PARTYMANAGER).GetComponent<Party>();
        _playerStatNames = _playerStatNames.GetComponent<Text>();
        _playerStats = _playerStats.GetComponent<Text>();
        _xpBar = _xpBar.GetComponent<Image>();
        _xpText = _xpText.GetComponent<Text>();
        _goldAmount = _goldAmount.GetComponent<Text>();
        //_characterIndex = 0;
    }

    void Update()
    {
        PlayerStats();
        XPBar();
        GoldAmount();
    }

    public void PlayerStats()
    {
        // \t = tab \n = new line i used multiple \t's to line out the text
        _playerStatNames.text   =   "Name"      + "\n" +
                                    "Race"      + "\n" +
                                    "Class"     + "\n" +
                                    "Level"     + "\n" +
                                    "Strength"  + "\n" +
                                    "Stamina"   + "\n" +
                                    "Spirit "   + "\n" +
                                    "Intellect" + "\n" +
                                    "Overpower" + "\n" +
                                    "Luck "     + "\n" +
                                    "Mastery"   + "\n" +
                                    "Charisma"  + "\n" +
                                    "Armor"     + "\n";

        _playerStats.text = _party.characters[_characterIndex].Name + "\n" +
        _party.characters[_characterIndex].Race.RaceName + "\n" +
        _party.characters[_characterIndex].Class.CharactersClassName + "\n" +
        _party.characters[_characterIndex].Level + "\n" +
        _party.characters[_characterIndex].Strength + "\n" +
        _party.characters[_characterIndex].Stamina + "\n" +
        _party.characters[_characterIndex].Spirit + "\n" +
        _party.characters[_characterIndex].Intellect + "\n" +
        _party.characters[_characterIndex].Overpower + "\n" +
        _party.characters[_characterIndex].Luck + "\n" +
        _party.characters[_characterIndex].Mastery + "\n" +
        _party.characters[_characterIndex].Charisma + "\n" +
        _party.characters[_characterIndex].Armor;
    }

    public void NextCharacter()
    {
        if (_characterIndex <= _party.characters.Count -2)
        {
            Debug.Log("Showing " + _characterIndex + " out of " + _party.characters.Count);
            _characterIndex += 1;
        }
        else if(_characterIndex >= _party.characters.Count-2)
        {
            Debug.Log("Whyyyyy");
            _characterIndex = 0;
        }
    }

    public void PreviousCharacter()
    {
        if (_characterIndex == 0)
        {
            _characterIndex = _party.characters.Count;
        }
        else
        {
            _characterIndex -= 1;
        }
    }

    public void GoldAmount()
    {
        _goldAmount.text = PlayerInformation.Gold.ToString();
    }

    public void XPBar()
    {
        _xpBar.fillAmount   = _party.characters[_characterIndex].CurrentXP / _party.characters[_characterIndex].RequiredXP;
        _xpText.text        = (float) _party.characters[_characterIndex].CurrentXP + " / " + _party.characters[_characterIndex].RequiredXP + " XP";
    }
}
