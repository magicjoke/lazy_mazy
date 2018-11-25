using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public GameObject echo;
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;


    public Transform moveSpot;

    private int randomSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    void Start(){
        waitTime = startWaitTime;

        moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

    }


    void Update(){

        if (timeBtwSpawns <= 0)
        {
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance, 1f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

        transform.position = Vector3.Slerp(transform.position, moveSpot.transform.position, Mathf.SmoothStep(0f, 0.5f, speed));//Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
            if(waitTime <= 0){
                moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
