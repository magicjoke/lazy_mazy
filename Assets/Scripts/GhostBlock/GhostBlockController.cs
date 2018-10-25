using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlockController : MonoBehaviour
{

    public bool isActive = false;

    public float waitTime = 2f;
    public float pauseBeforeDissapear = 4f;
    public float startDelay = 2f;


    void Start()
    {
        StartCoroutine(StartDelay());
    }

    void Update()
    {
        if (isActive == true)
        {
            StartCoroutine(GhostBlockAction());
        }

    }

    IEnumerator GhostBlockAction()
    {
        isActive = false;
        yield return new WaitForSeconds(pauseBeforeDissapear);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().Play("Ghost_block_dissapear_1");
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<Animator>().Play("Ghost_block_dissapear_2");
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Animator>().Play("Ghost_block_anim_1");
        isActive = true;
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        isActive = true;
    }
}
