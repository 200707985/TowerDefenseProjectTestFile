using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAction : MonoBehaviour
{
    public int health = 100;

    bool walk = true;
    bool fire = false;
    GameObject[] enemies;
    Transform target;
    float range = 20f;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float fireRate = 1f;
    float fireCountdown = 0f;


    //move forward
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);  //開始程式後不斷檢查有沒有敵人(士兵)
    }
    void UpdateTarget()
    {   // 更新最近的enemy為target 
        enemies = GameObject.FindGameObjectsWithTag("soldier");  // 找有soldier tag的enemy
        float shortestDistance = Mathf.Infinity;     // 設定為正數
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,
                enemy.transform.position);  // find the distance between soldier and enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;   // 將最近的enemy  = target
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        walking();
        if (target == null)
        {   // 如果沒有找到target, 不要做以下的
            return;
        }

        float dist = Vector3.Distance(transform.position, target.transform.position);  // check 與最近敵人的距離
        if (dist < 10)
        {
            //Debug.Log("can see soldier");
            walk = false;
           // Debug.Log("enemy: stop");
            fire = true;
            if (fireCountdown <= 0f)
            {
                Fire();
            //    Debug.Log("monster is fire");
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;

        }
        else
        {
            fire = false;
            walk = true;
        }
    }

    void walking()
    {
        if (walk == true)
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }


    }

    //fire
    void Fire()
    {
        if (fire == true)
        {
            Invoke("Shoot", 0.5f * Time.deltaTime);
        }
    }

    void Shoot()
    {
        //  GameObject clone = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);

    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
