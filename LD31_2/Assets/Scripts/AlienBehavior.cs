using UnityEngine;
using System.Collections;

public class AlienBehavior : MonoBehaviour {
	private GameObject playerTarget;
	private GameObject[] asteroids;
	private GameObject asteroidTarget;
    public GameObject target;


	private float playerDist = 0;
	private float asteroidDist = 0;
	private Quaternion rotTar;
	private float targetDist;
	public float attackOffset=1.5f;
	public float speed = 2;

    public GameObject bullet;
    public Transform player;

    public float bulletSpeed = 20;
    public float cannonOffset = 1.5f;
    public float rateOfFire = 1.25f;
    private static float rOF;
    public float nextShot;
    private float reloadTime;
    private bool canShoot = false;
    public GameObject closest;
    public Transform cannonLoc;
    



	// Use this for initialization
	void Awake () {
		asteroids = new GameObject[0];
        rOF = 1 / rateOfFire;
        nextShot = Time.time;

        this.gameObject.name = "Alien " + AlienSpawner.spawnNum.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
				//Find the mouse position on the screen and rotate towards it.
		FindTarget ();
       
		MoveShip ();
        if(Time.time>=nextShot)
		{
			nextShot = Time.time+ rOF;
            FireWeapon();
		}
        

	}
	GameObject FindPlayer()
	{
		playerTarget = GameObject.FindGameObjectWithTag ("Player");
        return playerTarget;
	}
	GameObject FindClosestAsteroid()
	{
        GameObject[] ast;
        ast = GameObject.FindGameObjectsWithTag("Asteroid");
        
        float dist = Mathf.Infinity;
        Vector3 myPos = transform.position;
        foreach (GameObject Ast in ast)
		{
            Vector2 diff = Ast.transform.position - myPos;
            float curDist = diff.sqrMagnitude;
            if(curDist<dist)
            {
                closest = Ast;
                dist = curDist;
            }
        }
        return closest;
    }
	void DistToTarget()
	{
		targetDist = Vector2.Distance (transform.position, target.transform.position);
	}
	void FindTarget()
	{
        GameObject cAst = FindClosestAsteroid();
        GameObject player = FindPlayer();
        float aDist = 0;
        float pDist = 0;
        if(cAst !=null)
        {
           aDist = Vector2.Distance(transform.position, cAst.transform.position);
        }
            
        if(player !=null)
        {
            pDist = Vector2.Distance(transform.position, player.transform.position);
        }
            
		
		if(player!=null)
        {
            if (aDist>=pDist || pDist <= 6 )
                target = player;
            else
                target = cAst;
        }
        else
            target = cAst;
        
		
	}
	void MoveShip()
	{
		if(target != null)
		{
          
			Vector2 shipPos = new Vector2( transform.position.x, transform.position.y);
			Vector2 tarPos= new Vector2(target.transform.position.x, target.transform.position.y);
			Vector2 direction = tarPos - shipPos;
			direction.Normalize();
			DistToTarget();
			if(targetDist>=attackOffset)
			{
				rigidbody2D.velocity = direction * speed;
			}
			rotTar = Quaternion.LookRotation(Vector3.back, target.transform.position - transform.position );
			transform.rotation = Quaternion.Slerp (transform.rotation, rotTar, .3f);
			
		}

            
	}

    void FireWeapon()
    {

        if (target != null)
        {

            Vector3 tarPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            Vector3 myPos = new Vector3(cannonLoc.position.x, cannonLoc.position.y, 0);
            Vector3 direction = tarPos - myPos;
            float distance = Vector3.Distance(myPos, tarPos);
            direction.Normalize();
            if (distance >= .20f)
            {

                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
                //Debug.Log(projectile.transform.position);
                projectile.rigidbody2D.velocity = direction * bulletSpeed;
            }
        }
        if (target == null)
        {

            Debug.Log("No Target");
        }


    }

   

}
