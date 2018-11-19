using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignController : MonoBehaviour
{
    private bool castOnce = true;

    private Image sign;
    private Text text;

    //public bool RU_ENG = false;

    public string signText;
    public string signTextRU;
    private float fadingSpeed = 1f;

    private GameObject levelManager;


    private void Start()
    {
        //sign = GameObject.Find("Sign").GetComponent<Image>();
        //text = GameObject.Find("SignText").GetComponent<Text>();

        sign = GameObject.FindGameObjectWithTag("Sign").GetComponent<Image>();
        text = GameObject.FindGameObjectWithTag("SignText").GetComponent<Text>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");

        //sign = Image.FindObject
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && castOnce == true)
        {
            castOnce = false;
            // Instantiate(text, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            // text.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            //sign.SetActive(true);

            //sign.GetComponent<Image>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);

            StartCoroutine(FadingPause());

            //text.GetComponent<Text>().text = signText;
            if(levelManager.GetComponent<LevelManager>().RU_ENG == false)
            {
                text.text = signText;
            } else
            {
                text.text = signTextRU;
            }
        }
    }

    IEnumerator fadeIn(Image MyRenderer, Text MyText, float duration)
    {
        float counter = 0;
        //Get current color
        Color imageColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0, 1, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            MyText.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }
    IEnumerator fadeOut(Image MyRenderer, Text MyText, float duration)
    {
        float counter = 0;
        //Get current color
        Color imageColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            MyText.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }

    IEnumerator FadingPause()
    {
        StartCoroutine(fadeIn(sign, text, fadingSpeed));
        yield return new WaitForSeconds(5f);
        StartCoroutine(fadeOut(sign, text, fadingSpeed));
    }
}
