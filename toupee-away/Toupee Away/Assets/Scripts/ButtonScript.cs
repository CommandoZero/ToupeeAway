using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{


    public GameObject clickObject;
    AudioSource click;
    public GameObject swooshObject;
    AudioSource swoosh;
    public GameObject roarObject;
    AudioSource roar;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        click = clickObject.GetComponent<AudioSource>();
        swoosh = swooshObject.GetComponent<AudioSource>();
        roar = roarObject.GetComponent<AudioSource>();
    }

    public void PlayClick()
    {
        click.Play();
    }

    public void PlayShwoosh()
    {
        swoosh.Play();
    }

    public void PlayRoar()
    {
        roar.Play();
    }

    public void MuteSFX()
    {
        click.mute = true;
        swoosh.mute = true;
        roar.mute = true;
    }

    public void UnmuteSFX()
    {
        click.mute = false;
        swoosh.mute = false;
        roar.mute = false;
    }

    public bool IsMuted()
    {
        if (click.mute == true && swoosh.mute == true && roar.mute == true)
        {
            return true;
        }
        else if (click.mute == false && swoosh.mute == false && roar.mute == false)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    [SerializeField]
    string appID = "1765546396839105";

    [SerializeField]
    string link = "https://google.com";

    [SerializeField]
    string pictureLink = "https://cdn.discordapp.com/attachments/378290572089098242/420702626091499532/unknown.png";

    [SerializeField]
    string caption = "Test Score: ";

    [SerializeField]
    string description = "Description: ";

   //public  void ShareToFacebook()
   // {
   //     int score;
   //     GameObject temp = GameObject.FindGameObjectWithTag("GameManager");
   //     score = (int)temp.GetComponent<ScoreScript>().GetScore();
   //     FB.FeedShare
   //         (
   //     linkCaption: "Toupee Away!",
   //     picture: new System.Uri(pictureLink),
   //     linkName: "Check Out My Score On Toupee Away: " + score,
   //     link: new System.Uri(link)
   //         );
   // }

}
