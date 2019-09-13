using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public GameObject Tree;
    public int treeHealth = 3;
    public bool isFallen = false;

	// Use this for initialization
	void Start () {
        Tree = transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (treeHealth <= 0 && isFallen == false)
        {
            Rigidbody rb = Tree.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward * Time.deltaTime, ForceMode.Impulse - 6);
            StartCoroutine(DestroyTree());
            isFallen = true;
        }
	}

    private IEnumerator DestroyTree ()
    {
        yield return new WaitForSeconds(3);
        Destroy(Tree);
    }
}
