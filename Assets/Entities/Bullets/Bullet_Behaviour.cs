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
        //rb2d.velocity = transform.up * speed;
        //dir = rb2d.velocity;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (this.transform.position.y >= screenBounds.y || 
            this.transform.position.y <= -screenBounds.y ||
            this.transform.position.x >= screenBounds.x ||
            this.transform.position.x <= -screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
}
