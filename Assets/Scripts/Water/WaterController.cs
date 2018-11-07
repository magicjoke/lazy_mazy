using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject spalash;

    public bool isActive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            spalash.GetComponent<Animator>().Play("Water_splash_1");
            isActive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Danger")
        {
            isActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            isActive = true;
        }
    }
}
