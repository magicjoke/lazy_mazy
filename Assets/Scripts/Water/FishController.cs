using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public bool isRight = true;
    public float speed = 0.1f;
    public float damping = 10;
    public float airPause = 1f;
    public float startDelay = 0f;
    private Vector3 pointAPosition;
    private Vector3 pointBPosition;
    // Use this for initialization
    private bool pEnabled = false;
    void Start()
    {
        pointAPosition = new Vector3(0, pointA.position.y, 0);
        pointBPosition = new Vector3(0, pointB.position.y, 0);
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (pEnabled == true)
        {

            Vector3 thisPosition = new Vector3(0, transform.position.y, 0);
            if (isRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed); //Vector3.Lerp(transform.position, pointB.position, Mathf.SmoothStep(0f, 0.5f, t));
                if (thisPosition.Equals(pointBPosition))
                {
                    //Debug.Log ("Position b");
                    //isRight = false;
                    StartCoroutine(RotateOne());
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed); //Vector3.Lerp(transform.position, pointA.position, Mathf.SmoothStep(0f, 0.5f, t));
                if (thisPosition.Equals(pointAPosition))
                {
                    //Debug.Log ("Position a");
                    //isRight = true;
                    StartCoroutine(RotateTwo());
                }
            }
        }
    }
    //    if (pEnabled == true)
    //    {

    //    }

    //    if(test == true)
    //    {
    //        this.GetComponent<Animator>().Play("Fish_in_water_1");
    //    }

    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.gameObject.tag == "Water")
    //    {
    //        //Debug.Log("InWater");
    //        gameObject.GetComponent<Animator>().Play("");
    //    }
    //}

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        pEnabled = true;
    }

    IEnumerator RotateOne()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90), Time.deltaTime * damping);
        yield return new WaitForSeconds(airPause);
        isRight = false;
    }
    IEnumerator RotateTwo()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -90), Time.deltaTime * damping);
        yield return new WaitForSeconds(airPause);
        isRight = true;
    }

}
