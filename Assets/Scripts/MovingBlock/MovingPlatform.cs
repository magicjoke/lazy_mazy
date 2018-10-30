using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
    public bool pEnabled = false;

    public float verticalVelocity;
    public float horizontalVelocity;

    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;

    Rigidbody2D rb;

    private Vector3 pos;

    public bool onceLeft = true;
    public bool onceRight = true;
    public bool onceUp = true;
    public bool onceDown = true;

    public float changeDirectionPause;

    private bool testOnce = true;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = points [pointSelection];
        pos = transform.position;
    }


	void Update ()
    {

        if (pEnabled == true)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
            if (platform.transform.position == currentPoint.position)
            {
                if(testOnce == true)
                {
                    StartCoroutine(ChangeDirection());
                }
            }
        }

        if (transform.position.x < pos.x)
        {

            //Debug.Log("Left");

            moveLeft = true;
            moveRight = false;
            moveDown = false;
            moveUp = false;

            onceRight = true;

            if (moveLeft == true && onceLeft == true)
            {
                this.GetComponent<Animator>().Play("Moving_block_left_1");
                //this.GetComponent<Animator>().Play("Moving_block_right_to_left_1");
                onceLeft = false;
            }
        }
        if (transform.position.x > pos.x)
        {
            //Debug.Log("Right");
            moveLeft = false;
            moveRight = true;
            moveDown = false;
            moveUp = false;

            onceLeft = true;

            if (moveRight == true && onceRight == true)
            {
                this.GetComponent<Animator>().Play("Moving_block_right_1");
                //this.GetComponent<Animator>().Play("Moving_block_left_to_right_1");
                onceRight = false;
            }
        }
        if (transform.position.y > pos.y)
        {

            //Debug.Log("Up");
            moveUp = true;
            moveLeft = false;
            moveRight = false;
            moveDown = false;

            onceDown = true;

            if (moveUp == true && onceUp == true)
            {
                this.GetComponent<Animator>().Play("Moving_block_up_1");
                onceUp = false;
            }
        }
        if (transform.position.y < pos.y)
        {
            //Debug.Log("Down");
            moveDown = true;
            moveLeft = false;
            moveRight = false;
            moveUp = false;

            onceUp = true;

            if (moveDown == true && onceDown == true)
            {
                this.GetComponent<Animator>().Play("Moving_block_down_1");
                onceDown = false;
            }
        }
    }


    IEnumerator ChangeDirection()
    {
        testOnce = false;
        pos = transform.position;
        pointSelection++;

        if (pointSelection == points.Length)
        {
            pointSelection = 0;
        }

        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Moving_block_left_1"))
        {
            this.GetComponent<Animator>().Play("Moving_block_reverse_left_1");
        }
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Moving_block_right_1"))
        {
            this.GetComponent<Animator>().Play("Moving_block_reverse_right_1");
        }
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Moving_block_up_1"))
        {
            this.GetComponent<Animator>().Play("Moving_block_reverse_up_1");
        }
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Moving_block_down_1"))
        {
            this.GetComponent<Animator>().Play("Moving_block_reverse_down_1");
        }

        yield return new WaitForSeconds(changeDirectionPause);

        currentPoint = points[pointSelection];
        testOnce = true;
    }
}
