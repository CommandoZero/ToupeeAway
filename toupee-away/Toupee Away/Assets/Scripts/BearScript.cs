using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{

    public GameObject player;
    public GameObject feet;
    public GameObject gameManager;
    PlayerScript playScript;
    RageModeScript rageScript;
    Rigidbody2D bearRidg;
    public float speed = 0;
    public float minSpeed = 0;
    public float maxSpeed = 0;
    public float minXDistance = 0;
    bool enterUpdate = false;

    Animator bearAnim;

    private void Start()
    {
        playScript = player.GetComponent<PlayerScript>();
        rageScript = gameManager.GetComponent<RageModeScript>();
        bearRidg = GetComponent<Rigidbody2D>();
        bearAnim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // print(speed);
        minXDistance = Mathf.Clamp(minXDistance, -15f, -6f);
        #region Constraints 
        if (gameObject.transform.position.x < player.transform.position.x + minXDistance)
        {
            gameObject.transform.position = new Vector2(player.transform.position.x + minXDistance, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x > player.transform.position.x)
        {
            gameObject.transform.position = new Vector2(player.transform.position.x, gameObject.transform.position.y);
        }
        #endregion
        Walking();
        FeetCheck();
    }

    void Walking()
    {
        if (enterUpdate == true)
        {
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            minXDistance += Time.deltaTime * 5;
        }
        else if (enterUpdate == false)
        {
            speed = -10f;
            if (gameObject.transform.position.x - player.transform.position.x <= minXDistance)
            {
                hasLeft = true;
            }
            else
            {
                hasLeft = false;
            }
        }

        if (player.transform.position.y < 2f && rageScript.RageMode() == true)
        {
            speed += Time.deltaTime;
        }
        else
        {
            speed -= Time.deltaTime;
        }
        bearRidg.velocity = new Vector2(speed, bearRidg.velocity.y);
    }

    public void Enter()
    {
        enterUpdate = true;
        speed = maxSpeed;
    }

    public void Leave()
    {
        enterUpdate = false;
        minXDistance = -15f;
    }
    bool hasLeft = false;
    public bool HasLeft()
    {
        return hasLeft;
    }

    float tick = 0;
    float frequency = 0;
    bool grounded = false;
    bool jumping = false;

    void FeetCheck()
    {


        tick = Mathf.Clamp(tick, 0, frequency);
        RaycastHit2D hit = Physics2D.Raycast(feet.transform.position, Vector2.down);
        if (hit.distance < 0.04f)
        {
            grounded = true;
            tick += Time.deltaTime;
        }
        else if (hit.distance > 0)
        {
            grounded = false;
        }

        if (grounded == false)
        {
           // bearAnim.SetBool("Bear_Run", false);
        }
        else if (grounded == true)
        {
            bearAnim.SetBool("Bear_Run", true);
        }

        if (player.transform.position.y < 1.5f)
        {
            speed += Time.deltaTime;
            if (player.transform.position.y > -1.25 && player.transform.position.x - gameObject.transform.position.x < 3f)
            {
                if (grounded == true)
                {
                    if (tick > frequency)
                    {
                        jumping = true;
                        if (jumping == true)
                        {


                            Jump();
                            jumping = false;
                            tick -= frequency;
                        }
                    }
                }
            }
        }
        else
        {
            speed -= Time.deltaTime;
        }
    }

    public void Jump()
    {
        bearRidg.velocity = new Vector2(speed + 2f, 7f);
    }

    public float GetMinXPos()
    {
        return minXDistance;
    }
}
