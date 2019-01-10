using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;



public class ADManagerScript : MonoBehaviour
{

    public static ADManagerScript Instance { set; get; }

    public string IOSAppID;
    public string testIOSVideoID;
    public string IOSVideoID;

    public string androidAppID;
    public string testAndroidVideoID;
    public string androidVideoID;

    MusicScript ms;

    public bool testingAD = false;


    private void Start()
    {
#if UNITY_IOS 
        MobileAds.Initialize(IOSAppID);
#elif UNITY_ANDROID|| UNITY_EDITOR
        MobileAds.Initialize(androidAppID);
        if (testingAD)
        {
            ad = new InterstitialAd(testAndroidVideoID);
        }
        else
        {
            ad = new InterstitialAd(androidVideoID);
        }

#endif
        LoadAd();

        ms = GameObject.FindGameObjectWithTag("MusicObject").GetComponent<MusicScript>();
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    InterstitialAd ad;
    AdRequest request;
    public void LoadAd()
    {
        request = new AdRequest.Builder().Build();
#if  UNITY_IOS
        ad = new InterstitialAd(testIOSVideoID);
        if (testingAD)
        {
            ad = new InterstitialAd(testIOSVideoID);
        }
        else
        {
            ad = new InterstitialAd(IOSVideoID);
        }
        
#endif
        ad.OnAdOpening += HandleOnAdOpened;
        ad.OnAdClosed += HandleOnAdClosed;
        ad.LoadAd(request);
    }

    bool isMuted = false;

    public void SetMusicCheck(bool aBool)
    {
        isMuted = aBool;
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLoaded event received");
        if (!isMuted)
        {
            ms.MuteMusic();
        }

    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleAdClosed event received");
        if (a & b)
        {
            HideButtons(a, b, true);
        }
        if (!isMuted)
        {
            ms.UnmuteMusic();
        }

        LoadAd();
    }

    GameObject a;
    GameObject b;


    public void HideButtons(GameObject aExit, GameObject aRestart, bool aBool)
    {
        a = aExit;
        b = aRestart;
        aExit.SetActive(aBool);
        aRestart.SetActive(aBool);
    }
    bool adIsAvailable = true;

    public IEnumerator AdTimer()
    {
        adIsAvailable = false;
        yield return new WaitForSeconds(30);
        adIsAvailable = true;
    }

    public IEnumerator ShowAd(GameObject aExitButton, GameObject aReturnButton)
    {
        if (ad.IsLoaded())
        {
            HideButtons(aExitButton, aReturnButton, false);
            yield return new WaitForSeconds(4);
#if UNITY_EDITOR
            Debug.Log("The ad is loaded and is being shown.");
#endif
            if (adIsAvailable)
            {
                ad.Show();
                AdTimer();
            }

        }
    }

}
