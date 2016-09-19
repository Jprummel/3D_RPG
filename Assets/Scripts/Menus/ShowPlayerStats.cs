using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerStats : MonoBehaviour {

    [SerializeField]private Text    _playerStatNames;
    [SerializeField]private Text    _playerStats;
    [SerializeField]private Image   _xpBar;
    [SerializeField]private Text    _xpText;

    void Start()
    {
        _playerStatNames = _playerStatNames.GetComponent<Text>();
        _playerStats = _playerStats.GetComponent<Text>();
        _xpBar = _xpBar.GetComponent<Image>();
        _xpText = _xpText.GetComponent<Text>();
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

        _playerStats.text = GameInformation.PlayerName + "\n" +
            GameInformation.PlayerRace.RaceName  + "\n" +
            GameInformation.PlayerClass.CharacterClassName +"\n" +
            GameInformation.PlayerLevel + "\n" +
            GameInformation.Strength + "\n" +
            GameInformation.Stamina + "\n" +
            GameInformation.Spirit + "\n" +
            GameInformation.Intellect + "\n" +
            GameInformation.Overpower + "\n" +
            GameInformation.Luck + "\n" +
            GameInformation.Mastery + "\n" +
            GameInformation.Charisma + "\n" +
            GameInformation.Armor;
    }

    public void XPBar()
    {
        _xpBar.fillAmount = GameInformation.CurrentXP / GameInformation.RequiredXP;
        _xpText.text =(float) GameInformation.CurrentXP + " / " + GameInformation.RequiredXP + " XP";
    }
}
