using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour {

    public float skySpeed = 0.1f;

    private void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (-skySpeed * Time.deltaTime),
            gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
