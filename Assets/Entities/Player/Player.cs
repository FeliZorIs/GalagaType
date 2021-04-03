using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Image Dpad_sprite;

    public float speed;
    public float turn_angle;

    public GameObject sprite;

    public GameObject Dpad_sr;
    public Sprite[] Dpad_sprites;

    bool up, down, left, right,
         upLeft, upRight, downLeft, downRight;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GameObject.Find("Player/Sprite");
        Dpad_sprite = Dpad_sr.gameObject.GetComponent<Image>();
        //neutral = 0
        //up = 1        upleft = 5
        //down = 2      upright = 6
        //left = 3      downleft = 7
        //right = 4     downright = 8

        up = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement_wasd();
        movement_buttons();
    }

    void movement_wasd()
    {
        sprite.transform.eulerAngles = new Vector3(0, 0, 0);
        Dpad_sprite.sprite = Dpad_sprites[0];

        //up
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            Dpad_sprite.sprite = Dpad_sprites[1];
        }

        //down
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            Dpad_sprite.sprite = Dpad_sprites[2];
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            Dpad_sprite.sprite = Dpad_sprites[3];
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            Dpad_sprite.sprite = Dpad_sprites[4];
        }

        //upleft
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Dpad_sprite.sprite = Dpad_sprites[5];
        }

        //upright
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Dpad_sprite.sprite = Dpad_sprites[6];
        }

        //downleft
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Dpad_sprite.sprite = Dpad_sprites[7];
        }

        //downright
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Dpad_sprite.sprite = Dpad_sprites[8];
        }

    }

    public void movement_buttons()
    {
        Dpad_sprite.sprite = Dpad_sprites[0];

        if (up)
        {
            Dpad_sprite.sprite = Dpad_sprites[1]; 
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (down)
        {
            Dpad_sprite.sprite = Dpad_sprites[2];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (left)
        {
            Dpad_sprite.sprite = Dpad_sprites[3];
            sprite.transform.eulerAngles = new Vector3(0, 0, turn_angle);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (right)
        {
            Dpad_sprite.sprite = Dpad_sprites[4];
            sprite.transform.eulerAngles = new Vector3(0, 0, -turn_angle);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (upLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[5];
            sprite.transform.eulerAngles = new Vector3(0, 0, turn_angle);

            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (upRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[6];
            sprite.transform.eulerAngles = new Vector3(0, 0, -turn_angle);

            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (downLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[7];
            sprite.transform.eulerAngles = new Vector3(0, 0, turn_angle);

            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (downRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[8];
            sprite.transform.eulerAngles = new Vector3(0, 0, -turn_angle);

            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    //up
    public void move_UP()
    {
        if (up == false)
            up = true;
        else
            up = false;
    }

    //down
    public void move_DOWN()
    {
        if (down == false)
            down = true;
        else
            down = false;
    }

    //left
    public void move_LEFT()
    {
        if (left == false)
            left = true;
        else
            left = false;
    }

    //right
    public void move_RIGHT()
    {
        if (right == false)
            right = true;
        else
            right = false;
    }

    //upLeft
    public void move_UPRIGHT()
    {
        if (upRight == false)
            upRight = true;
        else
            upRight = false;
    }

    //upRight
    public void move_UPLEFT()
    {
        if (upLeft == false)
            upLeft = true;
        else
            upLeft = false;
    }

    //downLeft
    public void move_DOWNLEFT()
    {
        if (downLeft == false)
            downLeft = true;
        else
            downLeft = false;
    }

    //downRight
    public void move_DOWNRIGHT()
    {
        if (downRight == false)
            downRight = true;
        else
            downRight = false;
    }
}