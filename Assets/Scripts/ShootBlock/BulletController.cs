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

    void Start()
    {
        //rb = bullet.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (shootUP == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, thrust, 0);
            //bullet.transform.position = new Vector2.up(0, 1);
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
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
