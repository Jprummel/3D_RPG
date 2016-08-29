using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateNewCharacter : MonoBehaviour {

    new BasePlayer  _newPlayer;
    private bool    _isWarriorClass;
    private bool    _isBerserkerClass;
    private bool    _isRogueClass;
    private bool    _isRangerClass;
    private bool    _isMageClass;
    private bool    _isNecromancerClass;
    private string  _playerName = "Enter Name"; //Textbox placeholder

    //Preview Models
    /*[SerializeField]private GameObject _warriorModel;
    [SerializeField]private GameObject _berserkerModel;
    [SerializeField]private GameObject _rogueModel;
    [SerializeField]private GameObject _rangerModel;
    [SerializeField]private GameObject _mageModel;
    [SerializeField]private GameObject _necromancerModel;*/

	void Start () {
	    _newPlayer = new BasePlayer();
	}

    void OnGUI()
    {
        _playerName = GUILayout.TextArea(_playerName,12);
        if (GUILayout.Toggle(_isWarriorClass, "Warrior"))
        {
            //Set Class
            _isWarriorClass     = true; 
            _isBerserkerClass   = false;
            _isRogueClass       = false;
            _isRangerClass      = false;
            _isMageClass        = false;
            _isNecromancerClass = false;

            //Activate Preview Model
            /*_warriorModel.SetActive     (true);
            _berserkerModel.SetActive   (false);
            _rogueModel.SetActive       (false);
            _rangerModel.SetActive      (false);
            _mageModel.SetActive        (false);
            _necromancerModel.SetActive (false);*/
        }
        if (GUILayout.Toggle(_isBerserkerClass, "Berserker"))
        {
            //Set Class
            _isWarriorClass     = false;
            _isBerserkerClass   = true;
            _isRogueClass       = false;
            _isRangerClass      = false;
            _isMageClass        = false;
            _isNecromancerClass = false;

            //Activate Preview Model
            /*_warriorModel.SetActive     (false);
            _berserkerModel.SetActive   (true);
            _rogueModel.SetActive       (false);
            _rangerModel.SetActive      (false);
            _mageModel.SetActive        (false);
            _necromancerModel.SetActive (false);*/
        }
        if (GUILayout.Toggle(_isRogueClass, "Rogue"))
        {
            //Set Class
            _isWarriorClass     = false;
            _isBerserkerClass   = false;
            _isRogueClass       = true;
            _isRangerClass      = false;
            _isMageClass        = false;
            _isNecromancerClass = false;

            //Activate Preview Model
            /*_warriorModel.SetActive     (false);
            _berserkerModel.SetActive   (false);
            _rogueModel.SetActive       (true);
            _rangerModel.SetActive      (false);
            _mageModel.SetActive        (false);
            _necromancerModel.SetActive (false);*/
        }
        if (GUILayout.Toggle(_isRangerClass, "Ranger"))
        {
            //Set Class
            _isWarriorClass     = false;
            _isBerserkerClass   = false;
            _isRogueClass       = false;
            _isRangerClass      = true;
            _isMageClass        = false;
            _isNecromancerClass = false;

            //Activate Preview Model
            /*_warriorModel.SetActive     (false);
            _berserkerModel.SetActive   (false);
            _rogueModel.SetActive       (false);
            _rangerModel.SetActive      (true);
            _mageModel.SetActive        (false);
            _necromancerModel.SetActive (false);*/
        }
        if (GUILayout.Toggle(_isMageClass, "Mage"))
        {
            //Set Class
            _isWarriorClass     = false;
            _isBerserkerClass   = false;
            _isRogueClass       = false;
            _isRangerClass      = false;
            _isMageClass        = true;
            _isNecromancerClass = false;

            //Activate Preview Model
            /*_warriorModel.SetActive     (false);
            _berserkerModel.SetActive   (false);
            _rogueModel.SetActive       (false);
            _rangerModel.SetActive      (false);
            _mageModel.SetActive        (true);
            _necromancerModel.SetActive (false);*/
        }
        if (GUILayout.Toggle(_isNecromancerClass, "Necromancer"))
        {
            //Set Class
            _isWarriorClass     = false;
            _isBerserkerClass   = false;
            _isRogueClass       = false;
            _isRangerClass      = false;
            _isMageClass        = false;
            _isNecromancerClass = true;
            
            //Activate Preview Model
            /*_warriorModel.SetActive     (false);
            _berserkerModel.SetActive   (false);
            _rogueModel.SetActive       (false);
            _rangerModel.SetActive      (false);
            _mageModel.SetActive        (false);
            _necromancerModel.SetActive (true);*/
        }

        if (GUILayout.Button("Create"))
        {
            if (_isWarriorClass)
            {
                _newPlayer.PlayerClass = new BaseWarriorClass();
            }else if (_isBerserkerClass)
            {
                _newPlayer.PlayerClass = new BaseBerserkerClass();
            }else if (_isRogueClass)
            {
                _newPlayer.PlayerClass = new BaseRogueClass();
            }else if (_isRangerClass)
            {
                _newPlayer.PlayerClass = new BaseRangerClass();
            }else if (_isMageClass)
            {
                _newPlayer.PlayerClass = new BaseMageClass();
            }else if (_isNecromancerClass)
            {
                _newPlayer.PlayerClass = new BaseNecromancerClass();
            }

            CreateNewPlayer();
            StoreNewPlayerInfo();
            SaveInformation.SaveAllInformation();           
        }
        if (GUILayout.Button("Load"))
        {
            SceneManager.LoadScene("Test");
        }
    }

    private void StoreNewPlayerInfo()
    {
        GameInformation.PlayerName  = _newPlayer.PlayerName;
        GameInformation.PlayerLevel = _newPlayer.PlayerLevel;
        GameInformation.PlayerClass = _newPlayer.PlayerClass;
        GameInformation.Strength    = _newPlayer.Strength;
        GameInformation.Stamina     = _newPlayer.Stamina;
        GameInformation.Spirit      = _newPlayer.Spirit;
        GameInformation.Intellect   = _newPlayer.Intellect;
        GameInformation.Overpower   = _newPlayer.Overpower;
        GameInformation.Luck        = _newPlayer.Luck;
        GameInformation.Gold        = _newPlayer.Gold;
    }

    void CreateNewPlayer()
    {
        _newPlayer.PlayerLevel  = 1;
        _newPlayer.Strength     = _newPlayer.PlayerClass.Strength;
        _newPlayer.Stamina      = _newPlayer.PlayerClass.Stamina;
        _newPlayer.Spirit       = _newPlayer.PlayerClass.Spirit;
        _newPlayer.Intellect    = _newPlayer.PlayerClass.Intellect;
        _newPlayer.Overpower    = _newPlayer.PlayerClass.Overpower;
        _newPlayer.Luck         = _newPlayer.PlayerClass.Luck;
        _newPlayer.Gold         = 100;
        _newPlayer.PlayerName   = _playerName;

        Debug.Log("Player Name : "          + _newPlayer.PlayerName);
        Debug.Log("Player Class : "         + _newPlayer.PlayerClass.CharacterClassName);
        Debug.Log("Class Description : "    + _newPlayer.PlayerClass.CharacterClassDescription);
        Debug.Log("Player Level : "         + _newPlayer.PlayerLevel);
        Debug.Log("Player Strength : "      + _newPlayer.Strength);
        Debug.Log("Player Stamina : "       + _newPlayer.Stamina);
        Debug.Log("Player Spirit : "        + _newPlayer.Spirit);
        Debug.Log("Player Intellect : "     + _newPlayer.Intellect);
        Debug.Log("Player Overpower : "     + _newPlayer.Overpower);
        Debug.Log("Player Luck : "          + _newPlayer.Luck);
        Debug.Log("Gold : "                 + _newPlayer.Gold);
    }
}
