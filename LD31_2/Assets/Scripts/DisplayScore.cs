using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {
	Text txt;
	public static int score = 0;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Score: " + score;
	
	}
}
