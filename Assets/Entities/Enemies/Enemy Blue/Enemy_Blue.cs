using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Blue : MonoBehaviour
{
    /*
    * uses script:     Enemy.cs
    * connected to:    Red_Enemy GameObject
    */
    Animator anim;
    Enemy self;

    void Awake()
    {
        anim = GetComponent<Animator>();
        self = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "blue_bullet")
        {
            self.health -= 1;
            anim.SetTrigger("hit");
        }
    }
}
