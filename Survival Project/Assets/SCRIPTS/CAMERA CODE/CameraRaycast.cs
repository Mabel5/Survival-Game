using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {
 
    //Raycast Variables:
    //float distanceToItem;
    public int rayLength = 2;

    //GameObjects:
    public GameObject weapon;
    public GameObject mainHand;

    //Strings:
	public string currentItem;

    //Booleans:
    public bool isEquipped;
    public bool axeIsEquipped;
    public bool pickIsEquipped;
    public bool canBeThrown;

    public ItemDatabase database;
    public Inventory inventory;

    // Use this for initialization
    void Start () {
        mainHand = GameObject.Find("MainHand");
        isEquipped = false;
        axeIsEquipped = false;
        pickIsEquipped = false;
        canBeThrown = false;
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * rayLength;
        Debug.DrawRay(transform.position, forward, Color.blue);

        if(Physics.Raycast(transform.position, (forward), out hit))
        {
            //distanceToItem = hit.distance;
			string currentItem = hit.collider.gameObject.tag;
			GameObject currentObject = hit.collider.gameObject;


            if (hit.distance <= rayLength && hit.collider.gameObject.tag == "Weapon"
                || hit.collider.gameObject.tag == "Axe"
                || hit.collider.gameObject.tag == "PickAxe"
                || hit.collider.gameObject.tag == "Stick"
                || hit.collider.gameObject.tag == "Rock")
            {

                if(Input.GetKeyDown(KeyCode.E))
                {
					if (hit.collider.gameObject.tag == "Stick" || hit.collider.gameObject.tag == "Rock") {
						Destroy (hit.collider.gameObject);
						inventory.AddItem (currentItem, 1);
					}


                    
                    if(hit.collider.gameObject.tag == "Weapon"
                        || hit.collider.gameObject.tag == "Axe"
                        || hit.collider.gameObject.tag == "PickAxe")
                    {

						weapon = hit.collider.gameObject;

                        if (isEquipped == true)
                        {
							Transform mhChild = mainHand.transform.GetChild(0);

							mhChild.GetComponent<Rigidbody> ().isKinematic = false;
							mhChild.GetComponent<Rigidbody> ().useGravity = true;

							mainHand.transform.DetachChildren ();
							isEquipped = false;
                        }

                        
                        SetParent(mainHand);
                        weapon.GetComponent<Rigidbody>().isKinematic = true;
                        weapon.GetComponent<Rigidbody>().useGravity = false;
                        SetPosition();
                        isEquipped = true;

                        //axeIsEquipped check:
                        if (weapon.tag == "Axe")
                        {
                            axeIsEquipped = true;
                        }
                        else
                        {
                            axeIsEquipped = false;
                        }
                        if (weapon.tag == "PickAxe")
                        {
                            pickIsEquipped = true;
                        }
                        else
                        {
                            pickIsEquipped = false;
                        }
                    }
                    
                }
            }

            //Axe Controller:
            if(Input.GetKeyDown(KeyCode.Mouse0) && isEquipped == true)
            {
                if (hit.distance <= rayLength && hit.collider.gameObject.tag == "Tree" && axeIsEquipped == true)
                {

                    /*This line accesses the "TreeController" script
                    * and allows for modification of things inside the script:*/
                    TreeController treeScript = hit.collider.gameObject.GetComponent<TreeController>();
                    if(treeScript.isFallen == false)
                    {
                        treeScript.treeHealth--;
						inventory.AddItem("Stick", (int)(Random.Range(1, 3)));
                    }
                }
                if (hit.distance <= rayLength && hit.collider.gameObject.tag == "Stone" && pickIsEquipped == true)
                {
                    StoneController stoneScript = hit.collider.gameObject.GetComponent<StoneController>();
                    if(stoneScript.isBroken == false)
                    {
                        stoneScript.stoneHealth--;
						inventory.AddItem("Rock", 1);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && isEquipped == true)
        {
			dropWeapon (weapon);
        }

        if (Input.GetKey(KeyCode.Mouse0) && isEquipped == true)
        {
            canBeThrown = true;
        }
        else
        {
            canBeThrown = false;
        }

        if (canBeThrown == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.transform.parent = null;
            weapon.GetComponent<Rigidbody>().isKinematic = false;
            weapon.GetComponent<Rigidbody>().useGravity = true;
            isEquipped = false;
            Rigidbody rb = weapon.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        }
    }

    public void SetParent(GameObject mainHand)
    {
        weapon.transform.parent = mainHand.transform;
    }

    public void SetPosition()
    {
        var meleePosition = mainHand.transform.position;
        Quaternion meleeRotation = new Quaternion(0f, 0f, 0f, 0f);
        weapon.transform.SetPositionAndRotation(meleePosition, meleeRotation);
    }

	public void dropWeapon(GameObject weapon) {
		mainHand.transform.DetachChildren ();
		weapon.GetComponent<Rigidbody>().isKinematic = false;
		weapon.GetComponent<Rigidbody>().useGravity = true;
		isEquipped = false;

		if(axeIsEquipped == true)
		{
			axeIsEquipped = false;
		}
		if(pickIsEquipped == true)
		{
			pickIsEquipped = false;
		}
	}
		
}
