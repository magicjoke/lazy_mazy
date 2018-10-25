using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushJumpBlock : MonoBehaviour
{

    private GameObject player;

    public GameObject particle;

    public float damage;

    private float zeroFive = 0.5f;

    private int a;
    private int b;
    private int c;
    private int d;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = 0;
    }

    void Update()
    {
        if(damage == 1 && a <= 3)
        {
            this.GetComponent<Animator>().Play("Crush_jump_2");
            GameObject instance = (GameObject)Instantiate(particle, new Vector3(Random.Range(transform.position.x - zeroFive, transform.position.x + zeroFive), Random.Range(transform.position.y - zeroFive, transform.position.y + zeroFive), Random.Range(transform.position.z, transform.position.z)), Quaternion.identity);
            Destroy(instance, 2f);
            a++;

        }
        if (damage == 2 && b <= 3)
        {
            this.GetComponent<Animator>().Play("Crush_jump_3");
            GameObject instance = (GameObject)Instantiate(particle, new Vector3(Random.Range(transform.position.x - zeroFive, transform.position.x + zeroFive), Random.Range(transform.position.y - zeroFive, transform.position.y + zeroFive), Random.Range(transform.position.z, transform.position.z)), Quaternion.identity);
            Destroy(instance, 2f);
            b++;
        }
        if (damage == 3 && c <= 3)
        {
            this.GetComponent<Animator>().Play("Crush_jump_4");
            GameObject instance = (GameObject)Instantiate(particle, new Vector3(Random.Range(transform.position.x - zeroFive, transform.position.x + zeroFive), Random.Range(transform.position.y - zeroFive, transform.position.y + zeroFive), Random.Range(transform.position.z, transform.position.z)), Quaternion.identity);
            Destroy(instance, 2f);
            c++;
        }
        if (damage == 4 && d <= 6)
        {
            StartCoroutine(DestroyBlock());
            GameObject instance = (GameObject)Instantiate(particle, new Vector3(Random.Range(transform.position.x - zeroFive, transform.position.x + zeroFive), Random.Range(transform.position.y - zeroFive, transform.position.y + zeroFive), Random.Range(transform.position.z, transform.position.z)), Quaternion.identity);
            Destroy(instance, 2f);
            d++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && player.GetComponent<PlayerController>().verticalVelocity < -3)
        {
            damage++;
        }
    }

    IEnumerator DestroyBlock()
    {
        this.GetComponent<Animator>().Play("Crush_jump_5");
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);

    }
}
