using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemyTower enemyT = hitInfo.GetComponent<enemyTower>();
        if (enemyT!=null) 
        {
            enemyT.TakeDamage(damage);
            if (hitInfo.tag == "enemy")
            {
                Destroy(gameObject);
            }
        }

        enemyAction enemy = hitInfo.GetComponent<enemyAction>();
        if (enemy != null)
        {
            //Debug.Log("I hit you" + enemy.transform.name);
            enemy.TakeDamage(damage);
            if (hitInfo.tag == "enemy")
            {
                Destroy(gameObject);
            }
            // Destroy(gameObject);
        }

        Melee_attack meleeEnemy = hitInfo.GetComponent<Melee_attack>();
        if (meleeEnemy != null)
        {
            //Debug.Log("I hit you" + meleeEnemy.transform.name);
            meleeEnemy.TakeDamage(damage);
            if (hitInfo.tag == "enemy")
            {
                Destroy(gameObject);
            }
            // Destroy(gameObject);
        }

        BossAction enemy3 = hitInfo.GetComponent<BossAction>();
        if (enemy3 != null)
        {
            //Debug.Log("I hit you" + meleeEnemy.transform.name);
            enemy3.TakeDamage(damage);
            if (hitInfo.tag == "enemy")
            {
                Destroy(gameObject);
            }
            // Destroy(gameObject);
        }

        MagicAttack enemy2 = hitInfo.GetComponent<MagicAttack>();
        if (enemy2 != null)
        {
            //Debug.Log("I hit you" + meleeEnemy.transform.name);
            enemy2.TakeDamage(damage);
            if (hitInfo.tag == "enemy")
            {
                Destroy(gameObject);
            }
            // Destroy(gameObject);
        }

    }

}
