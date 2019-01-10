using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FindButtonScript : MonoBehaviour
{

    public int buttonNumber;
    [SerializeField]
    Button button;

    [SerializeField]
    GameObject buttonObject;
    ButtonScript buttonScript;
    [SerializeField]
    GameObject musicObject;
    MusicScript musicScript;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        buttonObject = GameObject.FindGameObjectWithTag("SFXObject");
        musicObject = GameObject.FindGameObjectWithTag("MusicObject");
        // musicScript = musicObject.GetComponent<MusicScript>();
        buttonScript = buttonObject.GetComponent<ButtonScript>();
        musicScript = FindObjectOfType<MusicScript>();


        //MAIN MENU BUTTON
        if (buttonNumber == 0)
        {
            //list.callback.AddListener((eventData) => buttonScript.ChangeScene());
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.ChangeScene());
            button.onClick.AddListener(() => buttonScript.PlayClick());

        }
        //RESET LEVEL GAME
        if (buttonNumber == 1)
        {
            //list.callback.AddListener((eventData) => buttonScript.ResetGame());
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.ResetGame());
            button.onClick.AddListener(() => buttonScript.PlayClick());
            button.onClick.AddListener(() => musicScript.UnmuteMusic());
            //button.onClick.AddListener(() => adMan.LoadAd());
        }
        //START GAME
        if (buttonNumber == 2)
        {
            //list.callback.AddListener((eventData) => buttonScript.ChangeScene());
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //eventTrigger.triggers.Add(list);

            //error
            button.onClick.AddListener(() => { buttonScript.ChangeScene(); });
            button.onClick.AddListener(() => { buttonScript.PlayClick(); });
            button.onClick.AddListener(() => {ADManagerScript.Instance.SetMusicCheck(musicScript.IsMuted());});
            // button.onClick.AddListener(() => { start();});
        }
        //OPTIONS MENU
        if (buttonNumber == 3)
        {
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //eventTrigger.triggers.Add(list);
            //error
            button.onClick.AddListener(() => buttonScript.PlayClick());
        }
        //SFX ON
        if (buttonNumber == 4)
        {
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //list.callback.AddListener((eventData) => buttonScript.UnmuteSFX());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.PlayClick());
            button.onClick.AddListener(() => buttonScript.UnmuteSFX());

        }
        //SFX OFF
        if (buttonNumber == 5)
        {
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //list.callback.AddListener((eventData) => buttonScript.MuteSFX());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.PlayClick());
            button.onClick.AddListener(() => buttonScript.MuteSFX());
        }
        //MUSIC ON
        if (buttonNumber == 6)
        {
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //list.callback.AddListener((eventData) => musicScript.UnmuteMusic());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.PlayClick());
            button.onClick.AddListener(() => musicScript.UnmuteMusic());
        }
        //MUSIC OFF
        if (buttonNumber == 7)
        {
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //list.callback.AddListener((eventData) => musicScript.MuteMusic());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.PlayClick());
            button.onClick.AddListener(() => musicScript.MuteMusic());
        }
        //BACK BUTTON
        if (buttonNumber == 8)
        {
            //list.callback.AddListener((eventData) => buttonScript.PlayClick());
            //eventTrigger.triggers.Add(list);
            button.onClick.AddListener(() => buttonScript.PlayClick());
        }
        //SHARE TO FACEBOOK
        if (buttonNumber == 9)
        {
           // button.onClick.AddListener(() => buttonScript.ShareToFacebook());
        }
    }
}
