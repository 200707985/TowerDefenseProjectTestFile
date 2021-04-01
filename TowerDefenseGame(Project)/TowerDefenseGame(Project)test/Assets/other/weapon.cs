using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1.0f;

    void Start()
    {
        //if (Input.GetButtonDown("Fire1")) {
        //  Shoot();
        //}

        InvokeRepeating("Shoot",0f,fireRate);
    }

    void Shoot() {

        GameObject clone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(clone.GetComponent<CircleCollider2D>(),GetComponent<BoxCollider2D>());

    }

    public void StopShoot() {
        CancelInvoke("Shoot");
    }

}
