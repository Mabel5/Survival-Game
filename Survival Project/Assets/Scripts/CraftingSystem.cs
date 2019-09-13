using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour {

	public Inventory inventory;
    public GameObject inventoryGUI;
    public Transform Axe;
	public Transform Club;
	public Transform PickAxe;
    public CameraRaycast raycastScript;
    public string craftingButtonName = "CraftAxe, CraftClub";
    public bool showGUI = false;
    public bool inventoryEnabled;


    // Use this for initialization
    void Start () {
        raycastScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraRaycast>();
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
    }
	
	// Update is called once per frame
	void Update () {

		//Opens the crafting interface
        if (Input.GetKeyDown(KeyCode.C))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventoryGUI.SetActive(true);
            showGUI = true;
        }
        else
        {
            inventoryGUI.SetActive(false);
            showGUI = false;
        }

        if (inventoryEnabled)
        {
            Screen.lockCursor = false;
        }
        else if (!inventoryEnabled)
        {
            Screen.lockCursor = true;
        }
    }

	public void Craft(string item)
    {
        //buttonName = craftingButtonName;

		if(item == "Axe" && showGUI == true && inventory.craftCheck("Rock", 1) && inventory.craftCheck("Stick", 1))
        {
			Instantiate(Axe, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
			inventory.RemoveItem ("Rock", 1);
			inventory.RemoveItem ("Stick", 1);

        }
		if (item == "Club" && showGUI == true && inventory.craftCheck("Stick", 2))
        {
			Instantiate (Club, GameObject.FindGameObjectWithTag ("Player").transform.position, Quaternion.identity);
			inventory.RemoveItem ("Stick", 2);
        }
		if (item == "PickAxe" && showGUI == true && inventory.craftCheck("Rock", 1) && inventory.craftCheck("Stick", 1))
		{
			Instantiate (PickAxe, GameObject.FindGameObjectWithTag ("Player").transform.position, Quaternion.identity);
			inventory.RemoveItem ("Rock", 1);
			inventory.RemoveItem ("Stick", 1);
		}
    }

}
