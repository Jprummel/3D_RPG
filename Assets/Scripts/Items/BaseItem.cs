using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseItem{

    private string  _itemName;
    private string  _itemDescription;
    private int     _itemID;
    private int     _strength;
    private int     _stamina;
    private int     _spirit;
    private int     _intellect;
    private int     _overpower;
    private int     _luck;
    private int     _mastery;
    private int     _charisma;

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPONS,
        SCROLL,
        POTION,
        CHEST
    }

    private ItemTypes _itemType;

    public BaseItem() { }

    public BaseItem(Dictionary<string,string> itemsDictionary)
    {
        _itemName   = itemsDictionary["ItemName"]; //Gets name
        _itemID     = int.Parse(itemsDictionary["ItemID"]); // Parse ID
        _itemType   = (ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), itemsDictionary["ItemType"].ToString()); // Gets ItemType
        Debug.Log(_itemName);
    }

    public string       ItemName        { get; set; }
    public string       ItemDescription { get; set; }
    public int          ItemID          { get; set; }
    public ItemTypes    ItemType        { get; set; }
    
    //Stats
    public int Strength                 { get; set; }
    public int Stamina                  { get; set; }
    public int Spirit                   { get; set; }
    public int Intellect                { get; set; }
    public int Overpower                { get; set; }
    public int Luck                     { get; set; }
    public int Mastery                  { get; set; }
    public int Charisma                 { get; set; }
}
