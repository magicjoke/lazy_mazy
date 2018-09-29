using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyGlowing : MonoBehaviour
{

    Light fireFlyLight;
    float lightInt;

    float lightStep = 4f;
    private float waitTime = 1f;

    public bool growUP;
    public bool growDOWN;

    void Start()
    {
        fireFlyLight = GetComponent<Light>();
        StartCoroutine(ChangeLight());
    }

    void Update()
    {
        if (growUP == true)
        {
            fireFlyLight.intensity += lightStep * Time.deltaTime;
        }
        else
        {
            fireFlyLight.intensity -= lightStep * Time.deltaTime;
        }
    }

    IEnumerator ChangeLight()
    {
        while (true)
        {
            growUP = false;
            yield return new WaitForSeconds(waitTime);
            growUP = true;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
