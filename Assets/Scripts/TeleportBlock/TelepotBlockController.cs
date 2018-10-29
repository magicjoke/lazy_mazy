using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelepotBlockController : MonoBehaviour
{

    public GameObject from;
    public GameObject to;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if()
    }

    //void OnCollisionEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        player.transform.position = new Vector3(to.transform.position.x, to.transform.position.y, to.transform.position.z);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(to.transform.position.x, to.transform.position.y, to.transform.position.z);
        }
    }
}
