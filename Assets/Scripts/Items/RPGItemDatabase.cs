using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class RPGItemDatabase : MonoBehaviour {

    public TextAsset itemInventory; //Reads the XML File
    public static List<BaseItem> inventoryItems = new List<BaseItem>();

    private List<Dictionary<string, string>> _inventoryItemsDictionary = new List<Dictionary<string, string>>();
    private Dictionary<string, string> _inventoryDictionary;

    void Awake()
    {
        ReadItemsFromDatabase();
        for (int i = 0; i < _inventoryItemsDictionary.Count; i++)
        {
            inventoryItems.Add(new BaseItem(_inventoryItemsDictionary[i]));
        }
    }

    public void ReadItemsFromDatabase()
    {

        //Create and load XML Document
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(itemInventory.text);
        //Creates a list
        XmlNodeList itemList = xmlDocument.GetElementsByTagName("Item"); //Gets object with tag Item in XML File

        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            _inventoryDictionary = new Dictionary<string, string>(); //ItemName : TestItem

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ItemName":
                        _inventoryDictionary.Add("ItemName", content.InnerText);
                        break;
                    case "ItemID":
                        _inventoryDictionary.Add("ItemID", content.InnerText);
                        break;
                    case "ItemType":
                        _inventoryDictionary.Add("ItemType", content.InnerText);
                        break;
                }
            }

            _inventoryItemsDictionary.Add(_inventoryDictionary);
        }
    }
}
