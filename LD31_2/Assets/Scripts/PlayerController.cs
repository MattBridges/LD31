using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundry
{
	public float xMin, xMax, yMin,yMax;

}
public class PlayerController : MonoBehaviour {

	public float speed = 15f;
	public Boundry boundary;
	public AudioClip gather;
	public AudioClip playerExplosion;
	public static int resources = 0;
	public bool playerInv = true;
	public float maxFade = 125;
	public static GameObject ship;
	public Transform explosion;
	public Transform explosion2;
	void Start(){
		ship = this.gameObject;
	}

	void FixedUpdate()
	{
		float moveV = Input.GetAxis ("Vertical");
		float moveH = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector2 (moveH, moveV);
		rigidbody2D.velocity = movement * speed;

		//Clamp the ship into the game bounds
		rigidbody2D.position = new Vector2 (
			Mathf.Clamp(rigidbody2D.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rigidbody2D.position.y, boundary.yMin, boundary.yMax)
			);
		//Find the mouse position on the screen and rotate towards it.
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Asteroid" && Input.GetKey(KeyCode.Space))
		{
			audio.PlayOneShot(gather,1);
			other.SendMessage("GatherOre",.01f);
			Gather();
			if(other.transform.localScale.x <= 0.01f)
					GameObject.Destroy(other.gameObject,0);

		}


			
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Alien Ship" || other.gameObject.name == "Bullet_Alien"){
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Instantiate(explosion2, gameObject.transform.position, Quaternion.identity);
            audio.PlayOneShot(playerExplosion, 2);	
			DestroyPlayer ();
		}
	}
	void Gather()
	{
		DisplayScore.score += 5;
	}
	public static void DestroyPlayer()
	{
      	
		ship.renderer.enabled = false;
		ship.collider2D.enabled = false;
		GameObject.Destroy(ship,1);
		GameManager.DestroyShip ();
	}


}
