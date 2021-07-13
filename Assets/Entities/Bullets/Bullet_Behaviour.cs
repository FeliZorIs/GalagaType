using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour
{
    public GameObject bulletImpact;
    public float speed;

    Rigidbody2D rb2d;
    Vector2 dir;

    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        dir = rb2d.velocity;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.up * speed * Time.deltaTime);



        if (this.transform.position.y >= screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Instantiate(bulletImpact, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            /*Vector2 wallNormal = collision.contacts[0].normal;
            dir = Vector2.Reflect(rb2d.velocity, wallNormal).normalized;

            rb2d.velocity = dir * speed;
            */
        }
    }
}
