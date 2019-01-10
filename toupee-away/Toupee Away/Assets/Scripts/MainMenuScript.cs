using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject sky;

    public GameObject musicOnButton;
    public GameObject musicOffButton;
    GameObject musicObject;
    MusicScript musicScript;

    public GameObject sfxOnButton;
    public GameObject sfxOffButton;
    GameObject sfxObject;
    ButtonScript buttonScript;

    public GameObject mainMenuUI;
    public GameObject optionsUI;

    public GameObject title;
    public GameObject handOne;
    public GameObject handTwo;

    private void Start()
    {
        musicObject = GameObject.FindGameObjectWithTag("MusicObject");
        musicScript = musicObject.GetComponent<MusicScript>();
        sfxObject = GameObject.FindGameObjectWithTag("SFXObject");
        buttonScript = sfxObject.GetComponent<ButtonScript>();

       
    }

    private void Update()
    {
        GameObject[] skys = GameObject.FindGameObjectsWithTag("Sky");
        for (int i = 0; i < skys.Length; i++)
        {
            if (skys[i].transform.position.x < -60f)
            {
                Instantiate(sky, new Vector3(113.75f , 2.56f, 0f), Quaternion.identity);
                Destroy(skys[i]);
            }
        }
    }

    public void TurnMusicOn()
    {
        musicOffButton.SetActive(true);
        musicOnButton.SetActive(false);
    }
    public void TurnMusicOff()
    {
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);
    }


    public void TurnSFXOn()
    {
        sfxOffButton.SetActive(true);
        sfxOnButton.SetActive(false);
    }
    public void TurnSFXOff()
    {
        sfxOffButton.SetActive(false);
        sfxOnButton.SetActive(true);
    }

    public void OptionsMenu()
    {
        title.SetActive(false);
        optionsUI.SetActive(true);
        mainMenuUI.SetActive(false);
        handOne.SetActive(false);
        handTwo.SetActive(false);

        if (musicScript.IsMuted() == true)
        {
            TurnMusicOff();
        }
        else
        {
            TurnMusicOn();
        }

        if(buttonScript.IsMuted() == true)
        {
            TurnSFXOff();
        }
        else
        {
            TurnSFXOn();
        }
    }

    public void MainMenu()
    {
        title.SetActive(true);
        optionsUI.SetActive(false);
        mainMenuUI.SetActive(true);
        handOne.SetActive(true);
        handTwo.SetActive(true);
    }

}
