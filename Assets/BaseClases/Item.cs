using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID            { get; set; }
    public string ItemName   { get; set; }
    public string PluralName { get; set; }

    public Item (int id, string itemName, string pluralName)
    {
        ID = id;
        ItemName = itemName;
        PluralName = pluralName;
    }
}
