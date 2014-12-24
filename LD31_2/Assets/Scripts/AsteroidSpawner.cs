using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject asteroid;
	public Transform aSpawnLocation;
	public Boundry boundry;

		// Use this for initialization
		void Start ()
		{
		SpawnAsteroid ();
		StartCoroutine ("Spawner", GameManager.asteroidWait);
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.P))
						SpawnAsteroid ();
		}
		void SpawnAsteroid ()
		{
		float randX = Random.Range (-8	, 8);
		aSpawnLocation.transform.position = new Vector3 (randX, 6,0);
		Instantiate (asteroid, aSpawnLocation.position, aSpawnLocation.rotation);


		}
		void FindRandomSpawnLocation()
		{
		float randX = Random.Range (-8	, 8);
			aSpawnLocation.transform.position = new Vector3 (randX, 6,0);

		}
		IEnumerator Spawner(float sDelay)
		{
				
			while(!GameManager.gameOver)
			{	
				yield return new WaitForSeconds (sDelay);
				
				SpawnAsteroid ();
			}

		}

}

