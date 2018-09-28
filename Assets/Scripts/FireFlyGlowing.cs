using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyGlowing : MonoBehaviour
{

    Light fireFlyLight;
    float lightInt;
    //public float minInt = 6f, maxInt = 9f;


    float lightStep = 4f;
    private float waitTime = 1f;

    public bool growUP;
    public bool growDOWN;

    // Start is called before the first frame update
    void Start()
    {
        fireFlyLight = GetComponent<Light>();
        StartCoroutine(ChangeLight());
    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(ChangeLight());

        if (growUP == true)
        {
            fireFlyLight.intensity += lightStep * Time.deltaTime;
        }
        else
        {
            fireFlyLight.intensity -= lightStep * Time.deltaTime;
        }

        //if (fireFlyLight.intensity == 6)
        //{
        //    growUP = true;
        //}
        //if (fireFlyLight.intensity > 10)
        //{
        //    growUP = false;
        //}


        //fireFlyLight.intensity += lightStep * Time.deltaTime;

        //if(fireFlyLight.intensity >= 6)
        //{
        //    fireFlyLight.intensity -= lightStep * Time.deltaTime;
        //}

        //lightInt = Random.Range(minInt, maxInt);
        //fireFlyLight.intensity = lightInt;
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
