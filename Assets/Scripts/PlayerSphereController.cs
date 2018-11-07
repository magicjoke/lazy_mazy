using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSphereController : MonoBehaviour {

    private GameObject player;
    private GameObject respawn;
    private bool isAlive = false;
    //private float sphereSpeed = 1f;
    private const float minDistance = 0.1f;

    public float duration = 5.0F;
    private float startTime;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("RespawnPoint");
    }

    private void Start()
    {
        startTime = Time.time;
        isAlive = true;
    }

    void Update()
    {
        float t = (Time.time - startTime) / duration;

        if (isAlive == true)
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, respawn.transform.position, Mathf.SmoothStep(0f, 0.5f, t));
        }

        if (this.gameObject.transform.position == respawn.transform.position)
        {
            Debug.Log("onPLACE");
            player.GetComponent<PlayerController>().sphereOnRespawn = true;
            player.GetComponent<PlayerController>().canDie = true;
            isAlive = false;
            Destroy(this.gameObject);
        }
    }

    // - test - //
    IEnumerator WaterMove()
    {
        yield return new WaitForSeconds(0.6f);
    }

}
