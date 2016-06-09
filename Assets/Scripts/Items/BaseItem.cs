using UnityEngine;
using System.Collections;

public class BaseItem{

    private string _itemName;
    private string _itemDescription;
    private int _itemID;

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPONS,
        SCROLL,
        POTION,
        CHEST
    }

    private ItemTypes _itemType;

    public string ItemName
    {
        get { return _itemName; }
        set { _itemName = value;}
    }

    public string ItemDescription
    {
        get { return _itemDescription; }
        set { _itemDescription = value; }
    }

    public int ItemID
    {
        get { return _itemID; }
        set { _itemID = value; }
    }

    public ItemTypes ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }
}
