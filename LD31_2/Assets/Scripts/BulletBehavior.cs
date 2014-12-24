using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float destroyTime = 3f;
	public AudioClip alienExplosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Destroy (this.gameObject, destroyTime);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name == "ship")
            GameObject.Destroy(this.gameObject) ;
		if (other.gameObject.tag == "Alien Ship") 
		{
			audio.PlayOneShot(alienExplosion,1.5f);
			this.gameObject.renderer.enabled=false;
            this.gameObject.collider2D.enabled = false;
			GameObject.Destroy (other.gameObject);

			GameObject.Destroy (this.gameObject,2);
		}
        if (other.gameObject.tag == "Alien Bullet")
        {
           
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(this.gameObject);
        }
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Asteroid1")
		{
			//this.gameObject.renderer = false;
			GameObject.Destroy(this.gameObject);
		}
	}

}
