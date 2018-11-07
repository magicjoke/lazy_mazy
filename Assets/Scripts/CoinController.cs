using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public bool isActive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == false)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
        if (isActive == true)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
