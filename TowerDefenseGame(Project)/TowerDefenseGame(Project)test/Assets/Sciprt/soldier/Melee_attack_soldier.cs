using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_attack_soldier : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int health = 100;

    bool walk = true;
    bool fire = false;
    GameObject[] enemies;
    Transform target;
    float range = 50f;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float fireRate = 1f;
    float fireCountdown = 0f;
    public int damage = 80;


    //move forward
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);  //開始程式後不斷檢查有沒有敵人(士兵)
    }
    void UpdateTarget()
    {   // 更新最近的enemy為target 
        //Debug.Log("I am finding enemy");
        enemies = GameObject.FindGameObjectsWithTag("enemy");  // 找有soldier tag的enemy
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
        if (dist < 3)
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
            anim.SetTrigger("walk");
            transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        }


    }

    //fire
    void Fire()
    {
        if (fire == true)
        {
            Invoke("Attack", 0.5f * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            walk = false;
        }
    }

    void Die()
    {
        anim.SetTrigger("die");
        Destroy(gameObject, 1);
    }

    void Attack()
    {
        anim.SetTrigger("cut");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);

            if (enemy.GetComponent<enemyAction>() != null)
            {
                enemy.GetComponent<enemyAction>().TakeDamage(damage);
            }
            else if (enemy.GetComponent<enemyTower>() != null)
            {
                enemy.GetComponent<enemyTower>().TakeDamage(damage);
            }
            else if(enemy.GetComponent<Melee_attack>() != null)
            {
                enemy.GetComponent<Melee_attack>().TakeDamage(damage);
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }


}
