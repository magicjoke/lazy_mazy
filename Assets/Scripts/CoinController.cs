using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public bool isActive;

    public float startDelay;

    public GameObject coinPickupParticle;

    void Start()
    {
        StartCoroutine(AnimDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == false)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.transform.Find("CoinParticle").gameObject.SetActive(false);

        }
        if (isActive == true)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            this.GetComponent<CircleCollider2D>().enabled = true;
            this.transform.Find("CoinParticle").gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject instance = (GameObject)Instantiate(coinPickupParticle, this.transform.position, Quaternion.identity);
            Destroy(instance, 1.5f);
        }
    }

    IEnumerator AnimDelay()
    {
        yield return new WaitForSeconds(startDelay);
        this.GetComponent<Animator>().Play("Coin_float_1");
    }
}
