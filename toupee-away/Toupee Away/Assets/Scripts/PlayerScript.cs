using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject wallSector;
    Rigidbody2D playerRigd;
    public List<GameObject> colliderObj;
    public List<PolygonCollider2D> colliders;
    PolygonCollider2D playerCollider;
    SpriteRenderer playerRender;
    Vector2 force;
    Vector2 deacceleration;
    public float maxXVelocity;
    public float minXVelocity;
    public float maxYVelocity;
    float xVelocity = 0f;
    float yVelocity = 0f;

    public bool isDead = false;
    Quaternion playerRotation;

    public Sprite[] playerSprites;

    GameObject sfxObject;
    ButtonScript sfxScript;

    public GameObject background;

    public GameObject gameManager;
    ScoreScript scoreScript;

    GameObject adManager;
    ADManagerScript adMan;
    bool playAD = true;

    [SerializeField]
    GameObject aExitButton;

    [SerializeField]
    GameObject aRestartButton;

    void Start()
    {
        scoreScript = gameManager.GetComponent<ScoreScript>();
        playerRigd = gameObject.GetComponent<Rigidbody2D>();
        playerRender = gameObject.GetComponent<SpriteRenderer>();
        playerCollider = gameObject.GetComponent<PolygonCollider2D>();
        for (int i = 0; i < 3; i++)
        {
            colliders.Add(colliderObj[i].GetComponent<PolygonCollider2D>());
        }
        force = new Vector2(4.5f, 8f);
        sfxObject = GameObject.FindGameObjectWithTag("SFXObject");
        sfxScript = sfxObject.GetComponent<ButtonScript>();
        adManager = GameObject.FindGameObjectWithTag("ADManager");
        adMan = FindObjectOfType<ADManagerScript>();
        playAD = true;
    }

    void Update()
    {
        PlayerCheck();
        Environment();
        gameObject.transform.rotation = playerRotation;
    }
    private void FixedUpdate()
    {


        xVelocity = playerRigd.velocity.x;
        if (xVelocity > maxXVelocity)
        {
            xVelocity = maxXVelocity;
        }
        else if (xVelocity < minXVelocity)
        {
            xVelocity = minXVelocity;
        }


        yVelocity = playerRigd.velocity.y;
        if (yVelocity > maxYVelocity)
        {
            yVelocity = maxYVelocity;
        }
        playerRigd.velocity = new Vector2(xVelocity, yVelocity);


    }

    private void PlayerCheck()
    {

        if (isDead == false)
        {
            if (playerRigd.velocity.y < 0f && playerRigd.velocity.y > -1.5f)
            {
                //level toupee

                playerRender.sprite = playerSprites[1];
                playerCollider.points = colliders[1].points;

            }
            else if (playerRigd.velocity.y < -1.5f)
            {
                //toupee dipping down

                playerRender.sprite = playerSprites[0];
                playerCollider.points = colliders[0].points;

            }

#if UNITY_EDITOR 

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerRigd.velocity += force;
                //toupee tipped up

                playerRender.sprite = playerSprites[2];
                playerCollider.points = colliders[2].points;

                sfxScript.PlayShwoosh();

            }

            if (!Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerRigd.velocity -= new Vector2(Time.deltaTime, 0f);
            }


#elif UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playerRigd.velocity += force;
                //toupee tipped up

                playerRender.sprite = playerSprites[2];
                playerCollider.points = colliders[2].points;

                sfxScript.PlayShwoosh();
            }
            else
            {
                playerRigd.velocity -= new Vector2(Time.deltaTime, 0f);
            }

#elif UNITY_IPHONE
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playerRigd.velocity += force;
                //toupee tipped up

                playerRender.sprite = playerSprites[2];
                playerCollider.points = colliders[2].points;

                sfxScript.PlayShwoosh();
            }
            else
            {
                playerRigd.velocity -= new Vector2(Time.deltaTime, 0f);
            }


#endif
        }
        else if (isDead == true)
        {
            playerRigd.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            playerRender.sprite = playerSprites[1];
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            for (int i = 0; i < walls.Length; i++)
            {
                Destroy(walls[i]);
            }

            if (playAD == true)
            {
                StartCoroutine(ADManagerScript.Instance.ShowAd(aExitButton, aRestartButton));
                playAD = false;
            }

            return;
        }
    }

    float wallValue = 19.6f;
    void Environment()
    {
        GameObject[] sectors = GameObject.FindGameObjectsWithTag("Sector");
        Vector3 secPos = new Vector3(wallValue + 20f, 0, 0);
        if (transform.position.x >= wallValue)
        {
            Instantiate(wallSector, secPos, Quaternion.identity);
            wallValue += 20f;
        }

        for (int i = 0; i < sectors.Length; i++)
        {
            if (sectors[i].transform.position.x < gameObject.transform.position.x - 30)
            {
                Destroy(sectors[i]);
            }

        }

        GameObject[] skys = GameObject.FindGameObjectsWithTag("Sky");
        for (int i = 0; i < skys.Length; i++)
        {
            if (gameObject.transform.position.x - skys[i].transform.position.x > 370f)
            {
                Destroy(skys[i]);
            }
        }

        //GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        //for (int i = 0; i < backgrounds.Length; i++)
        //{
        //    print(backgrounds[i].transform.position.x - gameObject.transform.position.x);
        //    if (gameObject.transform.position.x - backgrounds[i].transform.position.x    > 220f)
        //    {
        //        Instantiate(background, new Vector3(backgrounds[i].transform.position.x + 850.6f, 0.65f, 0f), Quaternion.identity);
        //        Destroy(backgrounds[i]);
        //    }
        //}
    }

    public bool GameOver()
    {
        return isDead;
    }

    public float GetXVelocity()
    {
        return xVelocity;
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Wall" || hit.gameObject.tag == "Obstacle" || hit.gameObject.tag == "Bob" || hit.gameObject.tag == "Bear")
        {
            isDead = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Eagle")
        {
            scoreScript.AddPoints(20);
        }
        else if (hit.gameObject.tag == "Hashtag")
        {
            isDead = true;
        }
    }
}
