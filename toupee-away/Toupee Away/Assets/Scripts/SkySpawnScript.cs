using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpawnScript : MonoBehaviour
{

    public GameObject sky;
    public GameObject player;


    private void Update()
    {
        GameObject[] skys = GameObject.FindGameObjectsWithTag("Sky");

        for (int i = 0; i < skys.Length; i++)
        {
            if (player.transform.position.x - skys[i].transform.position.x >  82)
            {
                Instantiate(sky, new Vector3(skys[i].transform.position.x + 221, 0.24f, 0f), Quaternion.identity);
                Destroy(skys[i]);
            }
        }
    }

}
