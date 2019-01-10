using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject eagle;
    public GameObject[] eagleSpawns;

    private void Start()
    {
        StartCoroutine(Tick());
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x - 11, 3, 0);
    }

    IEnumerator Tick()
    {
        while (true)
        {
            int percent = Random.Range(1, 100);
            if (percent > 50)
            {
                int random = Random.Range(0, eagleSpawns.Length);
                Instantiate(eagle, eagleSpawns[random].transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(10);
        }

    }
}
