using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Image Dpad_sprite;
    Vector3 lastFramePosition;

    public float speed;
    public float turn_angle;
    public float turn_speed;

    public GameObject sprite;

    public GameObject Dpad_sr;
    public Sprite[] Dpad_sprites;

    bool up, down, left, right,
         upLeft, upRight, downLeft, downRight;

    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GameObject.Find("Player/Sprite");
        rb = GetComponent<Rigidbody2D>();
        Dpad_sprite = Dpad_sr.gameObject.GetComponent<Image>();
        //neutral = 0
        //up = 1        upleft = 5
        //down = 2      upright = 6
        //left = 3      downleft = 7
        //right = 4     downright = 8

        up = false;
        moving = false;
        lastFramePosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement_buttons();

        //rotates plane when you move left or right
        var delta = transform.position - lastFramePosition;
        if (delta.x < 0 && sprite.transform.rotation.eulerAngles.z < 15) //to the left
        {
            sprite.transform.Rotate(new Vector3(0, 0, turn_speed * Time.deltaTime));
        }
        if(delta.x > 0 && sprite.transform.rotation.eulerAngles.z > -15) //to the right
        {
            sprite.transform.Rotate(new Vector3(0, 0, -turn_speed * Time.deltaTime));
        }
        lastFramePosition = transform.position;
    }
    
    public void movement_buttons()
    {
        if (moving == false)
        {
            flightCorrections();
        }

        //base sprite for the D_pad. a simple '+'
        Dpad_sprite.sprite = Dpad_sprites[0];

        if (up)
        {
            Dpad_sprite.sprite = Dpad_sprites[1]; 
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            flightCorrections();
        }

        if (down)
        {
            Dpad_sprite.sprite = Dpad_sprites[2];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            flightCorrections();
        }

        if (left)
        {
            Dpad_sprite.sprite = Dpad_sprites[3];
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (right)
        { 
            Dpad_sprite.sprite = Dpad_sprites[4];
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (upLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[5];
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (upRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[6];
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (downLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[7];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (downRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[8];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    //========================= Called By Buttons (Canvas > ButtonArea > D-pad > buttons...) =============================

    //up    = 1         upLeft      = 5
    //down  = 2         upRight     = 6
    //left  = 3         downLeft    = 7
    //right = 4         downRight   = 8
    public void MOVE(int direction)
    {
        switch (direction) 
        {
            case 1:
                up = move_bool(up);
                break;

            case 2:
                down = move_bool(down);
                break;

            case 3:
                left = move_bool(left);
                break;

            case 4:
                right = move_bool(right);
                break;

            case 5:
                upLeft = move_bool(upLeft);
                break;

            case 6:
                upRight = move_bool(upRight);
                break;

            case 7:
                downLeft = move_bool(downLeft);
                break;

            case 8:
                downRight = move_bool(downRight);
                break;
        }
    }

    bool move_bool(bool direction)
    {
        if (direction == false)
        {
            direction = true;
            moving = true;
        }
        else
        {
            direction = false;
            moving = false;
        }

        return direction;
    }

    //so the phone vibrates
    public void vibrate()
    {
        Vibration.Vibrate(50);
    }

    //when the plane rotates to the side, it straightens it back to neutral
    void flightCorrections()
    {
        float temp_speed = 7.5f * turn_speed;
        if (sprite.transform.rotation.z >= 0.01f)//from the left
        {
            sprite.transform.Rotate(new Vector3(0, 0, -temp_speed * Time.deltaTime));
        }

        if (sprite.transform.rotation.z <= -0.01f)//from the right
        {
            sprite.transform.Rotate(new Vector3(0, 0, temp_speed * Time.deltaTime));
        }
        else
        { }
    }
}