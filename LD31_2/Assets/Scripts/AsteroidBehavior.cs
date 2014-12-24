using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour {
	public float rotSpeed = 2.5f;
	public float moveSpeed = 1.5f;
	public float paddingX = .5f;
	public float paddingY = .5f;

	private Vector3 rotDir = new Vector3 (0, 0, 1);
	private Vector2 moveDir;
	public int health=100;

	// Use this for initialization
	void Start () {
		FindRandomDirection ();
		gameObject.collider2D.enabled = true;


	}

	// Update is called once per frame
	void FixedUpdate () {


		transform.Rotate (rotDir * rotSpeed);
		
		rigidbody2D.velocity = moveDir * moveSpeed;
		if(rigidbody2D.position.x<-10||rigidbody2D.position.x>10||rigidbody2D.position.y<-7 || health <=0)
		{
			GameObject.Destroy(this.gameObject,0);
		}

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Left Wall")
						Debug.Log ("LeftWall");
			
		if (other.gameObject.tag == "Right Wall")
			Debug.Log ("LeftWall");
			
		if(other.gameObject.tag=="Alien Bullet")
		{
			GameObject.Destroy(other.gameObject);
			health-=25;
			if(health <=0)
				GameObject.Destroy(this.gameObject);
		}
	}
	void FindRandomDirection()
	{
		float randX, randY;

		randX = Random.Range (-2, 2);
		randY = Random.Range (-2, -1);

		moveDir = new Vector2 (randX, randY);

	}
	public void GatherOre()
	{
		transform.localScale -= new Vector3 (.005f, .005f,0);
	}

}
