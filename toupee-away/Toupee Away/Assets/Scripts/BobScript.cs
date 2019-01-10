using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobScript : MonoBehaviour
{
    public GameObject player;
    public GameObject feet;
    public GameObject hashtagSpawn;
    public GameObject hashtag;
    public GameObject gameManager;
    Rigidbody2D bobRidg;
    PlayerScript playScript;
    BobAnimationScript bobAnim;
    public float speed = 0;
    public float minSpeed = 0;
    public float maxSpeed = 0;
    public float maxHashtagAngle = 0;
    public float minHashtagAngle = 0;
    float minXDistance;
    bool enterUpdate = false;
    bool collided = false;

    private void Start()
    {
        bobRidg = GetComponent<Rigidbody2D>();
        playScript = player.GetComponent<PlayerScript>();
        bobAnim = gameObject.GetComponent<BobAnimationScript>();
        InvokeRepeating("HashtagSpawn", 10, 10);
    }

    private void Update()
    {
        minXDistance = Mathf.Clamp(minXDistance, -12f, -6.3f);
        #region Restraints

        //These if statements just make sure that bob/bear don't go past their minimum distances off screen
        if (gameObject.transform.position.x < player.transform.position.x + minXDistance)
        {
            gameObject.transform.position = new Vector2(player.transform.position.x + minXDistance, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x > player.transform.position.x - 0.5f)
        {
            gameObject.transform.position = new Vector2(player.transform.position.x - 0.5f, gameObject.transform.position.y);
        }

        #endregion
        Walking();
        if (playScript.GameOver() == false)
        {
            FeetCheck();
        }
        else if (playScript.GameOver() == true)
        {
            if (collided == true)
            {
                bobAnim.GameOver();
            }

            //if (bobRidg.velocity.y < 0f)
            //{
            //    bobAnim.RunToJumpOne();
            //    bobAnim.JumpOneToJumpThree(true);
            //}
            //else if (bobRidg.velocity.y > 0f)
            //{
            //    bobAnim.RunToJumpOne();
            //    bobAnim.JumpOneToJumpThree(true);
            //}
        }

    }

    public void Enter()
    {
        enterUpdate = true;
        minSpeed = 3.5f;
    }

    public void Leave()
    {
        enterUpdate = false;
        minXDistance = -12f;
    }

    bool hasLeft = false;
    public bool HasLeft()
    {
        return hasLeft;
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
            speed = -10;
            if (gameObject.transform.position.x - player.transform.position.x <= minXDistance)
            {
                hasLeft = true;
            }
            else
            {
                hasLeft = false;
            }
        }
        bobRidg.velocity = new Vector2(speed, bobRidg.velocity.y);
    }




    bool jumping = true;
    bool grounded = false;
    float tick = 0;
    float frequency = 0.8f;


    bool jumpBool = false;

    void FeetCheck()
    {

        //print(bobRidg.velocity.y);
        tick = Mathf.Clamp(tick, 0, frequency);
        RaycastHit2D hit = Physics2D.Raycast(feet.transform.position, Vector2.down);
        if (hit.distance < 0.006)
        {
            grounded = true;
            tick += Time.deltaTime;
            bobAnim.RunToWhole(false);
            //bobAnim.Whole_To_Run(true);
        }
        else if (hit.distance > 0.006)
        {
            grounded = false;
        }

        if (bobRidg.velocity.y > 0f)
        {
            if (jumpBool == true)
            {
                bobAnim.RunToJumpOne();
                jumpBool = false;
            }
        }
        else if (bobRidg.velocity.y < 0f && playScript.GameOver() == false)
        {

        }
        else if (bobRidg.velocity.y < 0f && playScript.GameOver() == true)
        {
            bobAnim.RunToJumpOne();
            bobAnim.JumpOneToJumpThree(true);
        }
        else if (bobRidg.velocity.y > 0f && playScript.GameOver() == true)
        {
            bobAnim.RunToJumpOne();
            bobAnim.JumpOneToJumpThree(true);
        }


        if (playScript.GameOver() == false)
        {
            if (player.transform.position.y < 1)
            {

                speed += Time.deltaTime;
                if (player.transform.position.y > -1.75 && player.transform.position.x - gameObject.transform.position.x < 2f)
                {
                    if (grounded == true)
                    {
                        if (tick > frequency)
                        {
                            jumping = false;
                            if (!jumping)
                            {
                                tick -= frequency;
                                Jump();
                                jumpBool = true;
                                jumping = true;
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

    }

    void Jump()
    {
        bobRidg.velocity = new Vector2(speed + 1f, 5.5f);
    }


    public GameObject rageObj;
    private void HashtagSpawn()
    {
        if (playScript.GameOver() == false && rageObj.GetComponent<RageModeScript>().RageMode() == false)
        {
            bool hashTemp = false;
            if (player.transform.position.x - gameObject.transform.position.x > 5.5f)
            {
                int randomPercent = Random.Range(0, 100);
                float randomAngle = Random.Range(minHashtagAngle, maxHashtagAngle);
                if (randomPercent > 50 && randomPercent < 85)
                {
                    bobAnim.RunToHashtag();
                    hashtagSpawn.transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
                    Instantiate(hashtag, hashtagSpawn.transform.position, hashtagSpawn.transform.rotation);
                }
                else if (randomPercent > 85)
                {
                    hashTemp = false;
                    if (hashTemp == false)
                    {
                        bobAnim.RunToHashtag();
                        hashTemp = true;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 0)
                        {
                            hashtagSpawn.transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
                            Instantiate(hashtag, hashtagSpawn.transform.position, hashtagSpawn.transform.rotation);
                        }
                        else if (i == 1)
                        {
                            hashtagSpawn.transform.rotation = Quaternion.Euler(0f, 0f, minHashtagAngle - 5);
                            Instantiate(hashtag, hashtagSpawn.transform.position, hashtagSpawn.transform.rotation);
                        }
                        else if (i == 2)
                        {
                            hashtagSpawn.transform.rotation = Quaternion.Euler(0f, 0f, maxHashtagAngle + 7);
                            Instantiate(hashtag, hashtagSpawn.transform.position, hashtagSpawn.transform.rotation);
                        }
                    }

                }
            }
        }
       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = true;
            if (grounded == true)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                bobAnim.RunToPickup(true);
                bobRidg.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else if (grounded == false)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                bobAnim.JumpOneToJumpThree(true);
                bobRidg.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(hashtagSpawn.transform.position, hashtagSpawn.transform.right * 15);
    }

}
