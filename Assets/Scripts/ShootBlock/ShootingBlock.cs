using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBlock : MonoBehaviour
{
    public GameObject bulletSphere;

    public float shootDelay;
    public float startShootDelay;

    public bool sDelay = false;

    public bool shoot = false;


    public void Update()
    {

        if (sDelay == true)
        {
            StartCoroutine(StartDelay());
        }

        if (sDelay == false)
        {
            if (shoot == true)
            {
                StartCoroutine(ShootBullet());
            }
        }
    }

    IEnumerator ShootBullet()
    {
        shoot = false;
        Instantiate(bulletSphere, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(shootDelay);
        shoot = true;
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startShootDelay);
        sDelay = false;
    }

}
