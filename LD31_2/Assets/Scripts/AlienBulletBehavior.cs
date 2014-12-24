using UnityEngine;
using System.Collections;

public class AlienBulletBehavior : MonoBehaviour {
	public float destroyTime = 3f;
	public AudioClip playerExplosion;
	public Transform explosion;
	public Transform explosion2;
	public static int damage=10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Destroy (this.gameObject, destroyTime);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.tag == "Player" && GameManager.playerAlive) 
		{
			GameManager.playerHealth -=10;
			DestroyBullet();
            if (GameManager.playerHealth <= 0)
                PlayerController.DestroyPlayer();

		}
        if (other.gameObject.tag == "Player Bullet")
        {

            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(this.gameObject);
        }
		if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Alien Ship") 
		{
			DestroyBullet();
            
		}
	
		
	}

	void DestroyBullet()
	{
        gameObject.renderer.enabled = false;
        gameObject.collider2D.enabled = false;
        GameObject.Destroy (this.gameObject);
	}
}
