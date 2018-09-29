using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMover : MonoBehaviour {

    private GameObject crystalBase;
    private GameObject crystalFinish;
    public bool isAlive = false;
    private bool transferDone = false;
    private const float minDistance = 0.07f;

    public float startMoveTime = 2f;
    public float moveDuration = 40f;

    public float duration = 5.0F;
    private float startTime;

    void Start ()
    {
        startTime = Time.time;
        isAlive = true;
    }
	
	void Update ()
    {
        float t = (Time.time - startTime) / duration;
        crystalBase = GameObject.FindGameObjectWithTag("Crystal_base");
        crystalFinish = GameObject.FindGameObjectWithTag("Crystal_finish");

        if (isAlive == true)
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, crystalFinish.transform.position, Mathf.SmoothStep(0f, 0.5f, t));
        }
        if(transferDone == false && (this.gameObject.transform.position - crystalFinish.transform.position).sqrMagnitude <= minDistance * minDistance)
        {
            crystalBase.GetComponent<CrystalController>().onPlace = true;
            transferDone = true;
            Debug.Log("Transfer...");
        }
    }
}
