using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageModeScript : MonoBehaviour
{
    public GameObject player;
    PlayerScript playScript;

    public GameObject bob;
    BobScript bobScript;

    public GameObject bear;
    BearScript bearScript;

    public GameObject rageBarLeft;
    public GameObject rageBarRight;
    Image leftBar;
    Image rightBar;

    public GameObject redTint;
    SpriteRenderer rageTint;
    Color red;
    float tint;

    public GameObject rageBanner;
    float rageBannerScale = 7.4f;
    public float rageBannerScaleRate = 0;
    public bool isGrowing = false;

    public float rageTime;
    float origTime = 15;

    bool rageMode = false;
    bool rageBannerLogic = false;

    GameObject sfxObject;
    ButtonScript sfxScript;


    private void Start()
    {
        leftBar = rageBarLeft.GetComponent<Image>();
        rightBar = rageBarRight.GetComponent<Image>();
        rageTint = redTint.GetComponent<SpriteRenderer>();
        red = rageTint.color;
        playScript = player.GetComponent<PlayerScript>();
        origTime = rageTime;
        bobScript = bob.GetComponent<BobScript>();
        bearScript = bear.GetComponent<BearScript>();

        bearScript.Leave();
        bobScript.Enter();

        isGrowing = false;
    }


    bool bearEnter = false;
    bool bobEnter = false;


    private void Update()
    {
        sfxObject = GameObject.FindGameObjectWithTag("SFXObject");
        sfxScript = sfxObject.GetComponent<ButtonScript>();
        RageCheck();
        RageBanner();
        if (playScript.GameOver() == false)
        {
            #region RageMeter Stuff
            if (player.transform.position.y > 2f && rageMode == false)
            {
                leftBar.fillAmount += Time.deltaTime / rageTime;
                rightBar.fillAmount += Time.deltaTime / rageTime;
            }
            else if (player.transform.position.y < 2f && rageMode == false)
            {
                leftBar.fillAmount -= Time.deltaTime / rageTime;
                rightBar.fillAmount -= Time.deltaTime / rageTime;
            }
            else if (rageMode == true)
            {
                leftBar.fillAmount -= Time.deltaTime / rageTime;
                rightBar.fillAmount -= Time.deltaTime / rageTime;
            }
            #endregion

            if (leftBar.fillAmount == 1 && rightBar.fillAmount == 1 && rageMode == false)
            {
                isGrowing = true;
                rageMode = true;
                rageBannerLogic = true;
                sfxScript.PlayRoar();
                //NEW LOGIC

                //CALL LEAVE ON BOB
                bobScript.Leave();

            }
            else if (leftBar.fillAmount == 0 && rightBar.fillAmount == 0 && rageMode == true)
            {
                rageMode = false;

                //NEW LOGIC

                //CALL LEAVE ON BEAR
                bearScript.Leave();

                //IF BEAR HAS LEFT, CALL ENTER ON BOB


            }

            if (rageMode == true)
            {
                //IF BOB HAS LEFT, CALL ENTER ON BEAR
                if (bobScript.HasLeft() == true)
                {
                    bearScript.Enter();
                }
            }
            else
            {
                if (bearScript.HasLeft() == true)
                {
                    bobScript.Enter();
                }
            }

        }
        else if (playScript.GameOver() == true)
        {
            leftBar.fillAmount = 0;
            rightBar.fillAmount = 0;
            isGrowing = false;
            rageMode = false;

            //NEW LOGIC

            //CALL LEAVE ON BEAR
            bearScript.Leave();
            //IF BEAR HAS LEFT, CALL ENTER ON BOB

            if (bearScript.HasLeft() == true)
            {
                bobScript.Enter();
            }
        }


    }


    void RageBanner()
    {
        if (isGrowing == true)
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            rageBanner.SetActive(true);
        }
        else if (isGrowing == false)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            rageBanner.SetActive(false);
            rageBannerLogic = false;
        }
    }

    void RageCheck()
    {
        red.a = Mathf.Clamp(red.a, 0, 0.75f);
        rageTint.color = red;
        if (rageMode == true)
        {
            rageTime = 15;
            red.a += Time.deltaTime;
            leftBar.color = Color.red;
            rightBar.color = Color.red;

        }
        else if (rageMode == false)
        {
            rageTime = origTime;
            red.a -= Time.deltaTime;
            leftBar.color = Color.white;
            rightBar.color = Color.white;
        }
    }
    public bool RageMode()
    {
        return rageMode;
    }

}
