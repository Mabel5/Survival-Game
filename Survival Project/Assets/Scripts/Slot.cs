using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler
{

    public bool empty;
    public Texture slotTexture;
    public Texture itemTexture;
    public Inventory inventory;

    // Use this for initialization
    void Start ()
    {
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		empty = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (itemTexture && empty == false)
        {
			gameObject.GetComponent<RawImage>().texture = itemTexture;
        }
        else
        {
            gameObject.GetComponent<RawImage>().texture = slotTexture;
			gameObject.GetComponent<Slot> ().itemTexture = slotTexture;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //
    }
}
