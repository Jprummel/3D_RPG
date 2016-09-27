using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveLoadGame : MonoBehaviour
{
    private Party _party;

    void Awake()
    {
        _party = GameObject.Find("PartyManager").GetComponent<Party>();
    }

    public void SaveGame()
    {
        BinaryFormatter bf  = new BinaryFormatter();
        FileStream file     = File.Create(Application.persistentDataPath + "/SaveDataSlot.dat");

        SaveData saveData           = new SaveData();
        //saveData.Party              = _party.characters;
        saveData.isMale             = _party.characters[0].IsMale;
        saveData.charactersName     = _party.characters[0].Name;
        saveData.charactersRace     = _party.characters[0].Race;
        saveData.charactersClass    = _party.characters[0].Class;
        saveData.charactersLevel    = _party.characters[0].Level;
        saveData.charactersSkills   = _party.characters[0].Skills;
        saveData.charactersMagic    = _party.characters[0].Magic;
        saveData.strength           = _party.characters[0].Strength;
        saveData.stamina            = _party.characters[0].Stamina;
        saveData.spirit             = _party.characters[0].Spirit;
        saveData.intellect          = _party.characters[0].Intellect;
        saveData.overpower          = _party.characters[0].Overpower;
        saveData.luck               = _party.characters[0].Luck;
        saveData.armor              = _party.characters[0].Armor;
        saveData.mastery            = _party.characters[0].Mastery;
        saveData.charisma           = _party.characters[0].Charisma;
        saveData.currentXP          = _party.characters[0].CurrentXP;
        saveData.requiredXP         = _party.characters[0].RequiredXP;
        saveData.statPoints         = _party.characters[0].StatPoints;
        saveData.gold               = PlayerInformation.Gold;
        saveData.playerMapScene     = PlayerInformation.PlayerMapScene;
        //saveData.playerMapPos     = _party.characters[0].PlayerMapPos;
        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log(Application.persistentDataPath);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveDataSlot.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveDataSlot.dat", FileMode.Open);

            SaveData saveData               = (SaveData)bf.Deserialize(file);
            //Party.partyMembers = saveData.Party;
            _party.characters[0].IsMale            = saveData.isMale;
            _party.characters[0].Name    = saveData.charactersName;
            _party.characters[0].Race    = saveData.charactersRace;
            _party.characters[0].Class   = saveData.charactersClass;
            _party.characters[0].Level   = saveData.charactersLevel;
            _party.characters[0].Skills  = saveData.charactersSkills;
            _party.characters[0].Magic   = saveData.charactersMagic;
            _party.characters[0].Strength          = saveData.strength;
            _party.characters[0].Stamina           = saveData.stamina;
            _party.characters[0].Spirit            = saveData.spirit;
            _party.characters[0].Intellect         = saveData.intellect;
            _party.characters[0].Overpower         = saveData.overpower;
            _party.characters[0].Luck              = saveData.luck;
            _party.characters[0].Armor             = saveData.armor;
            _party.characters[0].Mastery           = saveData.mastery;
            _party.characters[0].Charisma          = saveData.charisma;
            _party.characters[0].CurrentXP         = saveData.currentXP;
            _party.characters[0].RequiredXP        = saveData.requiredXP;
            _party.characters[0].StatPoints        = saveData.statPoints;
            PlayerInformation.Gold              = saveData.gold;
            PlayerInformation.PlayerMapScene    = saveData.playerMapScene;
            //_party.characters[0].PlayerMapPos    = saveData.playerMapPos;
            file.Close();            
        }

        Debug.Log("Current XP "                         + _party.characters[0].CurrentXP);
        Debug.Log("Required XP "                        + _party.characters[0].RequiredXP);
        Debug.Log("Gold "                               + PlayerInformation.Gold);
        SceneManager.LoadScene("MovementTest");
    }


    [System.Serializable]
    public class SaveData
    {
        //public List<BaseCharacter>  Party;
        public bool                 isMale;
        public string               playerBio;
        public string               charactersName;
        public BaseCharacterRace    charactersRace;
        public BaseCharacterClass   charactersClass;
        public int                  charactersLevel;
        public List<BaseAbility>    charactersSkills;
        public List<BaseAbility>    charactersMagic;
        public int                  strength;
        public int                  stamina;
        public int                  spirit;
        public int                  intellect;
        public int                  overpower;
        public int                  luck;
        public int                  armor;
        public int                  mastery;
        public int                  charisma;
        public float                currentXP;
        public float                requiredXP;
        public int                  statPoints;
        public int                  gold;
        public string               playerMapScene;
        //public Vector3              playerMapPos;
    }
}
