using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    public void Start()
    {
        items.Add(new Item("Stick", 0, "Wooden Sticks that usually fall off of trees", 2, 1, Item.ItemType.Resource, 10));
        items.Add(new Item("Rock", 1, "Small pebbles that are usually found scattered around, or from stones", 2, 1, Item.ItemType.Resource, 10));
        items.Add(new Item("Stone Axe", 2, "Sturdy axe made from a rock and a stick", 5, 2, Item.ItemType.Weapon, 1));
        items.Add(new Item("Club", 3, "A strong sturdy weapon made from carving out a log", 6, 2, Item.ItemType.Weapon, 1));
        items.Add(new Item("Log", 4, "Large peice of wood cut from a tree", 0, 0, Item.ItemType.Resource, 10));
    }
}
