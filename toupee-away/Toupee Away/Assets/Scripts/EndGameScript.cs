using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject scoreboard;
    public GameObject endScore;
    public GameObject player;
    public GameObject rageBar;
    ScoreScript scoreScript;
    PlayerScript playScript;
    Text endScoreText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playScript = player.GetComponent<PlayerScript>();
        endScoreText = endScore.GetComponent<Text>();
        scoreScript = gameObject.GetComponent<ScoreScript>();
    }

    private void Update()
    {
        if(playScript.GameOver() == false)
        {
            gameOverScreen.SetActive(false);
            scoreboard.SetActive(true);
            rageBar.SetActive(true);
        }
        else if(playScript.GameOver() == true)
        {
            gameOverScreen.SetActive(true);
            scoreboard.SetActive(false);
            rageBar.SetActive(false);
        }

        endScoreText.text = "" + scoreScript.GetScore();
    }

   

}
