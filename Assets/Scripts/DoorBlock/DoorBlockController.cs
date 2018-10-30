using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlockController : MonoBehaviour
{
    public bool isActive;

    public bool isVertical = false;


    // Update is called once per frame
    void Update()
    {
        if(isActive == true && isVertical == false)
        {
            //this.GetComponent<Animator>().Play("Door_block_opening_1");
            //isActive = false;
            StartCoroutine(DoorBlockAction());
        }
        if (isActive == true && isVertical == true)
        {
            //this.GetComponent<Animator>().Play("Door_block_opening_1");
            //isActive = false;
            StartCoroutine(VerticalDoorBlockAction());
        }
    }

    IEnumerator DoorBlockAction()
    {
        isActive = false; 
        this.GetComponent<Animator>().Play("Door_block_opening_1");
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().Play("Door_block_light_start_1");
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<Animator>().Play("Door_block_light_end_1");
        //this.GetComponent<BoxCollider2D>().enabled = true;
        //isActive = true;
    }
    IEnumerator VerticalDoorBlockAction()
    {
        isActive = false;
        this.GetComponent<Animator>().Play("Door_block_vertical_activation_1");
        yield return new WaitForSeconds(0.8f);
        this.GetComponent<Animator>().Play("Door_block_vertical_opening_1");
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().Play("Door_block_vertical_opened_1");
        //yield return new WaitForSeconds(0.4f);
        //this.GetComponent<Animator>().Play("Door_block_vertical_light_end_1");
    }
}
