using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public Animator anim;

    void Start()
    {   
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     //   Debug.Log(collision.name);
        if (collision.tag == ("enemy"))     
        {
           anim.SetTrigger("attack");
        }
    }



}
