using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {
    private Text gameOver;
    private GameObject gameOverBtn;
    // Use this for initialization
    void Start()
    {
        gameOver = gameObject.GetComponent<Text>();
        gameOverBtn = GameObject.Find("RestartButton");
        gameOverBtn.SetActive(false);
        gameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            gameOver.text = "Game Over!";
            gameOverBtn.SetActive(true);
        }
           
        else
        {
            gameOver.text = "";
            gameOverBtn.SetActive(false);

        }
            
    }
}
