using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableSpawnerLogic : MonoBehaviour {

	public float collectableSpawnTime = 1.0f;
	public float badCollectableSpawnTime = 2.0f;
	public bool canSpawnCollectable = true;
	public bool canSpawnBadCollectable = true;

	float randomGoodX=0.0f;
	float randomGoodY=0.0f;

	float randomBadX=0.0f;
	float randomBadY=0.0f;

	float maxX=20.5f;
	float maxY=9.0f;

	public GameObject goodCollectable;
	public GameObject badCollectable;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (spawnCollectables());
		StartCoroutine (spawnBadCollectables());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnCollectables()
	{
		while (canSpawnCollectable == true) 
		{
			spawnCollectable ();
			yield return new WaitForSeconds (collectableSpawnTime);
		}
	}

	IEnumerator spawnBadCollectables()
	{
		while (canSpawnBadCollectable == true) 
		{
			spawnBadCollectable ();
			yield return new WaitForSeconds (badCollectableSpawnTime);
		}
	}

	void spawnCollectable()
	{
		randomGoodX = Random.Range (-maxX,maxX);
		randomGoodY = Random.Range (-maxY, maxY);
		Instantiate (goodCollectable, new Vector3 (randomGoodX, randomGoodY, 0), Quaternion.identity);
	}

	void spawnBadCollectable()
	{

		randomBadX = Random.Range (-maxX,maxX);
		randomBadY = Random.Range (-maxY, maxY);
		Instantiate (badCollectable, new Vector3 (randomBadX, randomBadY, 0), Quaternion.identity);
	}
}
