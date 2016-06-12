using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseItem{

    private string  _itemName;
    private string  _itemDescription;
    private int     _itemID;

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPONS,
        SCROLL,
        POTION,
        CHEST
    }

    private ItemTypes _itemType;

    public string ItemName          { get; set; }
    public string ItemDescription   { get; set; }
    public int ItemID               { get; set; }
    public ItemTypes ItemType       { get; set; }
}
