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

        SaveData saveData           = new SaveData();
        //saveData.Party            = Party.partyMembers;
        saveData.isMale             = PlayerInformation.IsMale;
        saveData.charactersName     = PlayerInformation.CharactersName;
        saveData.charactersRace     = PlayerInformation.CharactersRace;
        saveData.charactersClass    = PlayerInformation.CharactersClass;
        saveData.charactersLevel    = PlayerInformation.CharactersLevel;
        saveData.charactersSkills   = PlayerInformation.CharactersSkills;
        saveData.charactersMagic    = PlayerInformation.CharactersMagic;
        saveData.strength           = PlayerInformation.Strength;
        saveData.stamina            = PlayerInformation.Stamina;
        saveData.spirit             = PlayerInformation.Spirit;
        saveData.intellect          = PlayerInformation.Intellect;
        saveData.overpower          = PlayerInformation.Overpower;
        saveData.luck               = PlayerInformation.Luck;
        saveData.armor              = PlayerInformation.Armor;
        saveData.mastery            = PlayerInformation.Mastery;
        saveData.charisma           = PlayerInformation.Charisma;
        saveData.currentXP          = PlayerInformation.CurrentXP;
        saveData.requiredXP         = PlayerInformation.RequiredXP;
        saveData.statPoints         = PlayerInformation.StatPoints;
        saveData.gold               = PlayerInformation.Gold;
        saveData.playerMapScene     = PlayerInformation.PlayerMapScene;
        //saveData.playerMapPos     = PlayerInformation.PlayerMapPos;
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
            PlayerInformation.IsMale            = saveData.isMale;
            PlayerInformation.CharactersName    = saveData.charactersName;
            PlayerInformation.CharactersRace    = saveData.charactersRace;
            PlayerInformation.CharactersClass   = saveData.charactersClass;
            PlayerInformation.CharactersLevel   = saveData.charactersLevel;
            PlayerInformation.CharactersSkills  = saveData.charactersSkills;
            PlayerInformation.CharactersMagic   = saveData.charactersMagic;
            PlayerInformation.Strength          = saveData.strength;
            PlayerInformation.Stamina           = saveData.stamina;
            PlayerInformation.Spirit            = saveData.spirit;
            PlayerInformation.Intellect         = saveData.intellect;
            PlayerInformation.Overpower         = saveData.overpower;
            PlayerInformation.Luck              = saveData.luck;
            PlayerInformation.Armor             = saveData.armor;
            PlayerInformation.Mastery           = saveData.mastery;
            PlayerInformation.Charisma          = saveData.charisma;
            PlayerInformation.CurrentXP         = saveData.currentXP;
            PlayerInformation.RequiredXP        = saveData.requiredXP;
            PlayerInformation.StatPoints        = saveData.statPoints;
            PlayerInformation.Gold              = saveData.gold;
            PlayerInformation.PlayerMapScene    = saveData.playerMapScene;
            //PlayerInformation.PlayerMapPos    = saveData.playerMapPos;
            file.Close();            
        }

        Debug.Log("Current XP "                         + PlayerInformation.CurrentXP);
        Debug.Log("Required XP "                        + PlayerInformation.RequiredXP);
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
