using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerStats : MonoBehaviour {

    [SerializeField]private Text    _playerStatNames;
    [SerializeField]private Text    _playerStats;
    [SerializeField]private Image   _xpBar;
    [SerializeField]private Text    _xpText;
    [SerializeField]private Text _goldAmount;

    void Start()
    {
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

        _playerStats.text = PlayerInformation.CharactersName + "\n" +
            PlayerInformation.CharactersRace.RaceName  + "\n" +
            PlayerInformation.CharactersClass.CharactersClassName +"\n" +
            PlayerInformation.CharactersLevel + "\n" +
            PlayerInformation.Strength + "\n" +
            PlayerInformation.Stamina + "\n" +
            PlayerInformation.Spirit + "\n" +
            PlayerInformation.Intellect + "\n" +
            PlayerInformation.Overpower + "\n" +
            PlayerInformation.Luck + "\n" +
            PlayerInformation.Mastery + "\n" +
            PlayerInformation.Charisma + "\n" +
            PlayerInformation.Armor;
    }

    public void GoldAmount()
    {

    }

    public void XPBar()
    {
        _xpBar.fillAmount = PlayerInformation.CurrentXP / PlayerInformation.RequiredXP;
        _xpText.text =(float) PlayerInformation.CurrentXP + " / " + PlayerInformation.RequiredXP + " XP";
    }
}
