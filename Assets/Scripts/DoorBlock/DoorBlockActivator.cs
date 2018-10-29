using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlockActivator : MonoBehaviour
{

    public GameObject doorBlock;

    private bool startActivation = false;

    private const float minDistance = 0.03f;

    public float duration = 5.0F;
    private float startTime;

    private bool once = true;

    void Start()
    {
        //startTime = Time.time;
    }

    void Update()
    {
        if(startActivation == true)
        {
            //StartCoroutine(DoorBlockActivation());

            float t = (Time.time - startTime) / duration;
            this.gameObject.transform.position = Vector3.Lerp(transform.position, doorBlock.transform.position, Mathf.SmoothStep(0f, 0.5f, t));
            if ((this.gameObject.transform.position - doorBlock.transform.position).sqrMagnitude <= minDistance * minDistance)
            {
                startActivation = false;
                doorBlock.GetComponent<DoorBlockController>().isActive = true;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && startActivation == false)
        {
            //startTime = Time.time;
            //startActivation = true;
            //this.GetComponent<Animator>().Play("Door_block_activation_crystal_idle_1");
            StartCoroutine(CrystalTrigger());
        }
    }

    //IEnumerator DoorBlockActivation()
    //{
    //    float t = (Time.time - startTime) / duration;
    //    this.gameObject.transform.position = Vector3.Lerp(transform.position, doorBlock.transform.position, Mathf.SmoothStep(0f, 0.5f, t));
    //    yield return new WaitForSeconds(1f);
    //    if ((this.gameObject.transform.position - doorBlock.transform.position).sqrMagnitude <= minDistance * minDistance && once == true)
    //    {
    //        once = false;
    //        startActivation = false;
    //        doorBlock.GetComponent<DoorBlockController>().isActive = true;
    //    }
    //}\

    IEnumerator CrystalTrigger()
    {

        this.GetComponent<Animator>().Play("Door_block_activation_crystal_trigger_1");
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().Play("Door_block_activation_crystal_1");
        startTime = Time.time;
        startActivation = true;
    }
}
