using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadGame : MonoBehaviour
{
    [SerializeField]private int _gold;
    [SerializeField]private int _saveSlot;
    public int Gold
    {
        get { return _gold; }
    }

    public void SaveResource()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveDataSlot" + _saveSlot +".dat");

        SaveData saveData = new SaveData();
        saveData.gold = _gold;

        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log(Application.persistentDataPath);
    }

    public void LoadResource()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveDataSlot" + _saveSlot + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveDataSlot"+_saveSlot+".dat", FileMode.Open);

            SaveData saveData = (SaveData)bf.Deserialize(file);
            _gold = saveData.gold;
            file.Close();
        }
        Debug.Log("Resources Loaded");
    }


    [System.Serializable]
    public class SaveData
    {
        public int gold;
    }
}
