using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorScript : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] wallSets;
    int[] randInt = new int[5];
    int random;
    private void Start()
    {

        //forloopStart
        //int[i] = startRandom(1, 125)
        //if (1-20) int random(1,4)
        //if (21-95) int random(5,9)
        //if (96-125) int random(10,12)
        //Instantiate(wallSets[random], spawnPoints[i].position, Quaternion.identity,spawnPoints[i])
        //forloopEnd

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            randInt[i] = Random.Range(1, 100);
            if (randInt[i] >= 1 && randInt[i] <= 10)
            {
                random = Random.Range(0, 3);
            }
            else if (randInt[i] >= 11 && randInt[i] <= 40)
            {
                random = Random.Range(4, 8);
            }
            else if (randInt[i] >= 41 && randInt[i] <= 100)
            {
                random = Random.Range(7, 9);
            }
            Instantiate(wallSets[random], spawnPoints[i].position, Quaternion.identity, spawnPoints[i]);
        }
    }
}
