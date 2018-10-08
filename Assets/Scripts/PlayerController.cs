using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField] float groundTriggerRadius = .1f;
    [SerializeField] Transform groundTrigger;
    [SerializeField] LayerMask groundLayer;

    private GameObject player;
    private GameObject respawn;

    private GameObject moveRightZone;
    private GameObject stopMoveRightZone;

    private GameObject crystalBase;

    public bool canControl = true;
    private bool castOnce = false;

    public float jumpPower;
    private float curSpeed;

    private bool canMove = true;

    public float Speed;

    // --- Level Change Things --- //
    private GameObject levelFader;
    private float waitTime = 2f;
    private bool changeLevel = false;
    public string nextLevel;

    // --- Char Ded --- //
    public float deathPause = 3f;
    public bool deadFreeze = false;
    public bool canDie = true;

    // --- Ded Things --- //
    public GameObject playerSphere;
    public bool sphereOnRespawn = false;
    // --- Cam Shake --- //
    private CameraShake shake;

    public float currentHeight;
    public float previousHeight;
    public float travel;

    public bool isGrounded = true;
    private int maxAmountOfJumps = 1;
    private int Jumped = 0;

    public bool stickJump;




    public int score;
    public int deathCount;

    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D boxCollider;

    //public float rotationSpeed = 10;
    //public bool rotatePlayer = false;


    void Awake () {

        //playerRotation = player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.x, 90);

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();

        levelFader = GameObject.FindGameObjectWithTag("LevelFader");

        crystalBase = GameObject.FindGameObjectWithTag("Crystal_base");

        moveRightZone = GameObject.FindGameObjectWithTag("MoveRightZone");
        stopMoveRightZone = GameObject.FindGameObjectWithTag("StopMoveRightZone");

        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        canControl = false;
        curSpeed = 2f;
        rb.velocity = new Vector2(curSpeed, rb.velocity.y);
    }

    void ChangeDirection() //change sprite xy
    {
        if (curSpeed > 0 && sr.flipX)
        {
            sr.flipX = false;
            //GetComponent<Animator>().Play("Rotate_1");
        }
        else if (curSpeed < 0 && !sr.flipX)
        {
            sr.flipX = true;
            //GetComponent<Animator>().Play("Rotate_1");
        }
    }

    public void Move()
    {
        rb.velocity = new Vector2(curSpeed, rb.velocity.y);
    }
    //-------------------------------- FOR DOUBLE JUMP
    //void Jump()
    //{
    //    if (Jumped < maxAmountOfJumps)
    //    {
    //        GoUp();
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    //void GoUp()
    //{
    //    rb.velocity = new Vector2(0, 0);
    //    rb.AddForce(Vector2.up * jumpPower);
    //    Jumped += 1;
    //}
    //------------------------------------------ END OF FOR DOUBLE JUMP
    void SingleJump()
    {
        isGrounded = false;
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(Vector2.up * jumpPower);
        //Jumped += 1;
    }
    void StickyJump()
    {
        canMove = true;
        stickJump = false;
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(Vector2.up * jumpPower);
        //Jumped += 1;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundTrigger.position, groundTriggerRadius, groundLayer);
        
    }
    void OnDrawGizmosSelected() //groundTrigger circle
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(groundTrigger.position, groundTriggerRadius);
    }

    void Update () {

        ChangeDirection();
        respawn = GameObject.FindGameObjectWithTag("RespawnPoint");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && canControl == true)
        {
            //Jump();
            SingleJump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && stickJump == true && canControl == true)
        {
            StickyJump();
        }


        if (Input.GetKey(KeyCode.LeftArrow) && canMove == true && canControl == true)
        {
            curSpeed = -Speed;
            rb.velocity = new Vector2(curSpeed, rb.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow) && canMove == true && canControl == true)
        {
            curSpeed = Speed;
            rb.velocity = new Vector2(curSpeed, rb.velocity.y);
        }
        else if(canControl == true)
        {
            curSpeed = 0f;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (isGrounded == true)
        {
            Jumped = 0;
            //GetComponent<Animator>().Play("Landing_1");
        }
        if (isGrounded == true && curSpeed == 0f && deadFreeze == false)
        {
            GetComponent<Animator>().Play("Idle_1");
        }
        //} else if (isGrounded == false && deadFreeze == false)
        //{
        //    GetComponent<Animator>().Play("Jump_1");
        //}
        //if (isGrounded == false && curSpeed > 0f && deadFreeze == false)
        //{
        //    GetComponent<Animator>().Play("Jump_1");
        //}
        if (player.GetComponent<Rigidbody2D>().velocity.y > 0.1 && isGrounded == false && deadFreeze == false)
        {
            GetComponent<Animator>().Play("Jump_1");

        }
        if (player.GetComponent<Rigidbody2D>().velocity.y < -0.1 && isGrounded == false && deadFreeze == false)
        {
            GetComponent<Animator>().Play("Fall_1");
        }
        if (isGrounded == true && curSpeed > 0f && deadFreeze == false)
        {
            GetComponent<Animator>().Play("Moving_1");
        }
        if (isGrounded == true && curSpeed < 0f && deadFreeze == false)
        {
            GetComponent<Animator>().Play("Moving_1");
        }

        if (canMove == false)
        {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(0, 0);

        } else
        {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if (Input.GetKey(KeyCode.P))
        {
            canMove = true;
        }

        if (changeLevel == true)
        {
            StartCoroutine(ChangeLevel());
            changeLevel = false;
        }
        if (deadFreeze == true)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        } else
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        if(sphereOnRespawn == true)
        {
            StartCoroutine(CharacterDeathTwo());
        }

        //if (player.GetComponent<Rigidbody2D>().velocity.y < -0.3 && isGrounded == false)
        //{
        //    GetComponent<Animator>().Play("Falling_1");
        //    Debug.Log("VNIZZZZZ");
        //}

        //if (player.GetComponent<Rigidbody2D>().velocity.y > 0.1 && isGrounded == false && deadFreeze == false)
        //{
        //    GetComponent<Animator>().Play("Jump_1");

        //}
        //if (player.GetComponent<Rigidbody2D>().velocity.y < -0.1 && isGrounded == false && deadFreeze == false)
        //{
        //    GetComponent<Animator>().Play("Fall_1");
        //}
        //if (player.GetComponent<Rigidbody2D>().velocity.y > 0.1 && isGrounded == false && curSpeed > 0f && deadFreeze == false)
        //{
        //    GetComponent<Animator>().Play("Jump_1");
        //}

        //void LateUpdate()
        //{
        //    currentHeight = player.transform.position.y;
        //    travel = currentHeight - previousHeight;
        //    if (currentHeight < previousHeight)
        //    {
        //        Debug.Log("MovingDOWN");
        //    }
        //    if (currentHeight > previousHeight)
        //    {
        //        Debug.Log("MovingUP");
        //    }

        //    previousHeight = currentHeight;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Danger" && canDie == true)
        {
            canDie = false;
            shake.CamShake();
            StartCoroutine(CharacterDeath());
        }
        if (other.gameObject.tag == "JumpBooster")
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * 400);
        }
        if(other.gameObject.tag == "Score")
        {
            Destroy(other.gameObject);
            score++;
        }
        if (other.gameObject.tag == "LiftUp")
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (other.gameObject.tag == "MoveRightZone")
        {
            crystalBase.GetComponent<CrystalController>().closeDoor = true;
            canControl = false;
            curSpeed = 2f;
            rb.velocity = new Vector2(curSpeed, rb.velocity.y);
            Debug.Log("MoveRightZone");
            changeLevel = true;
        }

        if (other.gameObject.tag == "StopMoveRightZone" && castOnce == false)
        {
            castOnce = true;
            crystalBase.GetComponent<CrystalController>().activeRedDoor = true;
            canControl = true;
            curSpeed = 0f;
            rb.velocity = new Vector2(0, rb.velocity.y);
            Debug.Log("StopMoveRightZone");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StickyWall")
        {
            stickJump = true;
            canMove = false;
            rb.velocity = new Vector2(0, 0);
            isGrounded = true;
        }
    }
    
    IEnumerator ChangeLevel()
    {
        levelFader.GetComponent<Animator>().Play("Level_fade_1");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator CharacterDeath()
    {
        canControl = false;
        deadFreeze = true;
        GetComponent<Animator>().Play("Death_1");
        yield return new WaitForSeconds(0.5f);
        GetComponent<CapsuleCollider2D>().enabled = false;
        Instantiate(playerSphere, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
    }

    IEnumerator CharacterDeathTwo()
    {
        //yield return new WaitForSeconds(deathPause);
        sphereOnRespawn = false;
        player.transform.position = new Vector3(respawn.transform.position.x, respawn.transform.position.y, respawn.transform.position.z);
        GetComponent<Animator>().Play("Respawn_1");
        GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.7f);
        deadFreeze = false;
        canControl = true;
        //canDie = true;
        deathCount++;
    }

}
