using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveLoadGame : MonoBehaviour
{
    public void SaveGame()
    {
        BinaryFormatter bf  = new BinaryFormatter();
        FileStream file     = File.Create(Application.persistentDataPath + "/SaveDataSlot.dat");

        SaveData saveData       = new SaveData();
        saveData.isMale         = GameInformation.IsMale;
        saveData.playerBio      = GameInformation.PlayerBio;
        saveData.playerName     = GameInformation.PlayerName;
        saveData.playerRace     = GameInformation.PlayerRace;
        saveData.playerClass    = GameInformation.PlayerClass;
        saveData.playerLevel    = GameInformation.PlayerLevel;
        saveData.playerSkills   = GameInformation.PlayersSkills;
        saveData.playerMagic    = GameInformation.PlayersMagic;
        saveData.strength       = GameInformation.Strength;
        saveData.stamina        = GameInformation.Stamina;
        saveData.spirit         = GameInformation.Spirit;
        saveData.intellect      = GameInformation.Intellect;
        saveData.overpower      = GameInformation.Overpower;
        saveData.luck           = GameInformation.Luck;
        saveData.armor          = GameInformation.Armor;
        saveData.mastery        = GameInformation.Mastery;
        saveData.charisma       = GameInformation.Charisma;
        saveData.currentXP      = GameInformation.CurrentXP;
        saveData.requiredXP     = GameInformation.RequiredXP;
        saveData.statPoints     = GameInformation.StatPoints;
        saveData.gold           = GameInformation.Gold;
        saveData.playerMapScene = GameInformation.PlayerMapScene;
        //saveData.playerMapPos   = GameInformation.PlayerMapPos;
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
            GameInformation.IsMale          = saveData.isMale;
            GameInformation.PlayerBio       = saveData.playerBio;
            GameInformation.PlayerName      = saveData.playerName;
            GameInformation.PlayerRace      = saveData.playerRace;
            GameInformation.PlayerClass     = saveData.playerClass;
            GameInformation.PlayerLevel     = saveData.playerLevel;

            GameInformation.PlayersSkills   = saveData.playerSkills;
            GameInformation.Strength        = saveData.strength;
            GameInformation.Stamina         = saveData.stamina;
            GameInformation.Spirit          = saveData.spirit;
            GameInformation.Intellect       = saveData.intellect;
            GameInformation.Overpower       = saveData.overpower;
            GameInformation.Luck            = saveData.luck;
            GameInformation.Armor           = saveData.armor;
            GameInformation.Mastery         = saveData.mastery;
            GameInformation.Charisma        = saveData.charisma;
            GameInformation.CurrentXP       = saveData.currentXP;
            GameInformation.RequiredXP      = saveData.requiredXP;
            GameInformation.StatPoints      = saveData.statPoints;
            GameInformation.Gold            = saveData.gold;
            GameInformation.PlayerMapScene  = saveData.playerMapScene;
            //GameInformation.PlayerMapPos    = saveData.playerMapPos;
            file.Close();            
        }
        Debug.Log("It's "                               + GameInformation.IsMale + " that I'm a guy");
        Debug.Log("You want to hear my story? okay.. "  + GameInformation.PlayerBio);
        Debug.Log("My name is "                         + GameInformation.PlayerName);
        Debug.Log("I am a "                             + GameInformation.PlayerRace.RaceName + " " + GameInformation.PlayerClass.CharacterClassName);
        Debug.Log("I'm level "                          + GameInformation.PlayerLevel);
        Debug.Log("Strength "                           + GameInformation.Strength);
        Debug.Log("Stamina "                            + GameInformation.Stamina);
        Debug.Log("Spirit "                             + GameInformation.Spirit);
        Debug.Log("Intellect "                          + GameInformation.Intellect);
        Debug.Log("Overpower "                          + GameInformation.Overpower);
        Debug.Log("Luck "                               + GameInformation.Luck);
        Debug.Log("Armor "                              + GameInformation.Armor);
        Debug.Log("Mastery "                            + GameInformation.Mastery);
        Debug.Log("Charisma "                           + GameInformation.Charisma);
        Debug.Log("Current XP "                         + GameInformation.CurrentXP);
        Debug.Log("Required XP "                        + GameInformation.RequiredXP);
        Debug.Log("Gold "                               + GameInformation.Gold);
        //SceneManager.LoadScene(GameInformation.PlayerMapScene);
        SceneManager.LoadScene("MovementTest");
    }


    [System.Serializable]
    public class SaveData
    {
        public bool                 isMale;
        public string               playerBio;
        public string               playerName;
        public BaseCharacterRace    playerRace;
        public BaseCharacterClass   playerClass;
        public int                  playerLevel;
        public List<BaseAbility>    playerSkills;
        public List<BaseAbility>    playerMagic;
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
