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
        if (collision.transform.tag == "red_bullet" || collision.transform.tag == "blue_bullet")
        {
            enemy.impact(enemy.bulletImpact, collision.transform.position);
            Destroy(collision.gameObject);

            enemy.health -= 1;
            anim.SetTrigger("hit");
        }
    }
}
