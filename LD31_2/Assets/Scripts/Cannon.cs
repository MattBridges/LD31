using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	public GameObject bullet;
	public GameObject laser;
	public float bulletSpeed = 20;
	public float cannonOffset = 1.5f;
	public AudioClip shot;
	public bool gameOver = false;
	private float nextShot;
	private float rOF;
	public float rateOfFire = 2;
	// Use this for initialization
	void Start () {
		nextShot = Time.time;
		rOF = 1 / rateOfFire;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetMouseButton(0)&&GameManager.playerAlive) 
		{
			if(Time.time>=nextShot)
			{
				nextShot = Time.time+ rOF;
				FirePlayerCannon();
			}
		}
	}
	void FirePlayerCannon()
	{

			
			Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y-1.5f) );
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
			Vector2 direction = target - myPos;
            float distance = Vector2.Distance(myPos, target);
			direction.Normalize();
            if(distance>=.20f)
            {
                audio.PlayOneShot(shot, .25f);
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
                projectile.rigidbody2D.velocity = direction * bulletSpeed;
            }
			
	
	}

}
