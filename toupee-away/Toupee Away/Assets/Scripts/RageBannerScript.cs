using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBannerScript : MonoBehaviour
{

    public GameObject gameManager;
    RageModeScript rageScript;
    float bannerScale = 0;
    public float maxBannerScale = 7.4f;
    public float minBannerScale = 1f;
    public float timeToRage = 15f;

    private void Start()
    {
        rageScript = gameManager.GetComponent<RageModeScript>();
    }

    float frequency = 1;
    float tick = 0;
    private void OnEnable()
    {
        bannerScale = maxBannerScale;
        tick = 0;
    }
    private void Update()
    {
        bannerScale = Mathf.Clamp(bannerScale, minBannerScale, maxBannerScale);
        //print(gameObject.GetComponent<RectTransform>().localScale);
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(bannerScale, bannerScale, bannerScale);
        bannerScale -= Time.deltaTime * timeToRage;
        if (bannerScale <= minBannerScale)
        {
            tick += Time.deltaTime * 10;
            if (tick >= frequency)
            {
                tick -= frequency;
                rageScript.isGrowing = false;
            }
        }
    }
}
