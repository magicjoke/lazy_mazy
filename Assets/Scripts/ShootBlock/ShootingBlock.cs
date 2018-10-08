using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBlock : MonoBehaviour
{
    public GameObject bulletSphere;

    public float shootPause;

    public bool shoot = false;


    public void Update()
    {
        if(shoot == true)
        {
            StartCoroutine(ShootBullet());
        }
    }

    IEnumerator ShootBullet()
    {
        shoot = false;
        yield return new WaitForSeconds(shootPause);
        Instantiate(bulletSphere, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        shoot = true;
    }

}
