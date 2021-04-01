using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 400;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerTower playerT = hitInfo.GetComponent<playerTower>();
        if (playerT != null)
        {
            playerT.TakeDamage(damage);
            if (hitInfo.tag == "soldier")
            {
                Destroy(gameObject);
            }
        }
      
        soldierActionNew enemy = hitInfo.GetComponent<soldierActionNew>();
        if (enemy != null)
        {
            //Debug.Log("I hit you" + enemy.transform.name);
            enemy.TakeDamage(damage);
            if (hitInfo.tag == "soldier")
            {
                Destroy(gameObject);
            }
        }

        soldierActionNew2 enemy2 = hitInfo.GetComponent<soldierActionNew2>();
        if (enemy2 != null)
        {
            //Debug.Log("I hit you" + enemy.transform.name);
            enemy2.TakeDamage(damage);
            if (hitInfo.tag == "soldier")
            {
                Destroy(gameObject);
            }
        }

        Melee_attack_soldier enemy3 = hitInfo.GetComponent<Melee_attack_soldier>();
        if (enemy3 != null)
        {
            //Debug.Log("I hit you" + enemy.transform.name);
            enemy3.TakeDamage(damage);
            if (hitInfo.tag == "soldier")
            {
                Destroy(gameObject);
            }
        }
    }
}
