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
        Dpad_sprite = Dpad_sr.gameObject.GetComponent<Image>();
        //neutral = 0
        //up = 1        upleft = 5
        //down = 2      upright = 6
        //left = 3      downleft = 7
        //right = 4     downright = 8

        up = false;
        moving = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement_buttons();
        //Debug.Log("Z: " + sprite.transform.rotation.z);
    }
    
    public void movement_buttons()
    {
        if (moving == false)
        {
            //flight corrections
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

        //base spritefor the D_pad. a simple '+'
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
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);

            turnSptite(false, turn_angle, turn_speed, sprite);
        }

        if (right)
        { 
            Dpad_sprite.sprite = Dpad_sprites[4];
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);

            turnSptite(true, turn_angle, turn_speed, sprite);
        }

        if (upLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[5];
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);

            turnSptite(false, turn_angle, turn_speed, sprite);
        }

        if (upRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[6];
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);

            turnSptite(false, turn_angle, turn_speed, sprite);
        }

        if (downLeft)
        {
            Dpad_sprite.sprite = Dpad_sprites[7];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);

            turnSptite(false, turn_angle, turn_speed, sprite);
        }

        if (downRight)
        {
            Dpad_sprite.sprite = Dpad_sprites[8];
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);

            turnSptite(false, turn_angle, turn_speed, sprite);
        }
    }

    //========================= Called By Buttons (Canvas > ButtonArea > D-pad > buttons...) =============================
    //up
    public void move_UP()
    {
        if (down == false)
            down = true;
        else
            down = false;
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
        {
            left = true;
            moving = true;
        }
        else
        {
            left = false;
            moving = false;
        }
    }

    //right
    public void move_RIGHT()
    {
        if (right == false)
        {
            right = true;
            moving = true;
        }
        else
        {
            right = false;
            moving = false;
        }
    }

    //upLeft
    public void move_UPRIGHT()
    {
        if (upRight == false)
        {
            upRight = true;
            moving = true;
        }
        else
        {
            upRight = false;
            moving = false;
        }
    }

    //upRight
    public void move_UPLEFT()
    {
        if (upLeft == false)
        {
            upLeft = true;
            moving = true;
        }
        else
        {
            upLeft = false;
            moving = false;
        }
    }

    //downLeft
    public void move_DOWNLEFT()
    {
        if (downLeft == false)
        {
            downLeft = true;
            moving = true;
        }
        else
        {
            downLeft = false;
            moving = false;
        }
    }

    //downRight
    public void move_DOWNRIGHT()
    {
        if (downRight == false)
        {
            downRight = true;
            moving = true;
        }
        else
        {
            downRight = false;
            moving = false;
        }
    }

    public void MOVE(int direction)
    {
        Debug.Log("1");
        switch (direction) 
        {
            case 1:
                Debug.Log("2");
                move_bool(up);
                break;

            case 2:
                move_bool(down);
                break;

            case 3:
                move_bool(left);
                break;

            case 4:
                move_bool(right);
                break;

            case 5:
                move_bool(upLeft);
                break;

            case 6:
                move_bool(upRight);
                break;

            case 7:
                move_bool(downLeft);
                break;

            case 8:
                move_bool(downRight);
                break;
        }
        Debug.Log("3");
    }

    void move_bool(bool direction)
    {
        Debug.Log("4");
        if (direction == false)
        {
            Debug.Log("5");
            direction = true;
            Debug.Log(direction);
            moving = true;
        }
        else
        {
            direction = false;
            moving = false;
        }
    }

    public void vibrate()
    {
        Vibration.Vibrate(50);
    }

    void turnSptite(bool direction, float angle, float speed, GameObject subject)
    {
        //direction = true  = right
        //direction = false = left

        float temp_speed = speed * 2;
        float deci_angle = (angle / 360)*3;

        if (direction == true)//right
        {
            if (subject.transform.rotation.z >= -deci_angle)
            {
                if (subject.transform.rotation.z > 0)
                {
                    subject.transform.Rotate(new Vector3(0, 0, -temp_speed * Time.deltaTime));
                }
                else
                    subject.transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
            }
            else if (subject.transform.rotation.z < -deci_angle)
            {
                subject.transform.eulerAngles = new Vector3(0, 0, -angle);
            }
        }

        else //left 
        {
            if (subject.transform.rotation.z <= deci_angle)
            {
                if (subject.transform.rotation.z > 0)
                {
                    subject.transform.Rotate(new Vector3(0, 0, temp_speed * Time.deltaTime));
                }
                else
                    subject.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else if (subject.transform.rotation.z > deci_angle)
            {
                subject.transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}