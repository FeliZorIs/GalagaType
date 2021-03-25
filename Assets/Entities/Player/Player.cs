using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public GameObject sprite;

    public GameObject Dpad_sr;
    public Sprite[] Dpad_sprites;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GameObject.Find("Player/Sprite");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        sprite.transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            move_up();
        }

        if (Input.GetKey(KeyCode.S))
        {
            move_down();
        }

        if (Input.GetKey(KeyCode.A))
        {
            sprite.transform.eulerAngles = new Vector3(0, 0, 45);
            move_left();
        }

        if (Input.GetKey(KeyCode.D))
        {
            sprite.transform.eulerAngles = new Vector3(0, 0, -45);
            move_right();
        }
    }

    public void move_up()
    {
        this.transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void move_down()
    {
        this.transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void move_left()
    {
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void move_right()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
