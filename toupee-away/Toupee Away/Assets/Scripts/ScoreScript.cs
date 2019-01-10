using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public GameObject scoreText;
    public GameObject player;
    Text text;
    PlayerScript playScript;
    float score = 0;

    private void Start()
    {
        playScript = player.GetComponent<PlayerScript>();
        text = scoreText.GetComponent<Text>();
    }

    private void Update()
    {
        if (playScript.GameOver() == false)
        {
            score += Time.deltaTime;
            text.text = "" + (int)score;
        }
    }

    public float GetScore()
    {
        return (int)score;
    }

    public void AddPoints(int points)
    {
        score += points;
    }
}
