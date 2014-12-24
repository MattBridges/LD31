using UnityEngine;
using System.Collections;

public class AlienCannon : MonoBehaviour {
	public GameObject bullet;
	public GameObject target;

	public float bulletSpeed = 20;
	public float cannonOffset = 1.5f;
	public float rateOfFire = 1.25f;
	private static float rOF;
	private static float nextShot;

	// Use this for initialization
	void Start () {
		rOF = 1 / rateOfFire;
		nextShot = Time.time;
	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(Time.time>=nextShot)
		{
			nextShot = Time.time+ rOF;
            AlienBehavior ab = this.transform.parent.GetComponent<AlienBehavior>();

            
            Debug.Log(target);
            if (target == null)
                return;
            Vector3 tarPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
			Vector3 myPos = new Vector3(transform.position.x,transform.position.y,0);
			Vector3 direction = target.transform.position - myPos;
            float distance = Vector3.Distance(myPos, tarPos);
			direction.Normalize();
            if (distance >= .20f)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
                projectile.rigidbody2D.velocity = direction * bulletSpeed;
            }

		}
	
	}

	


}
