using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {
    private GameObject life1, life2, life3;
	// Use this for initialization
	void Start () {
        life1 = GameObject.Find("Life1");
        life2 = GameObject.Find("Life2");
        life3 = GameObject.Find("Life3");
        life1.GetComponent<Image>().enabled = false;
        life2.GetComponent<Image>().enabled = false;
        life3.GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateLifeCounter();
	}
    void UpdateLifeCounter()
    {
        if (GameManager.playerLives >= 0)
        {
            life1.GetComponent<Image>().enabled = false;
            life2.GetComponent<Image>().enabled = false;
            life3.GetComponent<Image>().enabled = false;

        }
        if(GameManager.playerLives == 1)
        {
            life1.GetComponent<Image>().enabled = true;
            life2.GetComponent<Image>().enabled = false;
            life3.GetComponent<Image>().enabled = false;

        }
        if (GameManager.playerLives == 2)
        {
            life1.GetComponent<Image>().enabled = true;
            life2.GetComponent<Image>().enabled = true;
            life3.GetComponent<Image>().enabled = false;

        }
        if (GameManager.playerLives == 3)
        {
            life1.GetComponent<Image>().enabled = true;
            life2.GetComponent<Image>().enabled = true;
            life3.GetComponent<Image>().enabled = true;

        }
      
        

    }
}
