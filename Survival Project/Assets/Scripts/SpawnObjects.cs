using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    public GameObject StickPrefab;
    public GameObject TreePrefab;
    public GameObject RockPrefab;
    public GameObject StonePrefab;

    public Transform terrain;

    public Vector3 center;
    public Vector3 size;

	public int sticksToSpawn;
	public int treesToSpawn;
	public int rocksToSpawn;
	public int stonesToSpawn;

	// Use this for initialization
	void Start ()
    {
        SpawnSticks();
        SpawnTrees();
        SpawnRocks();
        SpawnStones();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SpawnSticks()
    {
		for (int i = 0; i < sticksToSpawn; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), terrain.position.y - 0.5f, Random.Range(-size.z / 2, size.z / 2));

            Instantiate(StickPrefab, pos, Quaternion.identity);
        }
    }
    public void SpawnTrees()
    {
		for (int i = 0; i < treesToSpawn; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), terrain.position.y - 0.5f, Random.Range(-size.z / 2, size.z / 2));

            Instantiate(TreePrefab, pos, Quaternion.identity);
        }
    }
    public void SpawnRocks()
    {
		for (int i = 0; i < rocksToSpawn; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), terrain.position.y - 0.5f, Random.Range(-size.z / 2, size.z / 2));

            Instantiate(RockPrefab, pos, Quaternion.identity);
        }
    }
    public void SpawnStones()//currently spawns stones with wrong rotation
    {
        for (int i = 0; i < stonesToSpawn; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), terrain.position.y - 0.5f, Random.Range(-size.z / 2, size.z / 2));

			Instantiate(StonePrefab, pos, StonePrefab.transform.rotation);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
