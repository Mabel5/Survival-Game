using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{

    public GameObject Stone;
    public int stoneHealth = 3;
    public bool isBroken = false;

    // Use this for initialization
    void Start()
    {
        Stone = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (stoneHealth <= 0 && isBroken == false)
        {
            Rigidbody rb = Stone.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward * Time.deltaTime, ForceMode.Impulse - 6);
            //StartCoroutine(DestroyStone());
            isBroken = true;
            Destroy(Stone);
        }
    }

    /*private IEnumerator DestroyStone()
    {
        Destroy(Stone);
    }*/
}
