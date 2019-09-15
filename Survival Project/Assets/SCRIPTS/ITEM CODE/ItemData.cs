using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour {

    //GUI Variables:
    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;


    // Use this for initialization
    void Start () {
        myText = GameObject.Find("PickUp").GetComponent<Text>();
        myText.color = Color.clear;
        fadeTime = 100000f;
    }
	
	// Update is called once per frame
	void Update () {
        FadeText();
	}

    void OnMouseOver()
    {
        displayInfo = true;
    }

    void OnMouseExit()
    {
        displayInfo = false;
    }

    void FadeText()
    {
        if(displayInfo == true)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }
        else if(displayInfo == false)
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime );
        }
    }
}
