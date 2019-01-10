using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject rageTint;

    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
        rageTint.transform.position = new Vector3(player.transform.position.x, 0, 1);
    }
}
