using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHealth : MonoBehaviour {
	Text txt;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "Player Health: " + GameManager.playerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Player Health: " + GameManager.playerHealth;
	}
}
