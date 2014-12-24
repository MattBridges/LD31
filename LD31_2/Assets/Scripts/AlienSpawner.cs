using UnityEngine;
using System.Collections;

public class AlienSpawner : MonoBehaviour {
    public Transform alienSpawnLoc;
    public GameObject alienShip;
    public float spawnWait = 5;
    public static int spawnNum = 0;
	// Use this for initialization
	void Start () {
        
        StartCoroutine("AlienSpawn");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
            SpawnAlien();
	}
    
    void SpawnAlien()
    {
        float randX = Random.Range(-8, 8);
        alienSpawnLoc.transform.position = new Vector3(randX, 6, 0);
        Instantiate(alienShip, alienSpawnLoc.position, alienSpawnLoc.rotation);
        spawnNum++;
    }

    IEnumerator AlienSpawn()
    {
        yield return new WaitForSeconds(1);
        SpawnAlien();

        while (!GameManager.gameOver)
        {
            yield return new WaitForSeconds(spawnWait);

            SpawnAlien();
            spawnWait -= .25f;
            if (spawnWait < 1)
                spawnWait = 1;

            Debug.Log(spawnWait);
        }
    }
    
    
}
