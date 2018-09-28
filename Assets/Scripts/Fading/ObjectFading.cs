using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFading : MonoBehaviour
{

    public SpriteRenderer spriteToFade;

    //public bool isActive = false;
    public bool fadeOutA = false;
    public bool fadeInA = false;


    void Update()
    {

        if (fadeOutA == true)
        {
            StartCoroutine(fadeOut(spriteToFade, 3f));
        }
        if(fadeInA == true)
        {
            StartCoroutine(fadeIn(spriteToFade, 3f));
        }

    }


    IEnumerator fadeOut(SpriteRenderer MyRenderer, float duration)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }
    IEnumerator fadeIn(SpriteRenderer MyRenderer, float duration)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0, 1, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }

}
