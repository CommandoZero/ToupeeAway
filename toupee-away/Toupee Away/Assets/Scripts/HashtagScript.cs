using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashtagScript : MonoBehaviour {

    Rigidbody2D hashRidg;
    public float moveSpeed = 0;

    private void Start()
    {
        hashRidg = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hashRidg.velocity = transform.right * moveSpeed;
        if(gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
