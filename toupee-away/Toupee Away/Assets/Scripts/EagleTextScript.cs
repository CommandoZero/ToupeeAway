using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EagleTextScript : MonoBehaviour {

    private void Awake()
    {
        StartCoroutine(TimeTilDestroy());
    }
    public int timeTilDestroy;

    public void SetBonus(int bonus)
    {
        GetComponentInChildren<Text>().text = "+" + bonus;
    }
    
    IEnumerator TimeTilDestroy()
    {
        yield return new WaitForSeconds(timeTilDestroy);
        Destroy(gameObject);
    }

}
