using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationSphere : MonoBehaviour
{

    public bool isActive;

    private GameObject player;

    public GameObject image;

    public GameObject whatToActivate;

    private const float minDistance = 0.05f;
    public float duration = 5.0F;
    private float startTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float t = (Time.time - startTime) / duration;

        if (isActive == true)
        {
            this.transform.position = Vector3.Lerp(transform.position, whatToActivate.transform.position, Mathf.SmoothStep(0f, 0.5f, t));
            Destroy(image);
        }

        if ((this.gameObject.transform.position - whatToActivate.transform.position).sqrMagnitude <= minDistance * minDistance)
        {
            player.GetComponent<PlayerController>().characterActivation = true;
            Destroy(gameObject);
        }
    }

    public void ActivateSphere()
    {
        startTime = Time.time;
        isActive = true;
    }
}
