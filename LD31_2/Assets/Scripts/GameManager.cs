using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject playerShip;
	public Transform spawnLocation;
	public static bool playerAlive = false;
	public static bool gameOver=false;
	public static float asteroidWait = 2;
	private static int score;
	public static int playerHealth;
	private int _playerHealth = 100;
    public  static int playerLives;


	// Use this for initialization
	void Start () {
		playerHealth = _playerHealth;
        playerLives = 3;
		DestroyShip ();
		SpawnPlayer ();
	
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q))
						SpawnPlayer ();
	}

	public void SpawnPlayer ()
	{

        if (playerAlive == false && !gameOver)
        {
            
            Instantiate (playerShip, spawnLocation.position, spawnLocation.rotation);
			playerAlive = true;
            playerHealth = 100;
		
		}
		else
			Debug.Log("Player is already alive");
			
	}
	public static void DestroyShip()
	{
		GameObject ship = GameObject.FindGameObjectWithTag ("Player");
		if (ship != null){
			GameObject.Destroy (ship);
			playerAlive = false;
            playerLives--;
           
            if (playerLives <= 0)
            {
                gameOver = true;
                Debug.Log("Game OVER!");

            }
                
		}
	}
    public void RestartGame()
    {
        playerHealth = _playerHealth;
        playerLives = 3;
        gameOver = false;
        DisplayScore.score = 0;
        Application.LoadLevel(0);
       // DestroyShip();
       // SpawnPlayer();
       

    }
}
