using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakPlatManager : MonoBehaviour {

	public float breakCD;
	public float respawnCD;
	public static breakPlatManager Instance = null;

	[SerializeField] GameObject platformPrefab;

	void Awake()
	{
		if (Instance == null) 
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
	}


	public void BreakPlatform(Vector2 spawnPosition1, GameObject caller1)
	{
		StartCoroutine (SpawnPlatform(spawnPosition1, caller1));
	}

	IEnumerator SpawnPlatform(Vector2 spawnPosition, GameObject caller)
	{
		yield return new WaitForSeconds (respawnCD);


		GameObject go = Instantiate (platformPrefab, spawnPosition, platformPrefab.transform.rotation);

		// Set the instantiate obj to be a child of the breakPlatManager
		go.transform.parent = caller.transform;
	}

}
