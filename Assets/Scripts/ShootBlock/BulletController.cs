using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float thrust = 1f;

    public bool shootUP;
    public bool shootDOWN;
    public bool shootLEFT;
    public bool shootRIGHT;


    // -- TrailShiet -- //


    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;

    // -- EndTrailShiet -- //

    public GameObject bulletParticle;



    void Start()
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(activateCollision());
    }

    void Update()
    {

        if(timeBtwSpawns <= 0)
        {
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance, 1f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

        if (shootUP == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, thrust, 0);
        }
        if (shootDOWN == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -thrust, 0);
        }
        if (shootLEFT == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(-thrust, 0, 0);

        }
        if (shootRIGHT == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(thrust, 0, 0);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            GameObject instance = (GameObject)Instantiate(bulletParticle, transform.position, Quaternion.identity);
            Destroy(instance, 1f);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject instance = (GameObject)Instantiate(bulletParticle, transform.position, Quaternion.identity);
            Destroy(instance, 1f);
        }
    }

    IEnumerator activateCollision()
    {
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<CircleCollider2D>().enabled = true;
    }
}
