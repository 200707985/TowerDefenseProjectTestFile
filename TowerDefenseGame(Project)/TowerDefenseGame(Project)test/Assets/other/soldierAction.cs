using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierAction : MonoBehaviour
{
    public Transform enemy;
    public bool shouldStop = false;
    public float walkingSpeed;
    public float demage = 1;
    public int allowFireDistance = 5;
    public GameObject varGameObject;
    public GameObject bulletPrefab;
    public Transform firePoint;



    void Start()
    {
 
        enemy = GameObject.FindWithTag("enemy").transform;
        varGameObject = GameObject.FindWithTag("soldier");
    }
    void Update()
    {
        enemy = GameObject.FindWithTag("enemy").transform;

        if (!shouldStop) {
            this.transform.position += new Vector3(-walkingSpeed * Time.deltaTime, 0, 0);
            float dist = Vector3.Distance(transform.position, enemy.position);
            if (dist < allowFireDistance)
            {
                shouldStop = true;
                readyToShoot();
             //   varGameObject.GetComponent<weapon>().enabled = true;
            }

        }

        if (shouldStop) {
            float dist = Vector3.Distance(transform.position, enemy.position);
            if (dist> allowFireDistance) {
                shouldStop = false;
                this.transform.position += new Vector3(-walkingSpeed * Time.deltaTime, 0, 0);
                stopShoot();
             //   varGameObject.GetComponent<weapon>().enabled = false;
             //   varGameObject.GetComponent<weapon>().StopShoot();
            }
        }
        
        
    }
    void readyToShoot() {
        InvokeRepeating("shoot", 0f, 0.5f);
    }
    void shoot() {

        GameObject clone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(clone.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
    }

    void stopShoot() {
        CancelInvoke("shoot");
    }


/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
    //    soldierAction soldier = collision.GetComponent<soldierAction>();

        if (collision.gameObject.tag == "soldier") {
            Physics.IgnoreCollision(collision.GetComponent<Collider>(), GetComponent<Collider>());
        }
        
    }
*/


}

