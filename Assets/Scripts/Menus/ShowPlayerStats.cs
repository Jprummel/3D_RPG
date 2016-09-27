using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerStats : MonoBehaviour {

    private Party _party;
    [SerializeField]private Text    _playerStatNames;
    [SerializeField]private Text    _playerStats;
    [SerializeField]private Image   _xpBar;
    [SerializeField]private Text    _xpText;
    [SerializeField]private Text _goldAmount;

    void Start()
    {
        _party = GameObject.Find("PartyManager").GetComponent<Party>();
        _playerStatNames = _playerStatNames.GetComponent<Text>();
        _playerStats = _playerStats.GetComponent<Text>();
        _xpBar = _xpBar.GetComponent<Image>();
        _xpText = _xpText.GetComponent<Text>();
        _goldAmount = _goldAmount.GetComponent<Text>();
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

        _playerStats.text = _party.characters[0].Name + "\n" +
            _party.characters[0].Race.RaceName  + "\n" +
            _party.characters[0].Class.CharactersClassName +"\n" +
            _party.characters[0].Level + "\n" +
            _party.characters[0].Strength + "\n" +
            _party.characters[0].Stamina + "\n" +
            _party.characters[0].Spirit + "\n" +
            _party.characters[0].Intellect + "\n" +
            _party.characters[0].Overpower + "\n" +
            _party.characters[0].Luck + "\n" +
            _party.characters[0].Mastery + "\n" +
            _party.characters[0].Charisma + "\n" +
            _party.characters[0].Armor;
    }

    public void GoldAmount()
    {
        _goldAmount.text = PlayerInformation.Gold.ToString();
    }

    public void XPBar()
    {
        _xpBar.fillAmount = _party.characters[0].CurrentXP / _party.characters[0].RequiredXP;
        _xpText.text =(float) _party.characters[0].CurrentXP + " / " + _party.characters[0].RequiredXP + " XP";
    }
}
