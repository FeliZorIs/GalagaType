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
            self.impact(self.bulletImpact, collision.transform.position);
            Destroy(collision.gameObject);

            self.health -= 1;
            anim.SetTrigger("hit");
        }

        if (collision.transform.tag == "red_bullet")
        {
            self.impact(self.sparks, collision.transform.position);
            float RanAngle = Random.Range(-45, 46);
            Vector3 newRot2 = new Vector3(0, 0, RanAngle);
            collision.transform.Rotate(newRot2);

            //Quaternion newRot = new Quaternion(0, 0, RanAngle, Quaternion.identity.w);
        }
    }
}
