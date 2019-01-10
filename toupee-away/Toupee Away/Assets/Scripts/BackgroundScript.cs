using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{


    Transform playerTrans;
    [SerializeField]
    GameObject background;
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(BackgroundLogic());
        }

    }


    IEnumerator BackgroundLogic()
    {
        yield return new WaitUntil(() => playerTrans.position.x - transform.position.x > 220f);
        Instantiate(background, new Vector3(transform.position.x + 850.6f, 0.65f, 0f), Quaternion.identity);
        Destroy(gameObject);
    }
}
