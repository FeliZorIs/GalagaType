using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Neutral : MonoBehaviour
{
    /*
     * uses script:     Enemy.cs
     * connected to:    Neutral_Enemy GameObject
    */
    Animator anim;
    Enemy enemy;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            enemy.health -= 1;
            anim.SetTrigger("hit");
            Debug.Log(this.transform.name + " Health: " + enemy.health);
        }
    }
}
