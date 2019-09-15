using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public List<Item> slots = new List<Item>();
    private ItemDatabase database;

	public Texture inventorySlotTexture;
    public bool inventoryEnabled;
    public GameObject inventoryGUI;
	private GameObject[] slot;
    public Transform itemsParent;
    public bool isPickedUp;

	public Text sticksText;
	public Text rocksText;

	public int sticks;
	public int rocks;

	void Start () {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		inventorySlotTexture = Resources.Load<Texture2D> ("InventoryIcon/InventorySlot");
        InventorySlots();
    }
	
	void Update () {

		sticksText.GetComponent<Text>().text = "Sticks: " + sticks;
		rocksText.GetComponent<Text>().text = "Rocks: " + rocks;

        if(Input.GetKeyDown(KeyCode.C))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled)
        {
            inventoryGUI.SetActive(true);
        }
        else
        {
            inventoryGUI.SetActive(false);
        }

        if(inventoryEnabled)
        {
            Screen.lockCursor = false;
        }
        else if(!inventoryEnabled)
        {
            Screen.lockCursor = true;
        }
	}

    public void InventorySlots()
    {
        slot = GameObject.FindGameObjectsWithTag("InventorySlot").OrderBy(go => go.name).ToArray();
    }

	public void AddItem(string item, int num)
    {

		itemGraphicsAdd(item, num);

		if (item == "Stick") {
			AddItemSticks (num);
		} else if (item == "Rock") {
			AddItemRocks (num);
		}

	}
		
	public void RemoveItem(string item, int num) {

		int y = 0;

		if (item == "Stick") {
			RemoveItemSticks (num);
		} else if (item == "Rock") {
			RemoveItemRocks (num);
		}

		for (int x = 0; x < slot.Length; x++) {
			if (slot [x].GetComponent<Slot> ().itemTexture.name == item) {
				slot [x].GetComponent<Slot> ().empty = true;

				num--;

				if (num == 0) {
					break;
				}
			}
		}



	}

	private int AddItemSticks(int num)
    {
		sticks = sticks + num;
		return sticks;
    }
	private int AddItemRocks(int num)
    {
		rocks = rocks + num;
		return rocks;
    }

	private int RemoveItemSticks(int num)
	{
		sticks = sticks - num;
		return sticks;
	}

	private int RemoveItemRocks(int num)
	{
		rocks = rocks - num;
		return rocks;
	}

	public bool craftCheck(string item, int cost) {
		if (item == "Stick" && (sticks - cost < 0)) {
			return false;
		} else if (item == "Rock" && (rocks - cost < 0)) {
			return false;
		} else {
			return true;
		}

	}

	private bool itemCheck(string item) {

		bool itemExistsInSlots = false;

		for (int j = 0; j < slot.Length; j++) {
			if (slot [j].GetComponent<Slot> ().itemTexture.name == item) {
				itemExistsInSlots = true;
				print ("item exists in slot" + j);
				return itemExistsInSlots;
				break;
			} 
		}
		return itemExistsInSlots;
	}

	private void itemGraphicsAdd(string currentItem, int num) {

		int x;

		for (int j = 0; j < num; j++) { 
			//finds the first empty slot in the array
			for (x = 0; x < slot.Length; x++) {
				if (slot [x].GetComponent<Slot> ().empty == true) {
					slot [x].GetComponent<Slot> ().empty = false;
					break;
				}
			}

			//finds the item icon associated with the inputed parameter string item
			for (int y = 0; y < database.items.Count; y++) {
				if (database.items [y].itemName.Equals (currentItem)) {
					slot [x].GetComponent<Slot> ().itemTexture = database.items [y].itemIcon;
					break;
				}
			}
		}
	}
}
