using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleScript : MonoBehaviour
{
    GameObject player;
    public GameObject eagleText;
    Rigidbody2D eagleRidg;
    bool hit = false;

    public float eagleSpeed = 6f;

    private void Start()
    {
        eagleRidg = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        eagleRidg.velocity = new Vector2(eagleSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            GameObject temp = Instantiate(eagleText, transform.position, Quaternion.identity);
            temp.GetComponent<EagleTextScript>().SetBonus(20);
        }
    }
}
